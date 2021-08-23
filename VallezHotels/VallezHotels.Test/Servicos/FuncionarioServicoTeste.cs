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

        [Fact]
        public void Deve_Buscar_Todos_Funcionarios()
        {
            Funcionario f1 = new Funcionario()
            {
                Nome = "Funcionario Teste 1",
                DataNascimento = new DateTime(1997, 03, 15),
                Cpf = "111",
                RG = "111",
                Email = "funcionario@email.com",
                Telefone = "(11) 11111-1111",
                Celular = "(11) 11111-1111",
                CTPS = "111",
                Admissao = new DateTime(2021, 01, 01)
            };

            f1.Usuario = new Usuario()
            {
                NomeUsuario = "usuario.teste.1",
                Senha = "123456",
                TipoUsuario = "U",
                Status = true
            };

            Funcionario f2 = new Funcionario()
            {
                Nome = "Funcionario Teste 2",
                DataNascimento = new DateTime(1997, 03, 15),
                Cpf = "222",
                RG = "222",
                Email = "funcionario@email.com",
                Telefone = "(11) 11111-1111",
                Celular = "(11) 11111-1111",
                CTPS = "222",
                Admissao = new DateTime(2021, 01, 01)
            };

            f2.Usuario = new Usuario()
            {
                NomeUsuario = "usuario.teste.2",
                Senha = "123456",
                TipoUsuario = "U",
                Status = true
            };

            Funcionario f3 = new Funcionario()
            {
                Nome = "Funcionario Teste 3",
                DataNascimento = new DateTime(1997, 03, 15),
                Cpf = "333",
                RG = "333",
                Email = "funcionario@email.com",
                Telefone = "(11) 11111-1111",
                Celular = "(11) 11111-1111",
                CTPS = "333",
                Admissao = new DateTime(2021, 01, 01)
            };

            f3.Usuario = new Usuario()
            {
                NomeUsuario = "usuario.teste.3",
                Senha = "123456",
                TipoUsuario = "U",
                Status = true
            };


            FuncionarioServico funcionarioServico = new FuncionarioServico();

            funcionarioServico.InserirFuncionario(f1);
            funcionarioServico.InserirFuncionario(f2);
            funcionarioServico.InserirFuncionario(f3);

            List<Funcionario> funcionarios = funcionarioServico.BuscarTodos();

            Assert.NotEmpty(funcionarios);
            Assert.Equal(3, funcionarios.Count);

            funcionarioServico.DeletarFuncionario(funcionarios[0]);
            funcionarioServico.DeletarFuncionario(funcionarios[1]);
            funcionarioServico.DeletarFuncionario(funcionarios[2]);

        }
    
        [Fact]
        public void Deve_Alterar_Um_Funcionario()
        {

            Funcionario f1 = new Funcionario()
            {
                Nome = "Funcionario Teste 1",
                DataNascimento = new DateTime(1997, 03, 15),
                Cpf = "111",
                RG = "111",
                Email = "funcionario@email.com",
                Telefone = "(11) 11111-1111",
                Celular = "(11) 11111-1111",
                CTPS = "111",
                Admissao = new DateTime(2021, 01, 01)
            };

            f1.Usuario = new Usuario()
            {
                NomeUsuario = "usuario.teste.1",
                Senha = "123456",
                TipoUsuario = "U",
                Status = true
            };


            FuncionarioServico funcionarioServico = new FuncionarioServico();

            Funcionario criado = funcionarioServico.InserirFuncionario(f1);

            Funcionario alterado = new Funcionario()
            {
                IdPessoa = criado.IdPessoa,
                UuidPessoa = criado.UuidPessoa,
                Nome = "Nome alterado",
                DataNascimento = criado.DataNascimento,
                Cpf = criado.Cpf,
                RG = criado.RG,
                Email = criado.Email,
                Telefone = criado.Telefone,
                Celular = criado.Celular,
                CreatedAtPessoa = criado.CreatedAtPessoa,
                UpdatedAtPessoa = criado.UpdatedAtPessoa,
                IdFuncionario = criado.IdFuncionario,
                UuidFuncionario = criado.UuidFuncionario,
                CTPS = "777",
                Admissao = criado.Admissao,
                CreatedAtFuncionario = criado.CreatedAtFuncionario,
                UpdatedAtFuncionario = criado.UpdatedAtFuncionario
            };

            alterado.Usuario = new Usuario()
            {
                Id = criado.Usuario.Id,
                Uuid = criado.Usuario.Uuid,
                NomeUsuario = "alteradoxxT",
                Senha = criado.Usuario.Senha,
                TipoUsuario = criado.Usuario.TipoUsuario,
                Status = criado.Usuario.Status,
                CreatedAt = criado.Usuario.CreatedAt,
                UpdatedAt = criado.Usuario.UpdatedAt
            };

            Funcionario busca = funcionarioServico.EditarFuncionario(alterado);

            Assert.NotEqual(f1.Nome, busca.Nome);
            Assert.NotEqual(f1.Usuario.NomeUsuario, busca.Usuario.NomeUsuario);

            funcionarioServico.DeletarFuncionario(busca);

        }
    
    }
}
