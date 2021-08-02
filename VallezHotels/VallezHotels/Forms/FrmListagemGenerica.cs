using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using VallezHotels.Source.DTO;

namespace VallezHotels
{
    public partial class FrmListagemGenerica : Form
    {
        public List<ListagemGenericaDTO> Lista;
        public int CodigoSelecionado;

        public FrmListagemGenerica()
        {
            InitializeComponent();
        }

        private void FrmListagemGenerica_Load(object sender, EventArgs e)
        {
            dgListagem.DataSource = Lista;
        }

        private void txtDescricao_TextChanged(object sender, EventArgs e)
        {
            var listagem = from l in Lista
                           where l.Descricao.ToUpper().Contains(txtDescricao.Text.Trim().ToUpper().ToString())
                           select l;

            dgListagem.DataSource = listagem.ToList();

        }

        private void dgListagem_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.CodigoSelecionado = int.Parse(dgListagem.Rows[e.RowIndex].Cells["Codigo"].Value.ToString());

            this.Close();
        }
    }
}
