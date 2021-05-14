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

        public FrmPrincipal()
        {

            InitializeComponent();

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
            //this.Visible = false;
            //this.Hide();

            //SplashScreen splash = new SplashScreen();
            //splash.principal = this;
            //splash.ShowDialog();
            
            //FrmLogin login = new FrmLogin();
            //login.principal = this;
            //login.ShowDialog();

            // Ativar a dashboard como formulário padrão
            //this._fa = new FormsActivator(pnlMain, lblFormTitle);
            //Form dashboard = (Form)new FrmDashboard();
            //this._fa.AtivarForm(dashboard);


           

            

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
            FrmQuarto quarto = new FrmQuarto();
            Helper.StartForm(quarto, this);
        }
    }
}
