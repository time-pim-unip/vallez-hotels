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
    public partial class FrmFuncionario : Form
    {

        private readonly FuncionarioServico _funcionarioServico;
        public bool AtualizarFuncionarios;
        public int IdFuncionario;
        private Funcionario Funcionario;

        public FrmFuncionario()
        {
            _funcionarioServico = new FuncionarioServico();
            AtualizarFuncionarios = false;
            Funcionario = new Funcionario();
            
            InitializeComponent();
        }

        private void PreencherFormularios(Funcionario f)
        {
            txtCodigo.Text = f.IdFuncionario.ToString();
            txtNome.Text = f.Nome.ToString();
            txtCPF.Text = f.Cpf.ToString();
            txtRG.Text = f.RG.ToString();
            dtNascimento.Value = f.DataNascimento;
            dtAdmissao.Value = f.Admissao;
            txtCtps.Text = f.CTPS.ToString();
            txtTelefone.Text = f.Telefone.ToString();
            txtCelular.Text = f.Celular.ToString();
            txtEmail.Text = f.Email.ToString();
            txtUsuario.Text = f.Usuario.NomeUsuario.ToString();
            txtSenha.Text = f.Usuario.Senha.ToString();
            chkAtivo.Checked = bool.Parse(f.Usuario.Status.ToString());

            char c = char.Parse(f.Usuario.TipoUsuario.ToString());
            TipoUsuario tipoUsuario = (TipoUsuario)c;

            cbTipoUsuario.SelectedItem = tipoUsuario.ToString();
        }


        private void FrmFuncionario_Load(object sender, EventArgs e)
        {

            if (IdFuncionario > 0)
            {
                Funcionario = _funcionarioServico.BuscarPeloId(IdFuncionario);
                PreencherFormularios(Funcionario);
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
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

            if (string.IsNullOrEmpty(dtAdmissao.Text.Trim().ToString()))
            {
                MessageBox.Show("Data de Admissão deve ser preenchido !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtAdmissao.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtCtps.Text.Trim().ToString()))
            {
                MessageBox.Show("Carteira de Trabalho deve ser preenchido !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCtps.Focus();
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



            /*
            Funcionario = new Funcionario()
            {
                Nome = txtNome.Text.Trim().ToString(),
                DataNascimento = DateTime.Parse(dtNascimento.Text.ToString()),
                Cpf = txtCPF.Text.Trim().ToString(),
                RG = txtRG.Text.Trim().ToString(),
                Email = txtEmail.Text.Trim().ToString(),
                Telefone = txtTelefone.Text.Trim().ToString(),
                Celular = txtCelular.Text.Trim().ToString(),
                CTPS = txtCtps.Text.Trim().ToString(),
                Admissao = DateTime.Parse(dtAdmissao.Text.ToString())
            };

            TipoUsuario tipoUsuario = (TipoUsuario)Enum.Parse(typeof(TipoUsuario), cbTipoUsuario.SelectedItem.ToString());
            char c = (char)tipoUsuario;

            Funcionario.Usuario = new Usuario()
            {
                NomeUsuario = txtUsuario.Text.Trim().ToString(),
                Senha = txtSenha.Text.Trim().ToString(),
                TipoUsuario = c.ToString(),
                Status = chkAtivo.Checked
            };
            */

            Funcionario.Nome = txtNome.Text.Trim().ToString();
            Funcionario.DataNascimento = DateTime.Parse(dtNascimento.Text.ToString());
            Funcionario.Cpf = txtCPF.Text.Trim().ToString();
            Funcionario.RG = txtRG.Text.Trim().ToString();
            Funcionario.Email = txtEmail.Text.Trim().ToString();
            Funcionario.Telefone = txtTelefone.Text.Trim().ToString();
            Funcionario.Celular = txtCelular.Text.Trim().ToString();
            Funcionario.CTPS = txtCtps.Text.Trim().ToString();
            Funcionario.Admissao = DateTime.Parse(dtAdmissao.Text.ToString());

            TipoUsuario tipoUsuario = (TipoUsuario)Enum.Parse(typeof(TipoUsuario), cbTipoUsuario.SelectedItem.ToString());
            char c = (char)tipoUsuario;

            Funcionario.Usuario.NomeUsuario = txtUsuario.Text.Trim().ToString();
            Funcionario.Usuario.Senha = txtSenha.Text.Trim().ToString();
            Funcionario.Usuario.TipoUsuario = c.ToString();
            Funcionario.Usuario.Status = chkAtivo.Checked;

            try
            {

                Funcionario f = null;

                if (IdFuncionario > 0)
                {
                    f = _funcionarioServico.EditarFuncionario(Funcionario);
                } else
                {
                    f = _funcionarioServico.InserirFuncionario(Funcionario);
                }

                if (f != null)
                {
                    MessageBox.Show($"Usuário com Id {f.IdFuncionario.ToString()} gerenciadoc com sucesso ! !", "Sucesso !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AtualizarFuncionarios = true;
                    PreencherFormularios(f);
                } else
                {
                    MessageBox.Show($"Um erro ocorreu ao tentar cadastrar o Funcionario !", "Atenção !", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ocorreu uma Exceção !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            

        }

    }
}
