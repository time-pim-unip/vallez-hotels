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

        private FormsActivator _fa;

        public FrmPrincipal()
        {

            InitializeComponent();
           
            // Carregar a splash screen e o formulário de login antes do sistema iniciar.
            /*
            this.TopLevel = false;
            this.Visible = false;

            SplashScreen splash = new SplashScreen();
            splash.principal = this;
            splash.ShowDialog();
            
            FrmLogin login = new FrmLogin();
            login.principal = this;
            login.Show();
            */

            // Ativar a dashboard como formulário padrão
            this._fa = new FormsActivator(pnlMain, lblFormTitle);
            Form dashboard = (Form)new FrmDashboard();
            this._fa.AtivarForm(dashboard);

        }

        private void btnShowQuartos_Click(object sender, EventArgs e)
        {
            FrmQuarto quarto = new FrmQuarto();
            this._fa.AtivarForm(quarto);
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            FrmDashboard dashboard = new FrmDashboard();
            this._fa.AtivarForm(dashboard);
        }

        private void btnShowHospedes_Click(object sender, EventArgs e)
        {
            FrmHospede hospede = new FrmHospede();
            this._fa.AtivarForm(hospede);
        }
    }
}
