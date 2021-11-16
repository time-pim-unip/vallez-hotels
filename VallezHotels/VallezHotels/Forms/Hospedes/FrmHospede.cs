using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using VallezHotels.Source.Servicos;
using VallezHotels.Source.Entidades;
using VallezHotels.Source.Enums;

namespace VallezHotels
{
    public partial class FrmHospede : Form
    {
        public bool AtualizarListaHospedes;
        public int IdHospede;
        private readonly HospedeServico _hospedeServico;
        private Hospede Hospede;

        public FrmHospede()
        {
            _hospedeServico = new HospedeServico();
            Hospede = new Hospede();
            AtualizarListaHospedes = false;
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmHospede_Load(object sender, EventArgs e)
        {
            if (IdHospede > 0)
            {
                Hospede = _hospedeServico.BuscarPeloId(IdHospede);
                PreencherCampos(Hospede);
            }
        }

        private void PreencherCampos(Hospede h)
        {
            txtCodigo.Text = h.IdHospede.ToString();
            txtNome.Text = h.Nome.ToString();
            txtCPF.Text = h.Cpf.ToString();
            txtRG.Text = h.RG.ToString();
            dtNascimento.Value = h.DataNascimento;
            chkConsentimento.Checked = h.Consentimento;
            txtTelefone.Text = h.Telefone.ToString();
            txtCelular.Text = h.Celular.ToString();
            txtEmail.Text = h.Email.ToString();
            txtUsuario.Text = h.Usuario.NomeUsuario.ToString();
            txtSenha.Text = h.Usuario.Senha.ToString();
            chkAtivo.Checked = h.Usuario.Status;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtNome.Text.Trim().ToString()))
            {
                MessageBox.Show("Nome do funcionário deve ser preenchido !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNome.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtCPF.Text.Trim().ToString()))
            {
                MessageBox.Show("CPF do funcionário deve ser preenchido !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCPF.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtRG.Text.Trim().ToString()))
            {
                MessageBox.Show("RG do funcionário deve ser preenchido !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRG.Focus();
                return;
            }

            if (string.IsNullOrEmpty(dtNascimento.Text.Trim().ToString()))
            {
                MessageBox.Show("Data de Nascimento deve ser preenchido !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtNascimento.Focus();
                return;
            }


            if (string.IsNullOrEmpty(txtUsuario.Text.Trim().ToString()))
            {
                MessageBox.Show("Usuário deve ser preenchido !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsuario.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtSenha.Text.Trim().ToString()))
            {
                MessageBox.Show("Senha deve ser preenchido !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSenha.Focus();
                return;
            }

            DateTime nascimento = dtNascimento.Value;
            DateTime hoje = DateTime.Now;

            TimeSpan tempoDeVida = hoje.Subtract(nascimento);
            double idade = tempoDeVida.TotalDays / 365.0;

            if (idade < 18 && chkConsentimento.Checked == false)
            {
                MessageBox.Show("Hospede é menor de idade e nessecita de consentimento dos pais para ser gerênciado !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<Hospede> hospedes = _hospedeServico.BuscarTodos();
            var h2 = hospedes.Where(h => h.Cpf == txtCPF.Text);
            if (h2.Count() != 0)
            {
                MessageBox.Show($"Este CPF já esta cadastrada no sistema !", "Atenção !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var h3 = hospedes.Where(h => h.RG == txtRG.Text);
            if (h3.Count() != 0)
            {
                MessageBox.Show($"Este RG já esta cadastrada no sistema !", "Atenção !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }



            Hospede.Nome = txtNome.Text.Trim().ToString();
            Hospede.DataNascimento = DateTime.Parse(dtNascimento.Text.ToString());
            Hospede.Cpf = txtCPF.Text.Trim().ToString();
            Hospede.RG = txtRG.Text.Trim().ToString();
            Hospede.Email = txtEmail.Text.Trim().ToString();
            Hospede.Telefone = txtTelefone.Text.Trim().ToString();
            Hospede.Celular = txtCelular.Text.Trim().ToString();
            Hospede.Consentimento = chkConsentimento.Checked;

            Hospede.Usuario.NomeUsuario = txtUsuario.Text.Trim().ToString();
            Hospede.Usuario.Senha = txtSenha.Text.Trim().ToString();
            Hospede.Usuario.TipoUsuario = "H";
            Hospede.Usuario.Status = chkAtivo.Checked;

            try
            {

                Hospede h = null;

                if (IdHospede > 0)
                {
                    h = _hospedeServico.EditarHospede(Hospede);
                } else
                {
                    h = _hospedeServico.InserirHospede(Hospede);
                }


                if ( h != null)
                {
                    MessageBox.Show($"O hospede de Id {h.IdHospede} foi gerenciado !!", "Sucesso !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AtualizarListaHospedes = true;
                    this.PreencherCampos(h);
                } else
                {
                    MessageBox.Show($"Não foi possivel gerênciar o hospede", "Atenção !", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ocorreu uma Exceção !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                
        }

        private void txtUsuario_Layout(object sender, LayoutEventArgs e)
        {

        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            
        }

        private void txtCPF_Leave(object sender, EventArgs e)
        {
            string cpf = txtCPF.Text.Replace(".", "").Replace("-", "");

            if (!string.IsNullOrEmpty(cpf.Trim()) || !string.IsNullOrWhiteSpace(cpf.Trim()))
            {
                txtUsuario.Text = cpf;
                txtSenha.Text = cpf;
            }
        }
    }
}
