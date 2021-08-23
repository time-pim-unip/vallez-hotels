using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using VallezHotels.Source.Servicos;
using VallezHotels.Source.Entidades;

namespace VallezHotels
{
    public partial class FrmListagemServicos : Form
    {

        private readonly ServicoServico _adcionaisServico;

        public FrmListagemServicos()
        {
            _adcionaisServico = new ServicoServico();
            InitializeComponent();
        }

        private void FrmListagemServicos_Load(object sender, EventArgs e)
        {
            this.AtualizarListaServicos();
        }

        private void AtualizarListaServicos()
        {

            List<Servico> servicos = _adcionaisServico.BuscarTodos();

            var servicosView = from s in servicos
                               where s.Descricao.ToUpper().Contains(txtPesquisaNome.Text.Trim().ToUpper().ToString())
                               orderby s.Descricao
                               select new
                               {
                                   Id = s.Id,
                                   Nome = s.Descricao,
                                   Valor = "R$ " + s.Valor.ToString("F2")
                               };

            dgServicos.DataSource = servicosView.ToList();
        }

        private void btnNovoServico_Click(object sender, EventArgs e)
        {
            FrmServicos frmServico = new FrmServicos();
            frmServico.ShowDialog();

            if (frmServico.AtualizarLista)
            {
                this.AtualizarListaServicos();
            }
        }

        private void dgServicos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FrmServicos frmServico = new FrmServicos();
            frmServico.IdServico = int.Parse(dgServicos.Rows[e.RowIndex].Cells["Id"].Value.ToString());
            frmServico.ShowDialog();

            if (frmServico.AtualizarLista)
            {
                this.AtualizarListaServicos();
            }
        }
    }
}
