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
using VallezHotels.Source.DTO;

namespace VallezHotels
{
    public partial class FrmLocacao : Form
    {

        private readonly LocacaoServico _locacaoServico;
        private readonly DisponibilidadeServico _disponibilidadeServico;
        private readonly HospedeServico _hospedeServico;
        private readonly HospedagemServico _hospedagemServico;
        private readonly QuartoServico _quartoServico;

        private bool AdicionarHospedes;
        List<Object> ListaHospedagem;

        public Quarto Quarto;
        private Locacao Locacao;
        private Locacao LocacaoAntiga;

        public FrmLocacao()
        {
            _locacaoServico = new LocacaoServico();
            _disponibilidadeServico = new DisponibilidadeServico();
            _hospedeServico = new HospedeServico();
            _hospedagemServico = new HospedagemServico();
            _quartoServico = new QuartoServico();
            AdicionarHospedes = false;

            Quarto = new Quarto();
            Locacao = new Locacao();
            ListaHospedagem = new List<Object>();

            InitializeComponent();
        }

        private void FrmLocacao_Load(object sender, EventArgs e)
        {

            dtEntrada.Value = DateTime.Now.Date;
            dtSaida.Value = DateTime.Now.Date;

            Locacao = _locacaoServico.BuscarPelaDataEQuarto(Quarto, DateTime.Now);
            Locacao.Quarto = Quarto;

            if (Locacao.Uuid != null)
            {
                Locacao.Hospedagems = _hospedagemServico.BuscarPelaLocacao(Locacao);
                    
                txtCodigo.Text = Locacao.Id.ToString();
                dtEntrada.Value = Locacao.DataEntrada;
                dtSaida.Value = Locacao.DataSaida;
                dtCheckin.Value = Locacao.CheckIn;
                dtCheckout.Value = Locacao.CheckOut;
                    
                //dgHospedes.DataSource = null;
                foreach (Hospedagem h in Locacao.Hospedagems)
                {
                    Object row = new
                    {
                        Codigo = h.Hospede.IdHospede.ToString(),
                        Nome = h.Hospede.Nome,
                        Detentor = h.Detentor
                    };

                    ListaHospedagem.Add(row);
                }

                dgHospedes.DataSource = ListaHospedagem;

            } else
            {
                Locacao.DataEntrada = DateTime.Now.Date;
                Locacao.DataSaida = DateTime.Now.Date;
            }

            // Exibir valor da locação
            lblValorLocacao.Text = $"R$ {Locacao.ValorDaLocacao().ToString("F2")}";

            txtQuarto.Text = Quarto.Id.ToString();
            txtBloco.Text = Quarto.Bloco;
            txtNumero.Text = Quarto.Numero.ToString();

            LocacaoAntiga = new Locacao()
            {
                DataEntrada = Locacao.DataEntrada,
                DataSaida = Locacao.DataSaida
            };

        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {

            // Verificar disponibilidade das datas selecionadas para locação.
            List<Disponibilidade> disponibilidades = _disponibilidadeServico.BuscarPeloQuarto(Quarto);
            List<DateTime> datasPeriodo = dtEntrada.Value.RetornarPeriodo(dtSaida.Value);

            foreach (DateTime dt in datasPeriodo)
            {
                if (disponibilidades.Where(d => d.Data.Date == dt.Date && d.Disponivel == false).Count() != 0)
                {
                    MessageBox.Show("O periodo selecionado é invalido !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning) ;
                    return;
                }

            }

            // Verificar se existe um hospede ao inserir nova locação
            if (string.IsNullOrEmpty(txtCodigo.Text))
            {

                if (dgHospedes.Rows.Count == 0)
                {
                    MessageBox.Show("Pelo menos 1 hospede deve ser inserido para a locação !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

            }

            Locacao.Quarto = Quarto;
            Locacao.DataEntrada = dtEntrada.Value;
            Locacao.DataSaida = dtSaida.Value;
            Locacao.CheckIn = dtCheckin.Value;
            Locacao.CheckOut = dtCheckout.Value;


            try
            {
                Locacao l = new Locacao();
                
                if (!string.IsNullOrEmpty(txtCodigo.Text))
                {
                    _quartoServico.HabilitarDisponibilidades(Locacao.Quarto, LocacaoAntiga);
                    l = _locacaoServico.EditarLocacao(Locacao);
                } else
                {
                   l =  _locacaoServico.InserirLocacao(Locacao);
                }

                if (AdicionarHospedes)
                {
                    foreach (DataGridViewRow row in dgHospedes.Rows)
                    {

                        // Verifica se o hóspede já faz parte desta locação
                        var existe = Locacao.Hospedagems.Where(x => x.Hospede.IdHospede == int.Parse(row.Cells["Codigo"].Value.ToString()));
                        if (existe.Count() == 0)
                        {
                            Hospedagem h = new Hospedagem();
                            h.Locacao = l;
                            h.Hospede = _hospedeServico.BuscarPeloId(int.Parse(row.Cells["Codigo"].Value.ToString()));
                            h.Detentor = bool.Parse(row.Cells["Detentor"].Value.ToString());

                            h = _hospedagemServico.InserirHospedagem(h);

                        }
                    }
                }

                if (l != null)
                {
                    MessageBox.Show("Locação gerênciada com sucesso", "Sucesso !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ocorreu uma exceção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            FrmListagemGenerica listagem = new FrmListagemGenerica();
            List<Hospede> hospedes = _hospedeServico.BuscarTodos();

            IEnumerable<ListagemGenericaDTO> dados = from h in hospedes
                                                     orderby h.Nome
                                                      select new ListagemGenericaDTO()
                                                      {
                                                          Codigo = h.IdHospede,
                                                          Descricao = h.Nome
                                                      };

            listagem.Lista = dados.ToList();
            listagem.ShowDialog();

            if (listagem.CodigoSelecionado > 0)
            {
                Hospede h = _hospedeServico.BuscarPeloId(listagem.CodigoSelecionado);

                txtCodigoHospede.Text = h.IdHospede.ToString();
                txtNomeHospede.Text = h.Nome.ToString();

            }

        }

        private void btnAddHospede_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCodigoHospede.Text.ToString()))
            {
                MessageBox.Show("Escolha um hospede antes de adicionar", "Ateñção !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Verifica se o hóspede já faz parte desta locação
            var existe = Locacao.Hospedagems.Where(x => x.Hospede.IdHospede == int.Parse(txtCodigoHospede.Text.ToString()));
            if (existe.Count() > 0)
            {
                MessageBox.Show("Hospede já inserido", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dgHospedes.DataSource = null;
            AdicionarHospedes = true;

            Object row = new
            {
                Codigo = txtCodigoHospede.Text.ToString(),
                Nome = txtNomeHospede.Text.ToString(),
                Detentor = chkDetentor.Checked
            };

            ListaHospedagem.Add(row);
            dgHospedes.DataSource = ListaHospedagem;
        }

        private void dtSaida_ValueChanged(object sender, EventArgs e)
        {
            if (dtSaida.Value < dtEntrada.Value)
            {
                dtSaida.Value = dtEntrada.Value;
                MessageBox.Show("Data de saida não pode ser menor que a data de entrada !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (dtSaida.Value < DateTime.Now.Date)
            {
                dtEntrada.Value = DateTime.Now.Date;
                MessageBox.Show("Data de saida não pode ser menor que a data atual !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            Locacao.DataSaida = dtSaida.Value;
            lblValorLocacao.Text = $"R$ {Locacao.ValorDaLocacao().ToString("F2")}";
        }

        private void dtEntrada_ValueChanged(object sender, EventArgs e)
        {
            if (dtEntrada.Value > dtSaida.Value)
            {
                dtEntrada.Value = dtSaida.Value;
                MessageBox.Show("Data de entrada não pode ser maior que a data da saida !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            } else if (dtEntrada.Value < DateTime.Now.Date)
            {
                dtEntrada.Value = DateTime.Now.Date;
                MessageBox.Show("Data de entrada não pode ser menor que a data atual !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Locacao.DataEntrada = dtEntrada.Value;
            lblValorLocacao.Text = $"R$ {Locacao.ValorDaLocacao().ToString("F2")}";
        }
    }
}
