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
        private readonly LocacaoServico _locacaoServico;
        private readonly HospedagemServico _hospedagemServico;

        public FrmDashboard()
        {
            _quartoServico = new QuartoServico();
            _locacaoServico = new LocacaoServico();
            _hospedagemServico = new HospedagemServico();

            InitializeComponent();
        }

        private void AtualizarDashboard()
        {
            List<Quarto> quartos = _quartoServico.BuscarTodos();
            List<Locacao> locacoes = new List<Locacao>();

            foreach (Quarto q in quartos)
            {
                Locacao l = _locacaoServico.BuscarPelaDataEQuarto(q);
                l.Hospedagems = _hospedagemServico.BuscarPelaLocacao(l);

                locacoes.Add(l);
            }


            pnlExibicaoQuartos.Controls.Clear();

            int quantidadeQuartosDisponiveis = quartos.Where(q => q.Disponibilidades.Where(d => d.Data.Date == DateTime.Now.Date && d.Disponivel == true).Count() != 0).Count();
            lblQuartosDisponiveis.Text = $"Quartos disponiveis: {quantidadeQuartosDisponiveis}";

            int quantidadeQuartosNaoDisponiveis = quartos.Where(q => q.Disponibilidades.Where(d => d.Data.Date == DateTime.Now.Date && d.Disponivel == false).Count() != 0).Count();
            lblQuartosNãoDisponiveis.Text = $"Quartos não disponiveis: {quantidadeQuartosNaoDisponiveis}";

            int quantidadeQuartosOcupados = locacoes.Where(l => l.Hospedagems.Count > 0).Count();
            lblQuartosOcupados.Text = $"Quartos ocupados: {quantidadeQuartosOcupados}";

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
