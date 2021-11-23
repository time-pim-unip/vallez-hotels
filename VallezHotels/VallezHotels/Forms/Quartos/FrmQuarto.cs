using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

using VallezHotels.Source.Entidades;
using VallezHotels.Source.Servicos;


namespace VallezHotels
{
    public partial class FrmQuarto : Form
    {

        private readonly TipoQuartoServico _tipoQuartoServico;
        private readonly QuartoServico _quartoServico;
        private readonly DisponibilidadeServico _disponibilidadeServico;
        private Quarto Quarto;
        public bool AtualizarListaQuartos;
        private bool InserirDisponibilidades;
        public int IdQuarto;

        public FrmQuarto()
        {
            _quartoServico = new QuartoServico();
            _tipoQuartoServico = new TipoQuartoServico();
            _disponibilidadeServico = new DisponibilidadeServico();
            Quarto = new Quarto();
            InserirDisponibilidades = false;
            InitializeComponent();
        }

        private void PreencherCampos(Quarto q)
        {
            txtCodigo.Text = q.Id.ToString();
            txtBloco.Text = q.Bloco.ToString();
            txtNumero.Text = q.Numero.ToString();
            cbTipoQuarto.SelectedItem = q.TipoQuarto.Descricao.ToString();
            txtValorDiaria.Text = q.ValorDiaria.ToString("F2");
            txtCamas.Text = q.QuantidadeCamas.ToString();
            txtBanheiros.Text = q.QuantidadeBanheiros.ToString();
            txtDescricaoQuarto.Text = q.Descricao.ToString();

            var disponibilidadesView = from d in q.Disponibilidades
                        orderby d.Data
                        select new
                        {
                            Id = d.Id,
                            Data = d.Data.ToString("dd/MM/yyyy"),
                            Disponivel = bool.Parse(d.Disponivel.ToString())
                        };

            dgDatas.DataSource = disponibilidadesView.ToList();

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmQuarto_Load(object sender, EventArgs e)
        {

            txtDataInicial.Value = DateTime.Now;
            txtDataFinal.Value = DateTime.Now;

            List<TipoQuarto> tipoQuartos = _tipoQuartoServico.BuscarTodos();
            txtDataInicial.Value = DateTime.Now;
            txtDataFinal.Value = DateTime.Now;
            

            foreach (TipoQuarto tq in tipoQuartos)
            {
                cbTipoQuarto.Items.Add(tq.Descricao);
            }

            if (IdQuarto > 0)
            {
                Quarto = _quartoServico.BuscarPeloId(IdQuarto);
                PreencherCampos(Quarto);
            }

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtBloco.Text.Trim().ToUpper().ToString()))
            {
                MessageBox.Show("O campo Bloco precisa ser preenchido !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(txtNumero.Text.Trim().ToUpper().ToString()))
            {
                MessageBox.Show("O campo Numero precisa ser preenchido !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbTipoQuarto.SelectedIndex < 0)
            {
                MessageBox.Show("O campo Tipo Quarto precisa ser selecionado !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(txtValorDiaria.Text.Trim().ToUpper().ToString()))
            {
                MessageBox.Show("O campo Valor Diaria precisa ser preenchido !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(txtCamas.Text.Trim().ToUpper().ToString()))
            {
                MessageBox.Show("O campo Quantidade Camas precisa ser preenchido !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(txtBanheiros.Text.Trim().ToUpper().ToString()))
            {
                MessageBox.Show("O campo Quantidade Banheiros precisa ser preenchido !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Quarto.Bloco = txtBloco.Text.Trim().ToUpper().ToString();
            Quarto.Numero = int.Parse(txtNumero.Text.Trim().ToString());
            Quarto.TipoQuarto =  _tipoQuartoServico.BuscarPeloNome(cbTipoQuarto.SelectedItem.ToString().Trim());
            Quarto.ValorDiaria = double.Parse(txtValorDiaria.Text.Trim().ToString());
            Quarto.QuantidadeCamas = int.Parse(txtCamas.Text.Trim().ToString());
            Quarto.QuantidadeBanheiros = int.Parse(txtBanheiros.Text.Trim().ToString());
            Quarto.Descricao = txtDescricaoQuarto.Text.ToString();

            if (InserirDisponibilidades)
            {

                Quarto.Disponibilidades.Clear();

                for (int i = 0; i < dgDatas.Rows.Count; i++)
                {
                    if (int.Parse(dgDatas.Rows[i].Cells["Id"].Value.ToString()) == 0)
                    {
                        Quarto.Disponibilidades.Add(new Disponibilidade()
                        {
                            Data = DateTime.Parse(dgDatas.Rows[i].Cells["Data"].Value.ToString()),
                            Disponivel = bool.Parse(dgDatas.Rows[i].Cells["Disponivel"].Value.ToString())
                        });
                    }
                }
            }

            try
            {
                Quarto q = null;

                if ( IdQuarto > 0)
                {
                    q = _quartoServico.EditarQuarto(Quarto);

                } else
                {
                    q = _quartoServico.InserirQuarto(Quarto);
                }

                q.Disponibilidades = Quarto.Disponibilidades;

                if (q.Disponibilidades.Count > 0 && InserirDisponibilidades)
                {

                    _disponibilidadeServico.InserirRangePeloQuarto(q);

                }

                q.Disponibilidades = _disponibilidadeServico.BuscarPeloQuarto(q);

                if ( q !=  null)
                {
                    MessageBox.Show("Quarto gerênciado com sucesso !", "Sucesso !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.AtualizarListaQuartos = true;
                    this.PreencherCampos(q);
                } else
                {
                    MessageBox.Show("Não foi possivel gerênciar o quarto !", "Atenção !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ocorreu uma exceção");
            }
            finally
            {
                InserirDisponibilidades = false;
            }

        }

        private void btnAdicionarDisponibilidade_Click(object sender, EventArgs e)
        {
            InserirDisponibilidades = true;
            List<Object> disponibilidades = new List<Object>();

            int totalDiasPeriodo = int.Parse(Math.Ceiling(txtDataFinal.Value.Subtract(txtDataInicial.Value).TotalDays).ToString());

            for (int i = 0; i <= totalDiasPeriodo; i++)
            {
                var data = Quarto.Disponibilidades.Where(x => x.Data == txtDataInicial.Value.AddDays(i));

                if (data.Count() == 0)
                {

                    disponibilidades.Add(new { Id = 0, Data = txtDataInicial.Value.AddDays(i), Disponivel = chkDisponiveis.Checked });
                }
            }

            if (disponibilidades.Count > 0)
            {
                dgDatas.DataSource = disponibilidades;
            }
            
        }

        private void txtBloco_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtBloco.Text))
            {
                int proximoNumero = _quartoServico.BuscarProximoNumeroDisponivelPeloBloco(txtBloco.Text);

                txtNumero.Text = proximoNumero.ToString();

            }else
            {
                txtNumero.Text = "";
            }
        }

        private void txtBloco_Leave(object sender, EventArgs e)
        {
            
        }
    }
}
