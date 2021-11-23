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
    public partial class FrmLogin : Form
    {
        public Boolean UsuarioValido;

        private readonly UsuarioServico _usuarioServico;

        public FrmLogin()
        {
            this._usuarioServico = new UsuarioServico();

            InitializeComponent();

            //this.UsuarioValido = false;
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
        
        }

        private void btnSair_Click(object sender, EventArgs e)
        {

            this.UsuarioValido = false;
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            try
            {
                string usuario = txtUsuario.Text.ToString().Trim();
                string senha = txtSenha.Text.ToString().Trim();

                Usuario u = _usuarioServico.BuscarUsuarioESenha(usuario, senha);

                if (u == null)
                {
                    MessageBox.Show("Usuário ou senha não encontrados !");
                }
                else
                {
                    this.UsuarioValido = true;
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro !", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void FrmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!this.UsuarioValido)
            {
                this.UsuarioValido = false;
            }
        }
    }
}
