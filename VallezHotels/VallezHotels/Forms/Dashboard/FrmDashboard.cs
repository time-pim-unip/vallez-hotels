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
    public partial class FrmDashboard : Form
    {
        public FrmDashboard()
        {
            InitializeComponent();
        }

        private void FrmDashboard_Load(object sender, EventArgs e)
        {

            // STATUS EXEMPLOS VISUAIS
            // 1 - Disponivel, 2 - Agendado, 3 - Ocupado, 4 - Não Disponivel


            FrmDescricaoQuarto quarto1 = new FrmDescricaoQuarto();
            quarto1.NumeroQuarto = 101;
            quarto1.StatusQuarto = 1;
            quarto1.TopLevel = false;
            quarto1.Parent = this;
            quarto1.Visible = true;
            pnlExibicaoQuartos.Controls.Add(quarto1);


            FrmDescricaoQuarto quarto2 = new FrmDescricaoQuarto();
            quarto2.NumeroQuarto = 102;
            quarto2.StatusQuarto = 4;
            quarto2.TopLevel = false;
            quarto2.Parent = this;
            quarto2.Visible = true;
            pnlExibicaoQuartos.Controls.Add(quarto2);

            FrmDescricaoQuarto quarto3 = new FrmDescricaoQuarto();
            quarto3.NumeroQuarto = 103;
            quarto3.StatusQuarto = 1;
            quarto3.TopLevel = false;
            quarto3.Parent = this;
            quarto3.Visible = true;
            pnlExibicaoQuartos.Controls.Add(quarto3);

            FrmDescricaoQuarto quarto4 = new FrmDescricaoQuarto();
            quarto4.NumeroQuarto = 104;
            quarto4.StatusQuarto = 2;
            quarto4.TopLevel = false;
            quarto4.Parent = this;
            quarto4.Visible = true;
            pnlExibicaoQuartos.Controls.Add(quarto4);

            FrmDescricaoQuarto quarto5 = new FrmDescricaoQuarto();
            quarto5.NumeroQuarto = 105;
            quarto5.StatusQuarto = 3;
            quarto5.TopLevel = false;
            quarto5.Parent = this;
            quarto5.Visible = true;
            pnlExibicaoQuartos.Controls.Add(quarto5);

            /*
            for (int i = 1; i <= 5; i++)
            {
                FrmDescricaoQuarto quarto = new FrmDescricaoQuarto();
                quarto.NumeroQuarto = i;
                quarto.TopLevel = false;
                quarto.Parent = this;
                quarto.Visible = true;
                pnlExibicaoQuartos.Controls.Add(quarto);
            }
            */





        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
