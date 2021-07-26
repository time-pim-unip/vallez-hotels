using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using VallezHotels.Source.Servicos;
using VallezHotels.Source.Entidades;

namespace VallezHotels.Test.Servicos
{
    public class DisponibilidadeServicoTeste : IDisposable
    {
        
        private readonly QuartoServico _quartoServico = new QuartoServico();
        private readonly TipoQuartoServico _tipoQuartoServico = new TipoQuartoServico();
        private Quarto Q1;
        private Quarto Q2;
        private TipoQuarto Tq1;
        private TipoQuarto Tq2;

        public DisponibilidadeServicoTeste()
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
        public void Deve_Inserir_Um_Novo_Disponibilidade()
        {

            Disponibilidade d = new Disponibilidade()
            {
                Quarto = Q1,
                Data = new DateTime(2021, 03, 03),
                Disponivel = true
            };


            DisponibilidadeServico disponibilidadeServico = new DisponibilidadeServico();

            Disponibilidade novo = disponibilidadeServico.InserirDisponibilidade(d);

            Assert.NotNull(novo.Uuid);
            Assert.NotNull(novo.Quarto.Uuid);

            disponibilidadeServico.DeletarDisponibilidade(novo);

        }



        [Fact]
        public void Deve_Excluir_Um_Disponibilidade()
        {

            Disponibilidade d = new Disponibilidade()
            {
                Quarto = Q1,
                Data = new DateTime(2021, 03, 03),
                Disponivel = true
            };

            DisponibilidadeServico disponibilidadeServico = new DisponibilidadeServico();

            Disponibilidade novo = disponibilidadeServico.InserirDisponibilidade(d);

            disponibilidadeServico.DeletarDisponibilidade(novo);

            Assert.NotNull(novo);
        }


        [Fact]
        public void Deve_Buscar_Um_Disponibilidade()
        {
            Disponibilidade d = new Disponibilidade()
            {
                Quarto = Q1,
                Data = new DateTime(2021, 03, 03),
                Disponivel = true
            };

            DisponibilidadeServico disponibilidadeServico = new DisponibilidadeServico();

            Disponibilidade novo = disponibilidadeServico.InserirDisponibilidade(d);

            Disponibilidade busca = disponibilidadeServico.BuscarPeloId(novo.Id);

            Assert.NotNull(busca);
            Assert.NotNull(busca.Uuid);
            Assert.NotNull(busca.Quarto.Uuid);

            disponibilidadeServico.DeletarDisponibilidade(busca);

        }


        [Fact]
        public void Deve_Buscar_Todos_Disponibilidades()
        {
            Disponibilidade d1 = new Disponibilidade()
            {
                Quarto = Q1,
                Data = new DateTime(2021, 03, 03),
                Disponivel = true
            };

            Disponibilidade d2 = new Disponibilidade()
            {
                Quarto = Q2,
                Data = new DateTime(2021, 03, 04),
                Disponivel = true
            };

            Disponibilidade d3 = new Disponibilidade()
            {
                Quarto = Q1,
                Data = new DateTime(2021, 03, 05),
                Disponivel = true
            };


            DisponibilidadeServico disponibilidadeServico = new DisponibilidadeServico();

            disponibilidadeServico.InserirDisponibilidade(d1);
            disponibilidadeServico.InserirDisponibilidade(d2);
            disponibilidadeServico.InserirDisponibilidade(d3);

            List<Disponibilidade> disponibilidades = disponibilidadeServico.BuscarTodos();

            Assert.NotEmpty(disponibilidades);
            Assert.Equal(3, disponibilidades.Count);

            disponibilidadeServico.DeletarDisponibilidade(disponibilidades[0]);
            disponibilidadeServico.DeletarDisponibilidade(disponibilidades[1]);
            disponibilidadeServico.DeletarDisponibilidade(disponibilidades[2]);

        }


        [Fact]
        public void Deve_Alterar_Um_Disponibilidade()
        {

            Disponibilidade d = new Disponibilidade()
            {
                Quarto = Q1,
                Data = new DateTime(2021, 03, 03),
                Disponivel = true
            };

            DisponibilidadeServico disponibilidadeServico = new DisponibilidadeServico();

            Disponibilidade criado = disponibilidadeServico.InserirDisponibilidade(d);

            Disponibilidade alterado = new Disponibilidade()
            {
                Id = criado.Id,
                Uuid = criado.Uuid,
                Quarto = criado.Quarto,
                Data = new DateTime(2021, 03, 07),
                Disponivel = false,
                CreatedAt = criado.CreatedAt,
                UpdatedAt = criado.UpdatedAt
            };


            Disponibilidade busca = disponibilidadeServico.EditarDisponibilidade(alterado);

            Assert.NotEqual(d.Data, busca.Data);
            Assert.NotEqual(d.Disponivel, busca.Disponivel);

            disponibilidadeServico.DeletarDisponibilidade(busca);

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
