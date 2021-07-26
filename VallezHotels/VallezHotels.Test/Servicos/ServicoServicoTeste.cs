using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using VallezHotels.Source.Entidades;
using VallezHotels.Source.Servicos;


namespace VallezHotels.Test.Servicos
{
    public class ServicoServicoTeste
    {

        [Fact]
        public void Deve_Inserir_Novo_Servico()
        {
            Servico s = new Servico()
            {
                Descricao = "Serviço teste",
                Valor = 10.27
            };

            ServicoServico servicoServico = new ServicoServico();

            Servico novo = servicoServico.InserirServico(s);

            Assert.NotNull(novo);
            Assert.NotNull(novo.Uuid);

            servicoServico.DeletarServico(novo);

        }

        [Fact]
        public void Deve_Excluir_Um_Servico()
        {

            Servico s = new Servico()
            {
                Descricao = "Serviço teste",
                Valor = 10.27
            };

            ServicoServico servicoServico = new ServicoServico();

            Servico novo = servicoServico.InserirServico(s);

            servicoServico.DeletarServico(novo);

            Servico busca = servicoServico.BuscarPeloId(novo.Id);

            Assert.Null(busca);


        }

        [Fact]
        public void Deve_Buscar_Um_Servico()
        {
            Servico s = new Servico()
            {
                Descricao = "Serviço teste",
                Valor = 10.27
            };

            ServicoServico servicoServico = new ServicoServico();

            Servico novo = servicoServico.InserirServico(s);

            Servico busca = servicoServico.BuscarPeloId(novo.Id);

            Assert.Equal(novo.Uuid, busca.Uuid);

            servicoServico.DeletarServico(busca);

        }

        [Fact]
        public void Deve_Buscar_Todos_Servicos()
        {
            Servico s1 = new Servico()
            {
                Descricao = "Serviço teste 1",
                Valor = 10.27
            };

            Servico s2 = new Servico()
            {
                Descricao = "Serviço teste 2",
                Valor = 10.27
            };

            Servico s3 = new Servico()
            {
                Descricao = "Serviço teste 3",
                Valor = 10.27
            };

            ServicoServico servicoServico = new ServicoServico();

            servicoServico.InserirServico(s1);
            servicoServico.InserirServico(s2);
            servicoServico.InserirServico(s3);

            List<Servico> busca = servicoServico.BuscarTodos();

            Assert.NotEmpty(busca);
            Assert.Equal(3, busca.Count);

            servicoServico.DeletarServico(busca[0]);
            servicoServico.DeletarServico(busca[1]);
            servicoServico.DeletarServico(busca[2]);

        }


        [Fact]
        public void Deve_Alterar_Um_Servico()
        {
            Servico s = new Servico()
            {
                Descricao = "Serviço teste",
                Valor = 10.27
            };

            ServicoServico servicoServico = new ServicoServico();

            Servico novo = servicoServico.InserirServico(s);

            Servico alteracao = new Servico()
            {
                Id = novo.Id,
                Uuid = novo.Uuid,
                Descricao = "serviço Alterado",
                Valor = 77.5125,
                CreatedAt = novo.CreatedAt,
                UpdatedAt = novo.UpdatedAt
            };

            Servico alterado = servicoServico.AlterarServico(alteracao);

            Servico busca = servicoServico.BuscarPeloId(alterado.Id);

            Assert.Equal(novo.Uuid, busca.Uuid);
            Assert.NotEqual(novo.Descricao, busca.Descricao);

            servicoServico.DeletarServico(busca);

        }



    }
}
