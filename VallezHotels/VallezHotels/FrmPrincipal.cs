using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace VallezHotels
{
    public partial class FrmPrincipal : Form
    {

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
           int nLeftRect,
           int nTopRect,
           int nRightRect,
           int nBottomRect,
           int nWidthEllipse,
           int nHeightEllipse
       );

        public FrmPrincipal()
        {

            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));

            this.TopLevel = false;
            this.Visible = false;
            SplashScreen splash = new SplashScreen();
            splash.principal = this;
            splash.ShowDialog();
            
            FrmLogin login = new FrmLogin();
            login.principal = this;
            login.Show();

        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_MouseHover(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
