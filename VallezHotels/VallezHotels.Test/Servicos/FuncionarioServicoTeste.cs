using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using VallezHotels.Source.Servicos;
using VallezHotels.Source.Entidades;

namespace VallezHotels.Test.Servicos
{
    public class FuncionarioServicoTeste
    {

        [Fact]
        public void Deve_Inserir_Um_Novo_Funcionario()
        {
            Funcionario f = new Funcionario()
            {
                Nome = "Funcionario Teste",
                DataNascimento = new DateTime(1997, 03, 15),
                Cpf = "111",
                RG = "111",
                Email = "funcionario@email.com",
                Telefone = "(11) 11111-1111",
                Celular = "(11) 11111-1111",
                CTPS = "111",
                Admissao = new DateTime(2021, 01,01)
            };

            f.Usuario = new Usuario()
            {
                NomeUsuario = "usuario.teste",
                Senha = "123456",
                TipoUsuario = "U",
                Status = true
            };

            FuncionarioServico servicoFun = new FuncionarioServico();

            Funcionario novo = servicoFun.InserirFuncionario(f);

            Assert.NotNull(novo.UuidFuncionario);
            Assert.NotNull(novo.UuidPessoa);
            Assert.NotNull(novo.Usuario.Uuid);

            servicoFun.DeletarFuncionario(novo);
                      
        }

        [Fact]
        public void Deve_Excluir_Um_Funcionario()
        {

            Funcionario f = new Funcionario()
            {
                Nome = "Funcionario Teste",
                DataNascimento = new DateTime(1997, 03, 15),
                Cpf = "111",
                RG = "111",
                Email = "funcionario@email.com",
                Telefone = "(11) 11111-1111",
                Celular = "(11) 11111-1111",
                CTPS = "111",
                Admissao = new DateTime(2021, 01, 01)
            };

            f.Usuario = new Usuario()
            {
                NomeUsuario = "usuario.teste",
                Senha = "123456",
                TipoUsuario = "U",
                Status = true
            };

            FuncionarioServico funcionarioServico = new FuncionarioServico();

            Funcionario novo = funcionarioServico.InserirFuncionario(f);

            funcionarioServico.DeletarFuncionario(f);
        }

        [Fact]
        public void Deve_Buscar_Um_Funcionario()
        {
            Funcionario f = new Funcionario()
            {
                Nome = "Funcionario Teste",
                DataNascimento = new DateTime(1997, 03, 15),
                Cpf = "111",
                RG = "111",
                Email = "funcionario@email.com",
                Telefone = "(11) 11111-1111",
                Celular = "(11) 11111-1111",
                CTPS = "111",
                Admissao = new DateTime(2021, 01, 01)
            };

            f.Usuario = new Usuario()
            {
                NomeUsuario = "usuario.teste",
                Senha = "123456",
                TipoUsuario = "U",
                Status = true
            };

            FuncionarioServico funcionarioServico = new FuncionarioServico();

            Funcionario novo = funcionarioServico.InserirFuncionario(f);

            Funcionario busca = funcionarioServico.BuscarPeloId(novo.IdFuncionario);

            Assert.NotNull(busca);
            Assert.NotNull(busca.UuidFuncionario);
            Assert.NotNull(busca.UuidPessoa);
            Assert.NotNull(busca.Usuario.Uuid);

            funcionarioServico.DeletarFuncionario(busca);



        }


    }
}
