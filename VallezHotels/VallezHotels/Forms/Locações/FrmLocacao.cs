﻿using System;
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
using VallezHotels.Source.DTO;

namespace VallezHotels
{
    public partial class FrmLocacao : Form
    {

        private readonly LocacaoServico _locacaoServico;
        private readonly DisponibilidadeServico _disponibilidadeServico;
        private readonly HospedeServico _hospedeServico;
        private readonly HospedagemServico _hospedagemServico;
        private readonly QuartoServico _quartoServico;
        private readonly ServicoServico _servicoServico;
        private readonly ServicoSolicitadoServico _servicoSolicitadoServico;

        private bool AdicionarHospedes;
        private bool AdicionarServicos;
        private List<Object> ListaHospedagem;
        private List<Object> ListaServicos;

        private Locacao Locacao;
        private Locacao LocacaoAntiga;
        
        public Quarto Quarto;
        public Boolean AtualizarDetalhes;

        public FrmLocacao()
        {
            _locacaoServico = new LocacaoServico();
            _disponibilidadeServico = new DisponibilidadeServico();
            _hospedeServico = new HospedeServico();
            _hospedagemServico = new HospedagemServico();
            _quartoServico = new QuartoServico();
            _servicoServico = new ServicoServico();
            _servicoSolicitadoServico = new ServicoSolicitadoServico();
            AdicionarHospedes = false;
            AdicionarServicos = false;
            Quarto = new Quarto();
            Locacao = new Locacao();
            ListaHospedagem = new List<Object>();
            ListaServicos = new List<Object>();
            AtualizarDetalhes = false;

            InitializeComponent();
        }

        private void FrmLocacao_Load(object sender, EventArgs e)
        {

            dtEntrada.Value = DateTime.Now.Date;
            dtSaida.Value = DateTime.Now.Date;

            Locacao = _locacaoServico.BuscarPelaDataEQuarto(Quarto, DateTime.Now);
            Locacao.Quarto = Quarto;

            if (Locacao.Uuid != null)
            {
                    
                txtCodigo.Text = Locacao.Id.ToString();
                dtEntrada.Value = Locacao.DataEntrada;
                dtSaida.Value = Locacao.DataSaida;
                dtCheckin.Value = Locacao.CheckIn;
                dtCheckout.Value = Locacao.CheckOut;
                    
                Locacao.Hospedagems = _hospedagemServico.BuscarPelaLocacao(Locacao);
                //dgHospedes.DataSource = null;
                foreach (Hospedagem h in Locacao.Hospedagems)
                {
                    Object row = new
                    {
                        Codigo = h.Hospede.IdHospede.ToString(),
                        Nome = h.Hospede.Nome,
                        Detentor = h.Detentor
                    };

                    ListaHospedagem.Add(row);
                }
                dgHospedes.DataSource = ListaHospedagem;


                Locacao.ServicosSolicitados = _servicoSolicitadoServico.BuscarPelaLocacao(Locacao);
                foreach (ServicoSolicitado ss in Locacao.ServicosSolicitados)
                {

                    ss.Servico = _servicoServico.BuscarPeloId(ss.Servico.Id);

                    Object rowServico = new
                    {
                        Id = ss.Servico.Id,
                        Descricao = ss.Servico.Descricao,
                        ValorUnitario = ss.Servico.Valor,
                        Quantidade = ss.Quantidade,
                        ValorTotal = ss.ValorTotalServico()
                    };

                    ListaServicos.Add(rowServico);

                }
                dgServicosSolicitados.DataSource = ListaServicos;

            } else
            {
                Locacao.DataEntrada = DateTime.Now.Date;
                Locacao.DataSaida = DateTime.Now.Date;
            }

            // Exibir valor da locação
            AtualizarValorDaLocacao();

            txtQuarto.Text = Quarto.Id.ToString();
            txtBloco.Text = Quarto.Bloco;
            txtNumero.Text = Quarto.Numero.ToString();

            LocacaoAntiga = new Locacao()
            {
                DataEntrada = Locacao.DataEntrada,
                DataSaida = Locacao.DataSaida
            };

        }

