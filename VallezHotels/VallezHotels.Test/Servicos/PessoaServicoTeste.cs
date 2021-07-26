using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using VallezHotels.Source.Servicos;
using VallezHotels.Source.Entidades;

namespace VallezHotels.Test.Servicos
{
    public class PessoaServicoTeste
    {

        [Fact]
        public void Deve_Inserir_Uma_Pessoa_No_Banco()
        {

            Pessoa p = new Pessoa()
            {
                Nome = "Pessoa Teste",
                DataNascimento = new DateTime(1997, 03, 15),
                Cpf = "11111111111",
                RG = "111111111",
                Email = "pessoa@email.com",
                Telefone = "(11) 1111-1111",
                Celular = "(11) 11111-1111"
            };

            PessoaServico servico = new PessoaServico();
            Pessoa pInserida = servico.InserirPessoa(p);

            Assert.NotEqual<Pessoa>(p, pInserida);
            Assert.NotNull(pInserida);
            Assert.NotNull(pInserida.UuidPessoa);

            servico.DeletarPessoa(pInserida);

        }

        [Fact]
        public void Deve_Excluir_Uma_Pessoa_Do_Banco()
        {

            Pessoa p = new Pessoa()
            {
                Nome = "Pessoa Teste",
                DataNascimento = new DateTime(1997, 03, 15),
                Cpf = "11111111111",
                RG = "111111111",
                Email = "pessoa@email.com",
                Telefone = "(11) 1111-1111",
                Celular = "(11) 11111-1111"
            };

            PessoaServico servico = new PessoaServico();
            Pessoa pInserida = servico.InserirPessoa(p);

            servico.DeletarPessoa(pInserida);

        }

        [Fact]
        public void Deve_Buscar_Uma_Pessoa_No_Banco()
        {
            Pessoa p = new Pessoa()
            {
                Nome = "Pessoa Teste",
                DataNascimento = new DateTime(1997, 03, 15),
                Cpf = "11111111111",
                RG = "111111111",
                Email = "pessoa@email.com",
                Telefone = "(11) 1111-1111",
                Celular = "(11) 11111-1111"
            };

            PessoaServico servico = new PessoaServico();
            Pessoa pInserida = servico.InserirPessoa(p);
            int idPessoaInserida = pInserida.IdPessoa;

            Pessoa pBusca = servico.BuscarPeloId(idPessoaInserida);

            Assert.NotNull(pBusca);
            Assert.Equal(idPessoaInserida, pBusca.IdPessoa);
            Assert.Equal(pInserida.UuidPessoa, pBusca.UuidPessoa);

            servico.DeletarPessoa(pBusca);

        }

        [Fact]
        public void Deve_Buscar_Todas_Pessoas()
        {

            Pessoa p1 = new Pessoa()
            {
                Nome = "Pessoa Teste 1",
                DataNascimento = new DateTime(1997, 03, 15),
                Cpf = "111",
                RG = "111",
                Email = "pessoa1@email.com",
                Telefone = "(11) 1111-1111",
                Celular = "(11) 11111-1111"
            };

            Pessoa p2 = new Pessoa()
            {
                Nome = "Pessoa Teste 2",
                DataNascimento = new DateTime(1997, 03, 15),
                Cpf = "222",
                RG = "222",
                Email = "pessoa2@email.com",
                Telefone = "(11) 1111-1111",
                Celular = "(11) 11111-1111"
            };

            Pessoa p3 = new Pessoa()
            {
                Nome = "Pessoa Teste 3",
                DataNascimento = new DateTime(1997, 03, 15),
                Cpf = "333",
                RG = "333",
                Email = "pessoa3@email.com",
                Telefone = "(11) 1111-1111",
                Celular = "(11) 11111-1111"
            };

            PessoaServico servico = new PessoaServico();
            Pessoa pInserida1 = servico.InserirPessoa(p1);
            Pessoa pInserida2 = servico.InserirPessoa(p2);
            Pessoa pInserida3 = servico.InserirPessoa(p3);

            List<Pessoa> pessoas = servico.BuscarTodas();

            Assert.NotEmpty(pessoas);
            Assert.Equal(3, pessoas.Count);

            servico.DeletarPessoa(pInserida1);
            servico.DeletarPessoa(pInserida2);
            servico.DeletarPessoa(pInserida3);

        }

        [Fact]
        public void Deve_Alterar_Uma_Pessoa_Existente()
        {

            Pessoa p = new Pessoa()
            {
                Nome = "Pessoa Teste",
                DataNascimento = new DateTime(1997, 03, 15),
                Cpf = "11111111111",
                RG = "111111111",
                Email = "pessoa@email.com",
                Telefone = "(11) 1111-1111",
                Celular = "(11) 11111-1111"
            };

            PessoaServico servico = new PessoaServico();
            Pessoa pInserida = servico.InserirPessoa(p);

            Pessoa pAlterar = new Pessoa()
            {
                IdPessoa = pInserida.IdPessoa,
                UuidPessoa = pInserida.UuidPessoa,
                Nome = "Nome alterado",
                DataNascimento = pInserida.DataNascimento,
                Cpf = pInserida.Cpf,
                RG = pInserida.RG,
                Email = pInserida.Email,
                Telefone = pInserida.Telefone,
                Celular = pInserida.Celular,
                CreatedAtPessoa = pInserida.CreatedAtPessoa,
                UpdatedAtPessoa = pInserida.UpdatedAtPessoa
            };

            Pessoa pAlterada = servico.AlterarPessoa(pAlterar);

            Assert.NotNull(pAlterada);
            Assert.Equal(pInserida.UuidPessoa, pAlterada.UuidPessoa);
            Assert.NotEqual(p.Nome, pAlterada.Nome);

            servico.DeletarPessoa(pAlterada);


        }

    }
}
