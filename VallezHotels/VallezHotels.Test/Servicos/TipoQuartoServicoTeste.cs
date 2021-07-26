using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using VallezHotels.Source.Entidades;
using VallezHotels.Source.Servicos;


namespace VallezHotels.Test.Servicos
{
    public class TipoQuartoServicoTeste
    {

        [Fact]
        public void Deve_Inserir_Novo_Tipo_De_Quarto()
        {
            TipoQuarto t = new TipoQuarto()
            {
                Descricao = "Tipo quarto teste"
            };

            TipoQuartoServico tipoQuartoServico = new TipoQuartoServico();

            TipoQuarto novo = tipoQuartoServico.InserirTipoQuarto(t);

            Assert.NotNull(novo);
            Assert.NotNull(novo.Uuid);

            tipoQuartoServico.DeletarTipoQuarto(novo);

        }

        [Fact]
        public void Deve_Excluir_Um_TipoQuarto()
        {

            TipoQuarto t = new TipoQuarto()
            {
                Descricao = "Serviço teste"
            };

            TipoQuartoServico tipoQuartoServico = new TipoQuartoServico();

            TipoQuarto novo = tipoQuartoServico.InserirTipoQuarto(t);

            tipoQuartoServico.DeletarTipoQuarto(novo);

            TipoQuarto busca = tipoQuartoServico.BuscarPeloId(novo.Id);

            Assert.Null(busca);


        }

        [Fact]
        public void Deve_Buscar_Um_TipoQuarto()
        {
            TipoQuarto t = new TipoQuarto()
            {
                Descricao = "Serviço teste",
            };

            TipoQuartoServico tipoQuartoServico = new TipoQuartoServico();

            TipoQuarto novo = tipoQuartoServico.InserirTipoQuarto(t);

            TipoQuarto busca = tipoQuartoServico.BuscarPeloId(novo.Id);

            Assert.Equal(novo.Uuid, busca.Uuid);

            tipoQuartoServico.DeletarTipoQuarto(busca);

        }

        [Fact]
        public void Deve_Buscar_Todos_TipoQuartos()
        {
            TipoQuarto s1 = new TipoQuarto()
            {
                Descricao = "Serviço teste 1"
            };

            TipoQuarto s2 = new TipoQuarto()
            {
                Descricao = "Serviço teste 2"
            };

            TipoQuarto s3 = new TipoQuarto()
            {
                Descricao = "Serviço teste 3"
            };

            TipoQuartoServico tipoQuartoServico = new TipoQuartoServico();

            tipoQuartoServico.InserirTipoQuarto(s1);
            tipoQuartoServico.InserirTipoQuarto(s2);
            tipoQuartoServico.InserirTipoQuarto(s3);

            List<TipoQuarto> busca = tipoQuartoServico.BuscarTodos();

            Assert.NotEmpty(busca);
            Assert.Equal(3, busca.Count);

            tipoQuartoServico.DeletarTipoQuarto(busca[0]);
            tipoQuartoServico.DeletarTipoQuarto(busca[1]);
            tipoQuartoServico.DeletarTipoQuarto(busca[2]);

        }


        [Fact]
        public void Deve_Alterar_Um_TipoQuarto()
        {
            TipoQuarto t = new TipoQuarto()
            {
                Descricao = "Serviço teste"
            };

            TipoQuartoServico tipoQuartoServico = new TipoQuartoServico();

            TipoQuarto novo = tipoQuartoServico.InserirTipoQuarto(t);

            TipoQuarto alteracao = new TipoQuarto()
            {
                Id = novo.Id,
                Uuid = novo.Uuid,
                Descricao = "serviço Alterado",
                CreatedAt = novo.CreatedAt,
                UpdatedAt = novo.UpdatedAt
            };

            TipoQuarto alterado = tipoQuartoServico.AlterarTipoQuarto(alteracao);

            TipoQuarto busca = tipoQuartoServico.BuscarPeloId(alterado.Id);

            Assert.Equal(novo.Uuid, busca.Uuid);
            Assert.NotEqual(novo.Descricao, busca.Descricao);

            tipoQuartoServico.DeletarTipoQuarto(busca);

        }
    }
}
