using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using VallezHotels.Source.Servicos;
using VallezHotels.Source.Entidades;

namespace VallezHotels.Test.Servicos
{
    public class ServicoSolicitadoServicoTeste : IDisposable
    {

        private readonly QuartoServico _quartoServico = new QuartoServico();
        private readonly TipoQuartoServico _tipoQuartoServico = new TipoQuartoServico();
        private readonly LocacaoServico _locacaoServico = new LocacaoServico();
        private readonly ServicoServico _servicoServico = new ServicoServico();
        private Quarto Q1;
        private Quarto Q2;
        private TipoQuarto Tq1;
        private TipoQuarto Tq2;
        private Locacao L1;
        private Locacao L2;
        private Servico S1;

        public ServicoSolicitadoServicoTeste()
        {

            TipoQuarto tq1 = new TipoQuarto()
            {
                Descricao = "Casal"
            };

            TipoQuarto tq2 = new TipoQuarto()
            {
                Descricao = "Simples"
            };

            Tq1 = _tipoQuartoServico.InserirTipoQuarto(tq1);
            Tq2 = _tipoQuartoServico.InserirTipoQuarto(tq2);

            Quarto q1 = new Quarto()
            {
                TipoQuarto = Tq1,
                Bloco = "A",
                Numero = 1,
                QuantidadeBanheiros = 1,
                QuantidadeCamas = 1,
                ValorDiaria = 22.58
            };

            Quarto q2 = new Quarto()
            {
                TipoQuarto = Tq2,
                Bloco = "B",
                Numero = 1,
                QuantidadeBanheiros = 1,
                QuantidadeCamas = 1,
                ValorDiaria = 22.58
            };

            Q1 = _quartoServico.InserirQuarto(q1);
            Q2 = _quartoServico.InserirQuarto(q2);

            Locacao l1 = new Locacao()
            {
                Quarto = Q1,
                DataEntrada = new DateTime(2021, 03, 01),
                DataSaida = new DateTime(2021, 03, 07),
                CheckIn = new DateTime(2021, 03, 01),
                CheckOut = new DateTime(2021, 03, 07),
            };

            Locacao l2 = new Locacao()
            {
                Quarto = Q2,
                DataEntrada = new DateTime(2021, 03, 01),
                DataSaida = new DateTime(2021, 03, 07),
                CheckIn = new DateTime(2021, 03, 01),
                CheckOut = new DateTime(2021, 03, 07),
            };

            L1 = _locacaoServico.InserirLocacao(l1);
            L2 = _locacaoServico.InserirLocacao(l2);

            Servico s1 = new Servico()
            {
                Descricao = "Servico teste",
                Valor = 10.20
            };

            S1 = _servicoServico.InserirServico(s1);
        }

        [Fact]
        public void Deve_Inserir_Um_Novo_ServicoSolicitado()
        {

            ServicoSolicitado ss = new ServicoSolicitado()
            {
                Servico = S1,
                Locacao = L1,
                Solicitacao = new DateTime(2021, 03, 04),
                Quantidade = 1
            };


            ServicoSolicitadoServico servicoSolicitadoServico = new ServicoSolicitadoServico();

            ServicoSolicitado novo = servicoSolicitadoServico.InserirServicoSolicitado(ss);

            Assert.NotNull(novo.Uuid);
            Assert.NotNull(novo.Locacao.Uuid);
            Assert.NotNull(novo.Servico.Uuid);

            servicoSolicitadoServico.DeletarServicoSolicitado(novo);

        }



        [Fact]
        public void Deve_Excluir_Um_ServicoSolicitado()
        {

            ServicoSolicitado ss = new ServicoSolicitado()
            {
                Servico = S1,
                Locacao = L1,
                Solicitacao = new DateTime(2021, 03, 04),
                Quantidade = 1
            };


            ServicoSolicitadoServico servicoSolicitadoServico = new ServicoSolicitadoServico();

            ServicoSolicitado novo = servicoSolicitadoServico.InserirServicoSolicitado(ss);

            servicoSolicitadoServico.DeletarServicoSolicitado(novo);

            Assert.NotNull(novo);
        }


