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
    public partial class FrmDescricaoQuarto : Form
    {

        public int NumeroQuarto;
        public int StatusQuarto;

        public FrmDescricaoQuarto()
        {
            InitializeComponent();
        }

        private void FrmDescricaoQuarto_Load(object sender, EventArgs e)
        {
            lblNumQuarto.Text = $"Quarto: {this.NumeroQuarto}";
            this.Cursor = Cursors.Hand ;

            switch (StatusQuarto)
            {
                case 1:
                    this.BackColor = Color.FromArgb(0, 173, 181);
                    break;
                case 2:
                    this.BackColor = Color.FromArgb(235, 188, 61);
                    break;
                case 3:
                    this.BackColor = Color.FromArgb(255, 131, 3);
                    break;
                case 4:
                    this.BackColor = Color.FromArgb(251, 54, 64);
                    break;
            }


        }

        private void FrmDescricaoQuarto_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
        }

        private void FrmDescricaoQuarto_MouseClick(object sender, MouseEventArgs e)
        {
            FrmLocacao locacao = new FrmLocacao();
            Helper.StartForm(locacao, null);
        }
    }
}
