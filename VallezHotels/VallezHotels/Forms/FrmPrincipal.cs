using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VallezHotels.Source.Core;

namespace VallezHotels
{
    public partial class FrmPrincipal : Form
    {

        public bool UsuarioValido;

        public FrmPrincipal()
        {
            InitializeComponent();

            this.UsuarioValido = false;

            /*
               Código obtido no Stack Overlow para impedir que a imagem de fundo fique tremida(flicker)
               https://stackoverflow.com/questions/1316310/mdi-parent-background-image
            */
            // as this code occurs in the Form's "Initialize()" function, any references to
            // "this." are to the Form instance itself (not the MDI control!)

            if (this.Controls.Count > 0)
            {
                MdiClient client = this.Controls.OfType<MdiClient>().First();
                client.BackgroundImageLayout = this.BackgroundImageLayout;
                client.Paint += (s, e) =>
                    e.Graphics.DrawImage(this.BackgroundImage, (s as MdiClient).ClientRectangle);

                //Set this to repaint when the size is changed
                typeof(Control).GetProperty(
                    "ResizeRedraw",
                    System.Reflection.BindingFlags.NonPublic |
                    System.Reflection.BindingFlags.Instance
                ).SetValue(client, true, null);

                //set this to prevent flicker
                typeof(Control).GetProperty(
                    "DoubleBuffered",
                    System.Reflection.BindingFlags.NonPublic |
                    System.Reflection.BindingFlags.Instance
                ).SetValue(client, true, null);
            }

            // Carregar a splash screen e o formulário de login antes do sistema iniciar.
            this.Opacity = 0;

            SplashScreen splash = new SplashScreen();
            splash.principal = this;
            splash.ShowDialog();

            FrmLogin login = new FrmLogin();
            login.ShowDialog();
            this.UsuarioValido = login.UsuarioValido;

            if (this.UsuarioValido)
            {
                this.Opacity = 1;
            }

        }

        private void hospedesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

        }

        private void FrmPrincipal_Resize(object sender, EventArgs e)
        {
            //this.BackgroundImage = Properties.Resources.backgroud; 
        }

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDashboard dash = new FrmDashboard();
            Helper.StartForm(dash, this);
        }

        private void hospedeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmListagemHospedes listagemHospedes = new FrmListagemHospedes();
            Helper.StartForm(listagemHospedes, this);
        }

        private void funcionárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmListagemFuncionarios listagemFuncionarios = new FrmListagemFuncionarios();
            Helper.StartForm(listagemFuncionarios, this);

        }

        private void quartoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmListagemQuartos quartos = new FrmListagemQuartos();
            Helper.StartForm(quartos, this);
        }

        private void tipoQuartoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmListagemTipoQuarto tipoQuarto = new FrmListagemTipoQuarto();
            Helper.StartForm(tipoQuarto, this);
        }

        private void serviçsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //FrmServicos servicos = new FrmServicos();
            FrmListagemServicos servicos = new FrmListagemServicos();
            Helper.StartForm(servicos, this);
        }

        private void locaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLocacao locacao = new FrmLocacao();
            Helper.StartForm(locacao, this);
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            
            if (!this.UsuarioValido)
            {
                Application.Exit();
            }
            

            // Ativar a dashboard como formulário padrão
            //FrmDashboard dashboard = new FrmDashboard();
            //Helper.StartForm(dashboard, this);
        }
    }
}