        [Fact]
        public void Deve_Buscar_Um_ServicoSolicitado()
        {
            ServicoSolicitado ss = new ServicoSolicitado()
            {
                Servico = S1,
                Locacao = L1,
                Solicitacao = new DateTime(2021, 03, 04),
                Quantidade = 1
            };


            ServicoSolicitadoServico servicoSolicitadoServico = new ServicoSolicitadoServico();

            ServicoSolicitado novo = servicoSolicitadoServico.InserirServicoSolicitado(ss);

            ServicoSolicitado busca = servicoSolicitadoServico.BuscarPeloId(novo.Id);

            Assert.NotNull(busca);
            Assert.NotNull(busca.Uuid);

            servicoSolicitadoServico.DeletarServicoSolicitado(busca);

        }


        [Fact]
        public void Deve_Buscar_Todos_ServicoSolicitados()
        {
            ServicoSolicitado ss1 = new ServicoSolicitado()
            {
                Servico = S1,
                Locacao = L1,
                Solicitacao = new DateTime(2021, 03, 04),
                Quantidade = 1
            };


            ServicoSolicitado ss2 = new ServicoSolicitado()
            {
                Servico = S1,
                Locacao = L2,
                Solicitacao = new DateTime(2021, 03, 04),
                Quantidade = 1
            };


            ServicoSolicitadoServico servicoSolicitadoServico = new ServicoSolicitadoServico();

            servicoSolicitadoServico.InserirServicoSolicitado(ss1);
            servicoSolicitadoServico.InserirServicoSolicitado(ss2);

            List<ServicoSolicitado> servicoSolicitados = servicoSolicitadoServico.BuscarTodos();

            Assert.NotEmpty(servicoSolicitados);
            Assert.Equal(2, servicoSolicitados.Count);

            servicoSolicitadoServico.DeletarServicoSolicitado(servicoSolicitados[0]);
            servicoSolicitadoServico.DeletarServicoSolicitado(servicoSolicitados[1]);

        }


        [Fact]
        public void Deve_Alterar_Um_ServicoSolicitado()
        {

            ServicoSolicitado ss = new ServicoSolicitado()
            {
                Servico = S1,
                Locacao = L1,
                Solicitacao = new DateTime(2021, 03, 04),
                Quantidade = 1
            };

            ServicoSolicitadoServico servicoSolicitadoServico = new ServicoSolicitadoServico();

            ServicoSolicitado criado = servicoSolicitadoServico.InserirServicoSolicitado(ss);

            ServicoSolicitado alterado = new ServicoSolicitado()
            {
                Id = criado.Id,
                Uuid = criado.Uuid,
                Locacao = criado.Locacao,
                Servico = criado.Servico,
                Solicitacao = new DateTime(2021, 03, 06),
                Quantidade = 1,
                CreatedAt = criado.CreatedAt,
                UpdatedAt = criado.UpdatedAt
            };


            ServicoSolicitado busca = servicoSolicitadoServico.EditarServicoSolicitado(alterado);

            Assert.NotEqual(ss.Solicitacao, busca.Solicitacao);

            servicoSolicitadoServico.DeletarServicoSolicitado(busca);

        }

        public void Dispose()
        {
            _servicoServico.DeletarServico(S1);

            _locacaoServico.DeletarLocacao(L1);
            _locacaoServico.DeletarLocacao(L2);

            _quartoServico.DeletarQuarto(Q1);
            _quartoServico.DeletarQuarto(Q2);

            _tipoQuartoServico.DeletarTipoQuarto(Tq1);
            _tipoQuartoServico.DeletarTipoQuarto(Tq2);
        }
    }

}