        private void AtualizarValorDaLocacao()
        {
            lblValorLocacao.Text = $"R$ {Locacao.ValorDaLocacao().ToString("F2")}";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {

            // Verificar disponibilidade das datas selecionadas para locação.
            /*
            List<Disponibilidade> disponibilidades = _disponibilidadeServico.BuscarPeloQuarto(Quarto);
            List<DateTime> datasPeriodo = dtEntrada.Value.RetornarPeriodo(dtSaida.Value);

            foreach (DateTime dt in datasPeriodo)
            {
                if (disponibilidades.Where(d => d.Data.Date == dt.Date && d.Disponivel == false).Count() != 0)
                {
                    MessageBox.Show("O periodo selecionado é invalido !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning) ;
                    return;
                }

            }
            */

            // Verificar se existe um hospede ao inserir nova locação
            if (string.IsNullOrEmpty(txtCodigo.Text))
            {

                if (dgHospedes.Rows.Count == 0)
                {
                    MessageBox.Show("Pelo menos 1 hospede deve ser inserido para a locação !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

            }

            Locacao.Quarto = Quarto;
            Locacao.DataEntrada = dtEntrada.Value;
            Locacao.DataSaida = dtSaida.Value;
            Locacao.CheckIn = dtCheckin.Value;
            Locacao.CheckOut = dtCheckout.Value;


            try
            {
                Locacao l = new Locacao();
                
                if (!string.IsNullOrEmpty(txtCodigo.Text))
                {
                    _quartoServico.HabilitarDisponibilidades(Locacao.Quarto, LocacaoAntiga);
                    l = _locacaoServico.EditarLocacao(Locacao);
                } else
                {
                   l =  _locacaoServico.InserirLocacao(Locacao);
                }

                if (AdicionarHospedes)
                {
                    foreach (DataGridViewRow row in dgHospedes.Rows)
                    {

                        // Verifica se o hóspede já faz parte desta locação
                        var existe = Locacao.Hospedagems.Where(x => x.Hospede.IdHospede == int.Parse(row.Cells["Codigo"].Value.ToString()));
                        if (existe.Count() == 0)
                        {
                            Hospedagem h = new Hospedagem();
                            h.Locacao = l;
                            h.Hospede = _hospedeServico.BuscarPeloId(int.Parse(row.Cells["Codigo"].Value.ToString()));
                            h.Detentor = bool.Parse(row.Cells["Detentor"].Value.ToString());

                            h = _hospedagemServico.InserirHospedagem(h);

                        }
                    }
                }

                if (AdicionarServicos)
                {
                    foreach (DataGridViewRow row in dgServicosSolicitados.Rows)
                    {
                        var existe = Locacao.ServicosSolicitados.Where(s => s.Servico.Id == int.Parse(row.Cells["Id"].Value.ToString()));

                        if (existe.Count() == 0)
                        {
                            ServicoSolicitado ss = new ServicoSolicitado()
                            {
                                Locacao = l,
                                Servico = _servicoServico.BuscarPeloId(int.Parse(row.Cells["Id"].Value.ToString())),
                                Solicitacao = DateTime.Now,
                                Quantidade = int.Parse(row.Cells["Quantidade"].Value.ToString())

                            };

                            _servicoSolicitadoServico.InserirServicoSolicitado(ss);
                        }
                    }
                }

                if (l != null)
                {
                    MessageBox.Show("Locação gerênciada com sucesso", "Sucesso !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AtualizarDetalhes = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ocorreu uma exceção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                AdicionarHospedes = false;
                AdicionarServicos = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            FrmListagemGenerica listagem = new FrmListagemGenerica();
            List<Hospede> hospedes = _hospedeServico.BuscarTodos();

            IEnumerable<ListagemGenericaDTO> dados = from h in hospedes
                                                     orderby h.Nome
                                                      select new ListagemGenericaDTO()
                                                      {
                                                          Codigo = h.IdHospede,
                                                          Descricao = h.Nome
                                                      };

            listagem.Lista = dados.ToList();
            listagem.ShowDialog();

            if (listagem.CodigoSelecionado > 0)
            {
                Hospede h = _hospedeServico.BuscarPeloId(listagem.CodigoSelecionado);

                txtCodigoHospede.Text = h.IdHospede.ToString();
                txtNomeHospede.Text = h.Nome.ToString();

            }

        }

        private void btnAddHospede_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCodigoHospede.Text.ToString()))
            {
                MessageBox.Show("Escolha um hospede antes de adicionar", "Ateñção !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Verifica se o hóspede já faz parte desta locação
            var existe = Locacao.Hospedagems.Where(x => x.Hospede.IdHospede == int.Parse(txtCodigoHospede.Text.ToString()));
            if (existe.Count() > 0)
            {
                MessageBox.Show("Hospede já inserido", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dgHospedes.DataSource = null;
            AdicionarHospedes = true;

            Object row = new
            {
                Codigo = txtCodigoHospede.Text.ToString(),
                Nome = txtNomeHospede.Text.ToString(),
                Detentor = chkDetentor.Checked
            };

            ListaHospedagem.Add(row);
            dgHospedes.DataSource = ListaHospedagem;
        }

        private void dtSaida_ValueChanged(object sender, EventArgs e)
        {
            /*
            if (dtSaida.Value < dtEntrada.Value)
            {
                dtSaida.Value = dtEntrada.Value;
                MessageBox.Show("Data de saida não pode ser menor que a data de entrada !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (dtSaida.Value < DateTime.Now.Date)
            {
                dtEntrada.Value = DateTime.Now.Date;
                MessageBox.Show("Data de saida não pode ser menor que a data atual !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            */


            Locacao.DataSaida = dtSaida.Value;
            AtualizarValorDaLocacao();
        }

        private void dtEntrada_ValueChanged(object sender, EventArgs e)
        {
            /*
            if (dtEntrada.Value > dtSaida.Value)
            {
                dtEntrada.Value = dtSaida.Value;
                MessageBox.Show("Data de entrada não pode ser maior que a data da saida !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            } else if (dtEntrada.Value < DateTime.Now.Date)
            {
                dtEntrada.Value = DateTime.Now.Date;
                MessageBox.Show("Data de entrada não pode ser menor que a data atual !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            */
            Locacao.DataEntrada = dtEntrada.Value;
            AtualizarValorDaLocacao();
        }

        private void btnPesquisaGenericaServicosAdicionais_Click(object sender, EventArgs e)
        {

            FrmListagemGenerica listagem = new FrmListagemGenerica();
            List<Servico> servicos = _servicoServico.BuscarTodos();

            IEnumerable<ListagemGenericaDTO> dados = from s in servicos
                                                     orderby s.Descricao
                                                     select new ListagemGenericaDTO()
                                                     {
                                                         Codigo = s.Id,
                                                         Descricao = s.Descricao
                                                     };

            listagem.Lista = dados.ToList();
            listagem.ShowDialog();

            if (listagem.CodigoSelecionado > 0)
            {
                Servico s = _servicoServico.BuscarPeloId(listagem.CodigoSelecionado);

                txtCodigoServico.Text = s.Id.ToString();
                txtDescricaoServico.Text = s.Descricao.ToString();
                txtValorServico.Text = $"R$ {s.Valor.ToString("F2")}";

            }

        }

        private void btnAddServico_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCodigoServico.Text.Trim()))
            {
                MessageBox.Show("Escolha um serviço antes de adicionar", "Atenção !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(txtQtServico.Text.Trim()))
            {
                MessageBox.Show("Coloque a quantidade do serviço a ser adicionada", "Atenção !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            } else if (!int.TryParse(txtQtServico.Text.Trim(), out int quantidadeServico))
            {
                MessageBox.Show("Você precisa informar um numero[0-100...] para a quantidade do serviço !!", "Atenção !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var existe = Locacao.ServicosSolicitados.Where(s => s.Servico.Id == int.Parse(txtCodigoServico.Text.ToString()));

            if (existe.Count() > 0)
            {
                MessageBox.Show("Serviço já foi adicionado a esta locação", "Atenção !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Servico servico = _servicoServico.BuscarPeloId(int.Parse(txtCodigoServico.Text.ToString()));

            Object row = new
            {
                Id = servico.Id,
                Descricao = servico.Descricao,
                ValorUnitario = servico.Valor,
                Quantidade = int.Parse(txtQtServico.Text),
                ValorTotal = servico.Valor * int.Parse(txtQtServico.Text)
            };

            ListaServicos.Add(row);
            dgServicosSolicitados.DataSource = null;
            dgServicosSolicitados.DataSource = ListaServicos;

            AdicionarServicos = true;
            AtualizarValorDaLocacao();

        }
    }
}
