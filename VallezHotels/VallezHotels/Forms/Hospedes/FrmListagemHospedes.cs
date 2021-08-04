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
using VallezHotels.Source.Servicos;
using VallezHotels.Source.Entidades;
using VallezHotels.Source.Enums;

namespace VallezHotels
{
    public partial class FrmListagemHospedes : Form
    {

        private readonly HospedeServico _hospedeServico;

        public FrmListagemHospedes()
        {

            _hospedeServico = new HospedeServico();

            InitializeComponent();
        }

        private void FrmListagemHospedes_Load(object sender, EventArgs e)
        {
            this.AtualizarListaHospedes();
        }

        private void AtualizarListaHospedes()
        {
            List<Hospede> hospedes = _hospedeServico.BuscarTodos();

            var hospedesView = from h in hospedes
                               where (h.Usuario.Status == chkSomenteAtivos.Checked || false == chkSomenteAtivos.Checked)
                                    && h.Nome.ToUpper().Contains(txtPesquisaNome.Text.Trim().ToUpper().ToString())
                               orderby h.Nome
                               select new
                               {
                                   Id = h.IdHospede,
                                   Nome = h.Nome,
                                   Cpf = h.Cpf,
                                   Rg = h.RG,
                                   Telefone = h.Telefone,
                                   Celular = h.Celular,
                                   Email = h.Email,
                               };

            dsHospedes.DataSource = hospedesView.ToList();

        }

        private void btnNovoHospede_Click(object sender, EventArgs e)
        {

            FrmHospede hospede = new FrmHospede();
            Helper.StartForm(hospede, null);

            if (hospede.AtualizarListaHospedes)
            {
                this.AtualizarListaHospedes();
            }
        }

        private void dsHospedes_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FrmHospede hospede = new FrmHospede();
            hospede.IdHospede = int.Parse(dsHospedes.Rows[e.RowIndex].Cells["Id"].Value.ToString());
            Helper.StartForm(hospede, null);

            if (hospede.AtualizarListaHospedes)
            {
                this.AtualizarListaHospedes();
            }
        }

        private void chkSomenteAtivos_CheckedChanged(object sender, EventArgs e)
        {
            this.AtualizarListaHospedes();
        }

        private void txtPesquisaNome_TextChanged(object sender, EventArgs e)
        {
            this.AtualizarListaHospedes();
        }
    }
}
