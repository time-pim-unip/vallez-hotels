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
    public partial class FrmQuarto : Form
    {

        private readonly TipoQuartoServico _tipoQuartoServico;
        private readonly QuartoServico _quartoServico;
        private Quarto Quarto;
        public bool AtualizarListaQuartos;
        public int IdQuarto;

        public FrmQuarto()
        {
            _quartoServico = new QuartoServico();
            _tipoQuartoServico = new TipoQuartoServico();
            Quarto = new Quarto();



            InitializeComponent();
        }

        private void PreencherCampos(Quarto q)
        {
            txtCodigo.Text = q.Id.ToString();
            txtBloco.Text = q.Bloco.ToString();
            txtNumero.Text = q.Numero.ToString();
            cbTipoQuarto.SelectedItem = q.TipoQuarto.Descricao.ToString();
            txtValorDiaria.Text = q.ValorDiaria.ToString("F2");
            txtCamas.Text = q.QuantidadeCamas.ToString();
            txtBanheiros.Text = q.QuantidadeBanheiros.ToString();

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmQuarto_Load(object sender, EventArgs e)
        {
            List<TipoQuarto> tipoQuartos = _tipoQuartoServico.BuscarTodos();

            foreach (TipoQuarto tq in tipoQuartos)
            {
                cbTipoQuarto.Items.Add(tq.Descricao);
            }

            if (IdQuarto > 0)
            {
                Quarto q = _quartoServico.BuscarPeloId(IdQuarto);
                PreencherCampos(q);
            }

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {

            Quarto.Bloco = txtBloco.Text.Trim().ToUpper().ToString();
            Quarto.Numero = int.Parse(txtNumero.Text.Trim().ToString());
            Quarto.TipoQuarto =  _tipoQuartoServico.BuscarPeloNome(cbTipoQuarto.SelectedItem.ToString().Trim());
            Quarto.ValorDiaria = double.Parse(txtValorDiaria.Text.Trim().ToString());
            Quarto.QuantidadeCamas = int.Parse(txtCamas.Text.Trim().ToString());
            Quarto.QuantidadeBanheiros = int.Parse(txtBanheiros.Text.Trim().ToString());

            try
            {
                Quarto q = _quartoServico.InserirQuarto(Quarto);

                if ( q !=  null)
                {
                    MessageBox.Show("Quarto gerênciado com sucesso !", "Sucesso !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.AtualizarListaQuartos = true;
                    this.PreencherCampos(q);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ocorreu uma exceção");
            }

        }

        private void txtBanheiros_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
