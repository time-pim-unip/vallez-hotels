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

        public bool AtualizarFuncionarios;
        private readonly FuncionarioServico _funcionarioServico;

        public FrmFuncionario()
        {
            _funcionarioServico = new FuncionarioServico();
            AtualizarFuncionarios = false;

            InitializeComponent();
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


            Funcionario funcionario = new Funcionario()
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

            funcionario.Usuario = new Usuario()
            {
                NomeUsuario = txtUsuario.Text.Trim().ToString(),
                Senha = txtSenha.Text.Trim().ToString(),
                TipoUsuario = c.ToString(),
                Status = chkAtivo.Checked
            };

            try
            {

                Funcionario f = _funcionarioServico.InserirFuncionario(funcionario);

                if (f != null)
                {
                    MessageBox.Show($"Usuário cadastrado com o Id {f.IdFuncionario.ToString()} !", "Sucesso !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AtualizarFuncionarios = true;
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
