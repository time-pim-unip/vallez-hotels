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
    public partial class FrmTipoQuarto : Form
    {
        private TipoQuartoServico _tipoQuartoServico;
        private TipoQuarto TipoQuarto;
        public bool AtualizarLista;
        public int IdTipoQuarto;

        public FrmTipoQuarto()
        {
            _tipoQuartoServico = new TipoQuartoServico();
            TipoQuarto = new TipoQuarto();
            AtualizarLista = false;
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmTipoQuarto_Load(object sender, EventArgs e)
        {
            if (IdTipoQuarto > 0)
            {
                TipoQuarto = _tipoQuartoServico.BuscarPeloId(IdTipoQuarto);
                this.PreencherCampos(TipoQuarto);
            }
        }

        public void PreencherCampos(TipoQuarto tq)
        {
            txtCodigo.Text = tq.Id.ToString();
            txtDescricao.Text = tq.Descricao.ToString();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDescricao.Text.Trim()))
            {
                MessageBox.Show("Uma descrição deve ser informada", "Atenção !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            TipoQuarto.Descricao = txtDescricao.Text.Trim().ToString();

            try
            {

                TipoQuarto tq = null;

                if (IdTipoQuarto > 0)
                {
                    tq = _tipoQuartoServico.AlterarTipoQuarto(TipoQuarto);

                }else
                {
                    tq = _tipoQuartoServico.InserirTipoQuarto(TipoQuarto);
                }
                
                if (tq != null)
                {
                    MessageBox.Show("Tipo de quarto gerênciado com sucesso !", "Sucesso !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.AtualizarLista = true;
                    this.PreencherCampos(tq);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ocorreu um exceção !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
