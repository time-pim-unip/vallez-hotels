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
    public partial class FrmLocacao : Form
    {

        private readonly LocacaoServico _locacaoServico;
        private readonly DisponibilidadeServico _disponibilidadeServico;
        public Quarto Quarto;

        public FrmLocacao()
        {
            _locacaoServico = new LocacaoServico();
            _disponibilidadeServico = new DisponibilidadeServico();
            Quarto = new Quarto();
            InitializeComponent();
        }

        private void FrmLocacao_Load(object sender, EventArgs e)
        {

            if (Quarto.Uuid != null)
            {
                Locacao locacao = _locacaoServico.BuscarPelaDataEQuarto(Quarto, DateTime.Now);

                if (locacao != null)
                {
                    txtCodigo.Text = locacao.Id.ToString();
                    dtEntrada.Value = locacao.DataEntrada;
                    dtSaida.Value = locacao.DataSaida;
                    dtCheckin.Value = locacao.CheckIn;
                    dtCheckout.Value = locacao.CheckOut;
                }

                txtQuarto.Text = Quarto.Id.ToString();
                txtBloco.Text = Quarto.Bloco;
                txtNumero.Text = Quarto.Numero.ToString();
            }

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


            Locacao locacao = new Locacao();
            locacao.Quarto = Quarto;
            locacao.DataEntrada = dtEntrada.Value;
            locacao.DataSaida = dtSaida.Value;
            locacao.CheckIn = dtCheckin.Value;
            locacao.CheckOut = dtCheckout.Value;


            try
            {
                Locacao l = null;
                
                if (!string.IsNullOrEmpty(txtCodigo.Text))
                {
                    l = _locacaoServico.EditarLocacao(locacao);
                } else
                {
                   l =  _locacaoServico.InserirLocacao(locacao);
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
    }
}
