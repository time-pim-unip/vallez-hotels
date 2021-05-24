using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VallezHotels
{
    public partial class FrmLogin : Form
    {

        public FrmPrincipal principal;
        public Boolean UsuarioValido;

        public FrmLogin()
        {
            InitializeComponent();
            this.UsuarioValido = false;
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            this.UsuarioValido = true;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.principal.Show();
            this.Close();
            
            //this.principal.TopLevel = true;
            //this.principal.Visible = true;
            //this.principal.Location = new Point(this.ClientSize.Width * 2, this.ClientSize.Height);
        }

        private void FrmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!this.UsuarioValido)
            {
                Application.Exit();
            } else
            {
                this.Close();
            }
        }
    }
}
