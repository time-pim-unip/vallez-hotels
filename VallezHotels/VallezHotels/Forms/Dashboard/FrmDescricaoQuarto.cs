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
using VallezHotels.Source.Entidades;
using VallezHotels.Source.Servicos;

namespace VallezHotels
{
    public partial class FrmDescricaoQuarto : Form
    {
        public Quarto Quarto;
        public bool Disponivel;



        public FrmDescricaoQuarto()
        {
            this.Quarto = new Quarto();
            Disponivel = false;
            InitializeComponent();
        }

        private void FrmDescricaoQuarto_Load(object sender, EventArgs e)
        {
            lblBloco.Text = $"Bloco: {this.Quarto.Bloco}";
            lblNumQuarto.Text = $"Quarto: {this.Quarto.Numero}";
            lblTipoQuarto.Text = this.Quarto.TipoQuarto.Descricao;
            var disponibilidade = this.Quarto.Disponibilidades.Where(x => x.Data.Date.ToString() == DateTime.Now.Date.ToString());
            Disponibilidade d = null;

            if (disponibilidade.Count() == 0)
            {
                d = new Disponibilidade();
            } else
            {
                d = disponibilidade.FirstOrDefault();
            }

            Disponivel = d.Disponivel;

            lblSituacao.Text = (d.Disponivel) ? "Disponivel" : "Não disponivel";
            this.Cursor = Cursors.Hand ;


            
            switch (d.Disponivel)
            {
                case true:
                    this.BackColor = Color.FromArgb(0, 173, 181);
                    break;
                case false:
                    this.BackColor = Color.FromArgb(251, 54, 64);
                    break;
                /*
                case 3:
                    this.BackColor = Color.FromArgb(255, 131, 3);
                    break;
                case 4:
                    this.BackColor = Color.FromArgb(235, 188, 61);
                    break;
                */
            }


        }

        private void FrmDescricaoQuarto_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
        }

        private void FrmDescricaoQuarto_MouseClick(object sender, MouseEventArgs e)
        {
            if (!Disponivel)
            {
                //MessageBox.Show("O quarto não esta disponivel para locação !", "Atenção !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //return;
            } else
            {
                
            }

            FrmLocacao locacao = new FrmLocacao();
            locacao.Quarto = Quarto;
            Helper.StartForm(locacao, null);
        }
    }
}
