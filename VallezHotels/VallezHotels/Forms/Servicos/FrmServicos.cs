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
    public partial class FrmServicos : Form
    {

        private readonly ServicoServico _adicionalServico;
        private Servico Servico;

        public bool AtualizarLista;
        public int IdServico;


        public FrmServicos()
        {
            _adicionalServico = new ServicoServico();
            Servico = new Servico();
            AtualizarLista = false;
            InitializeComponent();
        }


        private void FrmServicos_Load(object sender, EventArgs e)
        {
            if (IdServico > 0)
            {
                Servico = _adicionalServico.BuscarPeloId(IdServico);
                PreencherCampos(Servico);
            }
        }

        private void PreencherCampos(Servico s )
        {

            txtCodigo.Text = s.Id.ToString();
            txtDescricao.Text = s.Descricao.ToString();
            txtValor.Text = s.Valor.ToString("F2");
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {


            if (string.IsNullOrEmpty(txtDescricao.Text.Trim().ToString()))
            {
                MessageBox.Show("A descrição deve ser informada", "Atenção !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescricao.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtValor.Text.Trim().ToString()))
            {
                MessageBox.Show("O valor deve ser informada", "Atenção !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtValor.Focus();
                return;
            }

            Servico.Descricao = txtDescricao.Text.Trim().ToString();
            Servico.Valor = Double.Parse(txtValor.Text.Trim().ToString());

            try
            {

                Servico s = null;

                if (IdServico > 0)
                {
                    s = _adicionalServico.AlterarServico(Servico);
                } else
                {
                    s = _adicionalServico.InserirServico(Servico);
                }


                if (s != null)
                {
                    MessageBox.Show($"Serviço de Id {s.Id} foi gerênciado !", "Sucesso !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AtualizarLista = true;
                    PreencherCampos(s);

                } else
                {
                    MessageBox.Show("Não foi possivel gerênciar o servico !", "Atenção !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Uma exceção ocorreu !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
