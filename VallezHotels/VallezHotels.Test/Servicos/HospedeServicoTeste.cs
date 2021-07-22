using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using VallezHotels.Source.Servicos;
using VallezHotels.Source.Entidades;

namespace VallezHotels.Test.Servicos
{
    public class HospedeServicoTeste
    {

        [Fact]
        public void Deve_Inserir_Um_Novo_Hospede()
        {
            Hospede h = new Hospede()
            {
                Nome = "Hospede Teste",
                DataNascimento = new DateTime(1997, 03, 15),
                Cpf = "111",
                RG = "111",
                Email = "hospede@email.com",
                Telefone = "(11) 11111-1111",
                Celular = "(11) 11111-1111",
                Consentimento = true
            };

            h.Usuario = new Usuario()
            {
                NomeUsuario = "usuario.teste.hospede",
                Senha = "123456",
                TipoUsuario = "U",
                Status = true
            };

            HospedeServico hospedeServico = new HospedeServico();

            Hospede novo = hospedeServico.InserirHospede(h);

            Assert.NotNull(novo.UuidHospede);
            Assert.NotNull(novo.UuidPessoa);
            Assert.NotNull(novo.Usuario.Uuid);

            hospedeServico.DeletarHospede(novo);
                      
        }

        [Fact]
        public void Deve_Excluir_Um_Hospede()
        {

            Hospede h = new Hospede()
            {
                Nome = "Hospede Teste",
                DataNascimento = new DateTime(1997, 03, 15),
                Cpf = "111",
                RG = "111",
                Email = "hospede@email.com",
                Telefone = "(11) 11111-1111",
                Celular = "(11) 11111-1111",
                Consentimento = true
            };

            h.Usuario = new Usuario()
            {
                NomeUsuario = "usuario.teste",
                Senha = "123456",
                TipoUsuario = "U",
                Status = true
            };

            HospedeServico hospedeServico = new HospedeServico();

            Hospede novo = hospedeServico.InserirHospede(h);

            hospedeServico.DeletarHospede(h);
        }

        [Fact]
        public void Deve_Buscar_Um_Hospede()
        {
            Hospede h = new Hospede()
            {
                Nome = "Hospede Teste",
                DataNascimento = new DateTime(1997, 03, 15),
                Cpf = "111",
                RG = "111",
                Email = "hospede@email.com",
                Telefone = "(11) 11111-1111",
                Celular = "(11) 11111-1111",
                Consentimento = true
            };

            h.Usuario = new Usuario()
            {
                NomeUsuario = "usuario.teste",
                Senha = "123456",
                TipoUsuario = "U",
                Status = true
            };

            HospedeServico hospedeServico = new HospedeServico();

            Hospede novo = hospedeServico.InserirHospede(h);

            Hospede busca = hospedeServico.BuscarPeloId(novo.IdHospede);

            Assert.NotNull(busca);
            Assert.NotNull(busca.UuidHospede);
            Assert.NotNull(busca.UuidPessoa);
            Assert.NotNull(busca.Usuario.Uuid);

            hospedeServico.DeletarHospede(busca);

        }

        [Fact]
        public void Deve_Buscar_Todos_Hospedes()
        {
            Hospede h1 = new Hospede()
            {
                Nome = "Hospede Teste 1",
                DataNascimento = new DateTime(1997, 03, 15),
                Cpf = "111",
                RG = "111",
                Email = "hospede@email.com",
                Telefone = "(11) 11111-1111",
                Celular = "(11) 11111-1111",
                Consentimento = true
            };

            h1.Usuario = new Usuario()
            {
                NomeUsuario = "usuario.teste.1",
                Senha = "123456",
                TipoUsuario = "U",
                Status = true
            };

            Hospede h2 = new Hospede()
            {
                Nome = "Hospede Teste 2",
                DataNascimento = new DateTime(1997, 03, 15),
                Cpf = "222",
                RG = "222",
                Email = "hospede@email.com",
                Telefone = "(11) 11111-1111",
                Celular = "(11) 11111-1111",
                Consentimento = true
            };

            h2.Usuario = new Usuario()
            {
                NomeUsuario = "usuario.teste.2",
                Senha = "123456",
                TipoUsuario = "U",
                Status = true
            };

            Hospede h3 = new Hospede()
            {
                Nome = "Hospede Teste 3",
                DataNascimento = new DateTime(1997, 03, 15),
                Cpf = "333",
                RG = "333",
                Email = "hospede@email.com",
                Telefone = "(11) 11111-1111",
                Celular = "(11) 11111-1111",
                Consentimento = true
            };

            h3.Usuario = new Usuario()
            {
                NomeUsuario = "usuario.teste.3",
                Senha = "123456",
                TipoUsuario = "U",
                Status = true
            };


            HospedeServico hospedeServico = new HospedeServico();

            hospedeServico.InserirHospede(h1);
            hospedeServico.InserirHospede(h2);
            hospedeServico.InserirHospede(h3);

            List<Hospede> hospedes = hospedeServico.BuscarTodos();

            Assert.NotEmpty(hospedes);
            Assert.Equal(3, hospedes.Count);

            hospedeServico.DeletarHospede(hospedes[0]);
            hospedeServico.DeletarHospede(hospedes[1]);
            hospedeServico.DeletarHospede(hospedes[2]);

        }
    
        [Fact]
        public void Deve_Alterar_Um_Hospede()
        {

            Hospede h1 = new Hospede()
            {
                Nome = "Hospede Teste 1",
                DataNascimento = new DateTime(1997, 03, 15),
                Cpf = "111",
                RG = "111",
                Email = "hospede@email.com",
                Telefone = "(11) 11111-1111",
                Celular = "(11) 11111-1111",
                Consentimento = true
            };

            h1.Usuario = new Usuario()
            {
                NomeUsuario = "usuario.teste.1",
                Senha = "123456",
                TipoUsuario = "U",
                Status = true
            };


            HospedeServico hospedeServico = new HospedeServico();

            Hospede criado = hospedeServico.InserirHospede(h1);

            Hospede alterado = new Hospede()
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
                IdHospede = criado.IdHospede,
                UuidHospede = criado.UuidHospede,
                Consentimento = criado.Consentimento,
                CreatedAtHospede = criado.CreatedAtHospede,
                UpdatedAtHospede = criado.UpdatedAtHospede
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

            Hospede busca = hospedeServico.EditarHospede(alterado);

            Assert.NotEqual(h1.Nome, busca.Nome);
            Assert.NotEqual(h1.Usuario.NomeUsuario, busca.Usuario.NomeUsuario);

            hospedeServico.DeletarHospede(busca);

        }
    
    }
}
