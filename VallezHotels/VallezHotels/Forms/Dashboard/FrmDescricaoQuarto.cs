using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VallezHotels.Source.Core;
using VallezHotels.Source.Entidades;
using VallezHotels.Source.Servicos;

namespace VallezHotels
{
    public partial class FrmDescricaoQuarto : Form
    {
        private readonly QuartoServico _quartoServico;
        private readonly LocacaoServico _locacaoServico;
        private readonly HospedagemServico _hospedagemServico;
        private readonly ServicoSolicitadoServico _servicoSolicitadoServico;
        

        public Quarto Quarto;
        public Locacao Locacao;
        public DateTime DataSelecionada;
        public bool Disponivel;


        public FrmDescricaoQuarto()
        {

            _quartoServico = new QuartoServico();
            _locacaoServico = new LocacaoServico();
            _hospedagemServico = new HospedagemServico();
            _servicoSolicitadoServico = new ServicoSolicitadoServico();

            Quarto = new Quarto();
            Locacao = new Locacao();
            DataSelecionada = new DateTime();

            Disponivel = false;
            InitializeComponent();
        }

        public void AtualizarDetalhes()
        {
            Locacao = _locacaoServico.BuscarPeloId(Locacao.Id);
            //Locacao = _locacaoServico.BuscarPelaDataEQuarto(Quarto, DataSelecionada);
            Quarto = _quartoServico.BuscarPeloId(Quarto.Id);

            if (Locacao.Uuid != null)
            {
                Locacao.Quarto = Quarto;
                Locacao.Hospedagems = _hospedagemServico.BuscarPelaLocacao(Locacao);
                Locacao.ServicosSolicitados = _servicoSolicitadoServico.BuscarPelaLocacao(Locacao);

                lblHospedes.Visible = true;
                lblEntrada.Visible = true;
                lblSaida.Visible = true;
                lblCheckin.Visible = true;
                lblCheckout.Visible = true;
                lblValor.Visible = true;

                lblLocacao.Text = $"#{Locacao.Id}";
                lblHospedes.Text = $"Quantidade de hospedes: {Locacao.Hospedagems.Count}";
                lblEntrada.Text  = $"Data entrada   : {Locacao.DataEntrada.ToString("dd/MM/yyyy")}";
                lblSaida.Text    = $"Data saida     : {Locacao.DataSaida.ToString("dd/MM/yyyy")}";

                lblCheckin.Text  = $"Data check-in  : {Locacao.CheckIn.ToString()}";
                lblCheckout.Text = $"Data check-out : {Locacao.CheckOut.ToString()}";

                lblValor.Text = $"Valor: R${Locacao.ValorDaLocacao()}";

            }


            lblDescricao.Text = Quarto.Descricao;
            lblBloco.Text = $"Bloco: {this.Quarto.Bloco}";
            lblNumQuarto.Text = $"Quarto: {this.Quarto.Numero}";
            lblTipoQuarto.Text = this.Quarto.TipoQuarto.Descricao;

            var disponibilidade = this.Quarto.Disponibilidades.Where(x => x.Data.Date.ToString() == DataSelecionada.Date.ToString());
            Disponibilidade d = null;
            if (disponibilidade.Count() == 0)
            {
                d = new Disponibilidade();
            }
            else
            {
                d = disponibilidade.FirstOrDefault();
            }

            Disponivel = d.Disponivel;

            lblSituacao.Text = (d.Disponivel) ? "Disponivel" : "Não disponivel";
            this.Cursor = Cursors.Hand;

            if (d.Disponivel)
            {
                this.BackColor = Color.FromArgb(0, 173, 181);
            }
            else if (Locacao.Hospedagems.Count > 0)
            {
                this.BackColor = Color.FromArgb(255, 131, 3);
            }
            else if (!d.Disponivel)
            {
                this.BackColor = Color.FromArgb(251, 54, 64);
            }

        }

        private void FrmDescricaoQuarto_Load(object sender, EventArgs e)
        {

            AtualizarDetalhes();

        }

        private void FrmDescricaoQuarto_MouseClick(object sender, MouseEventArgs e)
        {
            FrmLocacao locacao = new FrmLocacao();
            locacao.Quarto = Quarto;
            locacao.Locacao = Locacao;
            locacao.DataSelecionada = DataSelecionada;
            locacao.ShowDialog();

            AtualizarDetalhes();

        }

        private void lblSituacao_Click(object sender, EventArgs e)
        {

        }

        private void lblTipoQuarto_Click(object sender, EventArgs e)
        {

        }

        private void lblCheckout_Click(object sender, EventArgs e)
        {

        }

        private void lblCheckin_Click(object sender, EventArgs e)
        {

        }

        private void lblSaida_Click(object sender, EventArgs e)
        {

        }

        private void lblEntrada_Click(object sender, EventArgs e)
        {

        }

        private void lblHospedes_Click(object sender, EventArgs e)
        {

        }
    }
}
