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
    public partial class SplashScreen : Form
    {

        public FrmPrincipal principal;

        public SplashScreen()
        {
            InitializeComponent();
        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {



        }

        private void tmrLoading_Tick(object sender, EventArgs e)
        {

            if (this.Opacity < 1)
            {
                this.Opacity += 0.1;
            } else
            {
                tmrLoading.Enabled = false;
                tmrClose.Enabled = true;
            }


        }

        private void tmrClose_Tick(object sender, EventArgs e)
        {

            this.Close();

        }
    }
}
