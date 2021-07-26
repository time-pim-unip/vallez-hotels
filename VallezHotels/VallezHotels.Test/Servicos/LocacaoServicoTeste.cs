using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using VallezHotels.Source.Servicos;
using VallezHotels.Source.Entidades;

namespace VallezHotels.Test.Servicos
{
    public class LocacaoServicoTeste : IDisposable
    {

        private readonly QuartoServico _quartoServico = new QuartoServico();
        private readonly TipoQuartoServico _tipoQuartoServico = new TipoQuartoServico();
        private Quarto Q1;
        private Quarto Q2;
        private TipoQuarto Tq1;
        private TipoQuarto Tq2;

        public LocacaoServicoTeste()
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
        }

        [Fact]
        public void Deve_Inserir_Um_Novo_Locacao()
        {

            Locacao l = new Locacao()
            {
                Quarto = Q1,
                DataEntrada = new DateTime(2021,03,01),
                DataSaida = new DateTime(2021,03,07),
                CheckIn = new DateTime(2021, 03, 01),
                CheckOut = new DateTime(2021, 03, 07),
            };


            LocacaoServico locacaoServico = new LocacaoServico();

            Locacao novo = locacaoServico.InserirLocacao(l);

            Assert.NotNull(novo.Uuid);
            Assert.NotNull(novo.Quarto.Uuid);

            locacaoServico.DeletarLocacao(novo);

        }



        [Fact]
        public void Deve_Excluir_Um_Locacao()
        {

            Locacao l = new Locacao()
            {
                Quarto = Q1,
                DataEntrada = new DateTime(2021, 03, 01),
                DataSaida = new DateTime(2021, 03, 07),
                CheckIn = new DateTime(2021, 03, 01),
                CheckOut = new DateTime(2021, 03, 07),
            };


            LocacaoServico locacaoServico = new LocacaoServico();

            Locacao novo = locacaoServico.InserirLocacao(l);

            locacaoServico.DeletarLocacao(novo);

            Assert.NotNull(novo);
        }


        [Fact]
        public void Deve_Buscar_Um_Locacao()
        {
            Locacao l = new Locacao()
            {
                Quarto = Q1,
                DataEntrada = new DateTime(2021, 03, 01),
                DataSaida = new DateTime(2021, 03, 07),
                CheckIn = new DateTime(2021, 03, 01),
                CheckOut = new DateTime(2021, 03, 07),
            };


            LocacaoServico locacaoServico = new LocacaoServico();

            Locacao novo = locacaoServico.InserirLocacao(l);

            Locacao busca = locacaoServico.BuscarPeloId(novo.Id);

            Assert.NotNull(busca);
            Assert.NotNull(busca.Uuid);
            Assert.NotNull(busca.Quarto.Uuid);

            locacaoServico.DeletarLocacao(busca);

        }


        [Fact]
        public void Deve_Buscar_Todos_Locacaos()
        {
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




            LocacaoServico locacaoServico = new LocacaoServico();

            locacaoServico.InserirLocacao(l1);
            locacaoServico.InserirLocacao(l2);

            List<Locacao> locacaos = locacaoServico.BuscarTodos();

            Assert.NotEmpty(locacaos);
            Assert.Equal(2, locacaos.Count);

            locacaoServico.DeletarLocacao(locacaos[0]);
            locacaoServico.DeletarLocacao(locacaos[1]);

        }


        [Fact]
        public void Deve_Alterar_Um_Locacao()
        {

            Locacao l = new Locacao()
            {
                Quarto = Q1,
                DataEntrada = new DateTime(2021, 03, 01),
                DataSaida = new DateTime(2021, 03, 07),
                CheckIn = new DateTime(2021, 03, 01),
                CheckOut = new DateTime(2021, 03, 07),
            };

            LocacaoServico locacaoServico = new LocacaoServico();

            Locacao criado = locacaoServico.InserirLocacao(l);

            Locacao alterado = new Locacao()
            {
                Id = criado.Id,
                Uuid = criado.Uuid,
                Quarto = criado.Quarto,
                DataEntrada = new DateTime(2021, 03, 08),
                DataSaida = new DateTime(2021, 03, 010),
                CheckIn = new DateTime(2021, 03, 08),
                CheckOut = new DateTime(2021, 03, 010),
                CreatedAt = criado.CreatedAt,
                UpdatedAt = criado.UpdatedAt
            };


            Locacao busca = locacaoServico.EditarLocacao(alterado);

            Assert.NotEqual(l.DataEntrada, busca.DataEntrada);

            locacaoServico.DeletarLocacao(busca);

        }

        public void Dispose()
        {
            _quartoServico.DeletarQuarto(Q1);
            _quartoServico.DeletarQuarto(Q2);
            _tipoQuartoServico.DeletarTipoQuarto(Tq1);
            _tipoQuartoServico.DeletarTipoQuarto(Tq2);
        }
    }

}
