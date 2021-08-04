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
    public partial class FrmListagemTipoQuarto : Form
    {

        private readonly TipoQuartoServico _tipoQuartoServico;

        public FrmListagemTipoQuarto()
        {
            _tipoQuartoServico = new TipoQuartoServico();

            InitializeComponent();
        }

        private void FrmListagemTipoQuarto_Load(object sender, EventArgs e)
        {
            this.AtualizarLista();
        }

        private void AtualizarLista()
        {
            List<TipoQuarto> tipoQuartos = _tipoQuartoServico.BuscarTodos();

            var tipoQuartosView = from t in tipoQuartos
                                  where t.Descricao.ToUpper().Contains(txtPesquisa.Text.ToUpper().Trim().ToString())
                                  orderby t.Id
                                  select new
                                  {
                                      Id = t.Id,
                                      Descricao = t.Descricao
                                  };

            dgTiposQuarto.DataSource = tipoQuartosView.ToList();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnNovoTipo_Click(object sender, EventArgs e)
        {
            FrmTipoQuarto frmTipoQuarto = new FrmTipoQuarto();
            frmTipoQuarto.ShowDialog();

            if (frmTipoQuarto.AtualizarLista)
            {
                this.AtualizarLista();
            }
        }

        private void dgTiposQuarto_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FrmTipoQuarto frmTipoQuarto = new FrmTipoQuarto();
            frmTipoQuarto.IdTipoQuarto = int.Parse(dgTiposQuarto.Rows[e.RowIndex].Cells["Id"].Value.ToString());
            frmTipoQuarto.ShowDialog();

            if (frmTipoQuarto.AtualizarLista)
            {
                this.AtualizarLista();
            }
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            this.AtualizarLista();
        }
    }
}
