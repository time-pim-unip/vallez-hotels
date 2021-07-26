using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using VallezHotels.Source.Servicos;
using VallezHotels.Source.Entidades;

namespace VallezHotels.Test.Servicos
{
    public class QuartoServicoTeste: IDisposable
    {

        private readonly TipoQuartoServico _tipoQuartoServico = new TipoQuartoServico();
        private TipoQuarto Tq1;
        private TipoQuarto Tq2;

        public QuartoServicoTeste()
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


        }

        [Fact]
        public void Deve_Inserir_Um_Novo_Quarto()
        {
            
            Quarto q = new Quarto() 
            { 
                TipoQuarto = Tq1,
                Bloco = "A",
                Numero = 1,
                QuantidadeBanheiros = 1,
                QuantidadeCamas = 1,
                ValorDiaria = 22.58
            };


            QuartoServico quartoServico = new QuartoServico();

            Quarto novo = quartoServico.InserirQuarto(q);

            Assert.NotNull(novo.Uuid);
            Assert.NotNull(novo.TipoQuarto.Uuid);

            quartoServico.DeletarQuarto(novo);

        }


        
        [Fact]
        public void Deve_Excluir_Um_Quarto()
        {

            Quarto q = new Quarto()
            {
                TipoQuarto = Tq1,
                Bloco = "A",
                Numero = 1,
                QuantidadeBanheiros = 1,
                QuantidadeCamas = 1,
                ValorDiaria = 22.58
            };


            QuartoServico quartoServico = new QuartoServico();

            Quarto novo = quartoServico.InserirQuarto(q);

            quartoServico.DeletarQuarto(novo);

            Assert.NotNull(novo);
        }

        
        [Fact]
        public void Deve_Buscar_Um_Quarto()
        {
            Quarto q = new Quarto()
            {
                TipoQuarto = Tq1,
                Bloco = "A",
                Numero = 1,
                QuantidadeBanheiros = 1,
                QuantidadeCamas = 1,
                ValorDiaria = 22.58
            };


            QuartoServico quartoServico = new QuartoServico();

            Quarto novo = quartoServico.InserirQuarto(q);


            Quarto busca = quartoServico.BuscarPeloId(novo.Id);

            Assert.NotNull(busca);
            Assert.NotNull(busca.Uuid);
            Assert.NotNull(busca.TipoQuarto.Uuid);

            quartoServico.DeletarQuarto(busca);

        }


        [Fact]
        public void Deve_Buscar_Todos_Quartos()
        {
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
                TipoQuarto = Tq1,
                Bloco = "B",
                Numero = 2,
                QuantidadeBanheiros = 1,
                QuantidadeCamas = 1,
                ValorDiaria = 22.58
            };

            Quarto q3 = new Quarto()
            {
                TipoQuarto = Tq1,
                Bloco = "C",
                Numero = 3,
                QuantidadeBanheiros = 1,
                QuantidadeCamas = 1,
                ValorDiaria = 22.58
            };


            QuartoServico quartoServico = new QuartoServico();

            quartoServico.InserirQuarto(q1);
            quartoServico.InserirQuarto(q2);
            quartoServico.InserirQuarto(q3);

            List<Quarto> quartos = quartoServico.BuscarTodos();

            Assert.NotEmpty(quartos);
            Assert.Equal(3, quartos.Count);

            quartoServico.DeletarQuarto(quartos[0]);
            quartoServico.DeletarQuarto(quartos[1]);
            quartoServico.DeletarQuarto(quartos[2]);

        }
        
        
        [Fact]
        public void Deve_Alterar_Um_Quarto()
        {

            Quarto q = new Quarto()
            {
                TipoQuarto = Tq1,
                Bloco = "A",
                Numero = 1,
                QuantidadeBanheiros = 1,
                QuantidadeCamas = 1,
                ValorDiaria = 22.58
            };

            QuartoServico quartoServico = new QuartoServico();

            Quarto criado = quartoServico.InserirQuarto(q);

            Quarto alterado = new Quarto()
            {
                Id = criado.Id,
                Uuid = criado.Uuid,
                TipoQuarto = criado.TipoQuarto,
                Bloco = criado.Bloco,
                Numero = criado.Numero,
                QuantidadeBanheiros = criado.QuantidadeBanheiros,
                QuantidadeCamas = criado.QuantidadeCamas,
                ValorDiaria = 10.20,
                CreatedAt = criado.CreatedAt,
                UpdatedAt = criado.UpdatedAt
            };


            Quarto busca = quartoServico.EditarQuarto(alterado);

            Assert.NotEqual(q.ValorDiaria, busca.ValorDiaria);

            quartoServico.DeletarQuarto(busca);

        }

        public void Dispose()
        {
            _tipoQuartoServico.DeletarTipoQuarto(Tq1);
            _tipoQuartoServico.DeletarTipoQuarto(Tq2);
        }
    }

}
