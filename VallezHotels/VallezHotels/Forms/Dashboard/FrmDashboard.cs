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
    public partial class FrmDashboard : Form
    {

        private readonly QuartoServico _quartoServico;

        public FrmDashboard()
        {
            _quartoServico = new QuartoServico();

            InitializeComponent();
        }

        private void AtualizarDashboard()
        {
            List<Quarto> quartos = _quartoServico.BuscarTodos();
            pnlExibicaoQuartos.Controls.Clear();

            var listQuartos = from q in quartos
                              orderby q.Bloco, q.Numero
                              select q;

            foreach (Quarto quarto in listQuartos)
            {
                FrmDescricaoQuarto q = new FrmDescricaoQuarto();
                q.Quarto = quarto;
                q.TopLevel = false;
                q.Parent = this;
                q.Visible = true;
                pnlExibicaoQuartos.Controls.Add(q);
            }
        }

        private void FrmDashboard_Load(object sender, EventArgs e)
        {

            AtualizarDashboard();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tmrBuscarQuartos_Tick(object sender, EventArgs e)
        {
            if (this.ContainsFocus)
            {
                AtualizarDashboard();
            }
        }
    }
}
