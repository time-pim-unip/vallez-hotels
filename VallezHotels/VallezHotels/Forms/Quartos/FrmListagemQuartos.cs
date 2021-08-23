using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using VallezHotels.Source.Entidades;
using VallezHotels.Source.Servicos;

namespace VallezHotels
{
    public partial class FrmListagemQuartos : Form
    {

        private readonly QuartoServico _quartoServico;

        public FrmListagemQuartos()
        {
            _quartoServico = new QuartoServico();

            InitializeComponent();
        }

        private void FrmListagemQuartos_Load(object sender, EventArgs e)
        {
            this.AtualizarListaQuartos();
        }

        public void AtualizarListaQuartos()
        {

            List<Quarto> quartos = _quartoServico.BuscarTodos();
            var quartosView = from q in quartos
                              where q.Bloco.ToUpper().Contains(txtPesquisaBloco.Text.ToUpper().Trim()) && q.Numero.ToString().Contains(txtPesquisaNumero.Text.ToUpper().Trim())
                              select new
                              {
                                  Id = q.Id,
                                  Bloco = q.Bloco,
                                  Numero = q.Numero.ToString()
                              };

            dgQuartos.DataSource = quartosView.ToList();

        }

        private void btnNovoQuarto_Click(object sender, EventArgs e)
        {
            FrmQuarto quarto = new FrmQuarto();
            quarto.ShowDialog();

            if (quarto.AtualizarListaQuartos)
            {
                this.AtualizarListaQuartos();
            }


        }

        private void dgQuartos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FrmQuarto quarto = new FrmQuarto();
            quarto.IdQuarto = int.Parse(dgQuartos.Rows[e.RowIndex].Cells["Id"].Value.ToString());
            quarto.ShowDialog();

            if (quarto.AtualizarListaQuartos)
            {
                this.AtualizarListaQuartos();
            }
        }

        private void txtPesquisaBloco_TextChanged(object sender, EventArgs e)
        {
            this.AtualizarListaQuartos();
        }

        private void txtPesquisaNumero_TextChanged(object sender, EventArgs e)
        {
            this.AtualizarListaQuartos();
        }
    }
}
