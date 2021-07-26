using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using VallezHotels.Source.Servicos;
using VallezHotels.Source.Entidades;

namespace VallezHotels.Test.Servicos
{
    public class FaturamentoServicoTeste : IDisposable
    {

        private readonly QuartoServico _quartoServico = new QuartoServico();
        private readonly TipoQuartoServico _tipoQuartoServico = new TipoQuartoServico();
        private readonly LocacaoServico _locacaoServico = new LocacaoServico();
        private Quarto Q1;
        private Quarto Q2;
        private TipoQuarto Tq1;
        private TipoQuarto Tq2;
        private Locacao L1;
        private Locacao L2;

        public FaturamentoServicoTeste()
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
                DataEntrada = new DateTime(2021,03,01),
                DataSaida = new DateTime(2021,03,07),
                CheckIn = new DateTime(2021,03,01),
                CheckOut = new DateTime(2021,03,07),
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
        }

        [Fact]
        public void Deve_Inserir_Um_Novo_Faturamento()
        {

            Faturamento f = new Faturamento()
            {
                Locacao = L1,
                ValorTotal = 100.00,
                ValorDesconto = 10.00,
                ValorPago = 90.00
            };


            FaturamentoServico faturamentoServico = new FaturamentoServico();

            Faturamento novo = faturamentoServico.InserirFaturamento(f);

            Assert.NotNull(novo.Uuid);
            Assert.NotNull(novo.Locacao.Uuid);

            faturamentoServico.DeletarFaturamento(novo);

        }



        [Fact]
        public void Deve_Excluir_Um_Faturamento()
        {

            Faturamento f = new Faturamento()
            {
                Locacao = L1,
                ValorTotal = 100.00,
                ValorDesconto = 10.00,
                ValorPago = 90.00
            };


            FaturamentoServico faturamentoServico = new FaturamentoServico();

            Faturamento novo = faturamentoServico.InserirFaturamento(f);

            faturamentoServico.DeletarFaturamento(novo);

            Assert.NotNull(novo);
        }


        [Fact]
        public void Deve_Buscar_Um_Faturamento()
        {
            Faturamento f = new Faturamento()
            {
                Locacao = L1,
                ValorTotal = 100.00,
                ValorDesconto = 10.00,
                ValorPago = 90.00
            };


            FaturamentoServico faturamentoServico = new FaturamentoServico();

            Faturamento novo = faturamentoServico.InserirFaturamento(f);

            Faturamento busca = faturamentoServico.BuscarPeloId(novo.Id);

            Assert.NotNull(busca);
            Assert.NotNull(busca.Uuid);

            faturamentoServico.DeletarFaturamento(busca);

        }


        [Fact]
        public void Deve_Buscar_Todos_Faturamentos()
        {
            Faturamento f1 = new Faturamento()
            {
                Locacao = L1,
                ValorTotal = 100.00,
                ValorDesconto = 10.00,
                ValorPago = 90.00
            };


            Faturamento f2 = new Faturamento()
            {
                Locacao = L2,
                ValorTotal = 100.00,
                ValorDesconto = 10.00,
                ValorPago = 90.00
            };




            FaturamentoServico faturamentoServico = new FaturamentoServico();

            faturamentoServico.InserirFaturamento(f1);
            faturamentoServico.InserirFaturamento(f2);

            List<Faturamento> faturamentos = faturamentoServico.BuscarTodos();

            Assert.NotEmpty(faturamentos);
            Assert.Equal(2, faturamentos.Count);

            faturamentoServico.DeletarFaturamento(faturamentos[0]);
            faturamentoServico.DeletarFaturamento(faturamentos[1]);

        }


        [Fact]
        public void Deve_Alterar_Um_Faturamento()
        {

            Faturamento f = new Faturamento()
            {
                Locacao = L1,
                ValorTotal = 100.00,
                ValorDesconto = 10.00,
                ValorPago = 90.00
            };

            FaturamentoServico faturamentoServico = new FaturamentoServico();

            Faturamento criado = faturamentoServico.InserirFaturamento(f);

            Faturamento alterado = new Faturamento()
            {
                Id = criado.Id,
                Uuid = criado.Uuid,
                Locacao = criado.Locacao,
                ValorTotal = 110.00,
                ValorDesconto = 30.00,
                ValorPago = 80.00,
                CreatedAt = criado.CreatedAt,
                UpdatedAt = criado.UpdatedAt
            };


            Faturamento busca = faturamentoServico.EditarFaturamento(alterado);

            Assert.NotEqual(f.ValorTotal, busca.ValorTotal);

            faturamentoServico.DeletarFaturamento(busca);

        }

        public void Dispose()
        {
            _locacaoServico.DeletarLocacao(L1);
            _locacaoServico.DeletarLocacao(L2);
            _quartoServico.DeletarQuarto(Q1);
            _quartoServico.DeletarQuarto(Q2);
            _tipoQuartoServico.DeletarTipoQuarto(Tq1);
            _tipoQuartoServico.DeletarTipoQuarto(Tq2);
        }
    }

}
