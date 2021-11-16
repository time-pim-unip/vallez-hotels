using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using VallezHotels.Source.Entidades;
using VallezHotels.Source.Servicos;

namespace VallezHotels
{
    public partial class FrmDashboard : Form
    {

        private readonly QuartoServico _quartoServico;
        private readonly LocacaoServico _locacaoServico;
        private readonly HospedagemServico _hospedagemServico;

        public FrmDashboard()
        {
            _quartoServico = new QuartoServico();
            _locacaoServico = new LocacaoServico();
            _hospedagemServico = new HospedagemServico();

            InitializeComponent();
        }

        private void AtualizarDashboard()
        {
            List<Quarto> quartos = _quartoServico.BuscarTodos();
            List<Locacao> locacoes = new List<Locacao>();

            pnlExibicaoQuartos.Controls.Clear();

            var listQuartos = from q in quartos
                              orderby q.Bloco, q.Numero
                              select q;

            foreach (Quarto quarto in listQuartos)
            {
                Locacao l = _locacaoServico.BuscarPelaDataEQuarto(quarto, dtLocacao.Value.Date);
                l.Hospedagems = _hospedagemServico.BuscarPelaLocacao(l);
                locacoes.Add(l);

                FrmDescricaoQuarto q = new FrmDescricaoQuarto();
                q.Quarto = quarto;
                q.DataSelecionada = dtLocacao.Value;
                q.Locacao = l;
                q.TopLevel = false;
                q.Parent = this;
                q.Visible = true;
                pnlExibicaoQuartos.Controls.Add(q);
            }


            int quantidadeQuartosDisponiveis = quartos.Where(q => q.Disponibilidades.Where(d => d.Data.Date == DateTime.Now.Date && d.Disponivel == true).Count() != 0).Count();
            lblQuartosDisponiveis.Text = $"Quartos disponiveis: {quantidadeQuartosDisponiveis}";

            int quantidadeQuartosNaoDisponiveis = quartos.Where(q => q.Disponibilidades.Where(d => d.Data.Date == DateTime.Now.Date && d.Disponivel == false).Count() != 0).Count();
            lblQuartosNãoDisponiveis.Text = $"Quartos não disponiveis: {quantidadeQuartosNaoDisponiveis}";

            int quantidadeQuartosOcupados = locacoes.Where(l => l.Hospedagems.Count > 0).Count();
            lblQuartosOcupados.Text = $"Quartos ocupados: {quantidadeQuartosOcupados}";

            int quantidadeCheckIn = locacoes.Where(l => l.DataEntrada == DateTime.Now.Date && l.CheckIn == null).Count();
            lblCheckins.Text = $"Check-in para hoje: {quantidadeCheckIn}";

        }

        private void FrmDashboard_Load(object sender, EventArgs e)
        {

            dtLocacao.Value = DateTime.Now;
            AtualizarDashboard();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tmrBuscarQuartos_Tick(object sender, EventArgs e)
        {
            AtualizarDashboard();
        }

        private void dtLocacao_ValueChanged(object sender, EventArgs e)
        {
            AtualizarDashboard();
        }
    }
}
