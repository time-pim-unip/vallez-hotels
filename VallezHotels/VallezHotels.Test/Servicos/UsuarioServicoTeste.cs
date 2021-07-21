using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using VallezHotels.Source.Entidades;
using VallezHotels.Source.Servicos;
using VallezHotels.Source.DB.Exceptions;

namespace VallezHotels.Test.Servicos
{
    public class UsuarioServicoTeste
    {

        [Fact]
        public void Deve_Inserir_Um_Usuario_No_Banco()
        {
            Usuario u = new Usuario
            {
                NomeUsuario = "teste",
                Senha = "123456",
                TipoUsuario = "U",
                Status = true
            };

            UsuarioServico servico = new UsuarioServico();

            Usuario uInserido = servico.InserirUsuario(u);

            Assert.NotNull(uInserido);
            Assert.NotEqual<Usuario>(u, uInserido);
            Assert.NotNull(uInserido.Uuid);


            servico.DeletarUsuario(uInserido);

        }

        [Fact]
        public void Deve_Deletar_Usuario_Do_Banco()
        {
            Usuario u = new Usuario
            {
                NomeUsuario = "teste",
                Senha = "123456",
                TipoUsuario = "U",
                Status = true
            };

            UsuarioServico servico = new UsuarioServico();
            Usuario u2 = servico.InserirUsuario(u);
            servico.DeletarUsuario(u2);
        }

        [Fact]
        public void Deve_Buscar_Um_Usuario_Pelo_Id()
        {
            Usuario u = new Usuario
            {
                NomeUsuario = "teste_busca_id",
                Senha = "123456",
                TipoUsuario = "U",
                Status = true
            };

            UsuarioServico servico = new UsuarioServico();
            Usuario u2 = servico.InserirUsuario(u);

            int idUsuarioInserido = u2.Id;

            Usuario u3 = servico.BuscarPeloId(idUsuarioInserido);

            Assert.Equal(u2.Uuid.GetHashCode(), u3.Uuid.GetHashCode());

            servico.DeletarUsuario(u3);

        }

        [Fact]
        public void Deve_Falhar_Ao_Buscar_Um_Usuario_Por_Id_Inexistente()
        {

            UsuarioServico servico = new UsuarioServico();

            int idUsuarioBusca = 9999999;

            Action metodoBusca = () => servico.BuscarPeloId(idUsuarioBusca);
            NullReturnException ex = Assert.Throws<NullReturnException>(metodoBusca);

            Assert.Equal(nameof(NullReturnException), ex.GetType().Name.ToString());

        }

        [Fact]
        public void Deve_Atualizar_Um_Usuario_No_Banco()
        {
            Usuario original = new Usuario
            {
                NomeUsuario = "teste_atualizacao",
                Senha = "123456",
                TipoUsuario = "U",
                Status = true
            };
            UsuarioServico servico = new UsuarioServico();

            original = servico.InserirUsuario(original);

            Usuario modificado = new Usuario
            {
                Id = original.Id,
                Uuid = original.Uuid,
                NomeUsuario = "teste_pos_atualizacao",
                Senha = original.Senha,
                TipoUsuario = original.TipoUsuario,
                Status = original.Status,
                CreatedAt = original.CreatedAt,
                UpdatedAt = original.UpdatedAt

            };

            Usuario atualizado = servico.EditarUsuario(modificado);

            Usuario busca = servico.BuscarPeloId(original.Id);

            Assert.Equal(atualizado.Uuid, busca.Uuid);
            Assert.Equal(atualizado.NomeUsuario, busca.NomeUsuario);
            Assert.NotEqual(original.NomeUsuario, busca.NomeUsuario);

            servico.DeletarUsuario(busca);

        }

        [Fact]
        public void Deve_Retornar_Todos_Os_Usuarios()
        {
            Usuario u1 = new Usuario
            {
                NomeUsuario = "teste_1",
                Senha = "123456",
                TipoUsuario = "U",
                Status = true
            };

            Usuario u2 = new Usuario
            {
                NomeUsuario = "teste_2",
                Senha = "123456",
                TipoUsuario = "U",
                Status = true
            };

            Usuario u3 = new Usuario
            {
                NomeUsuario = "teste_3",
                Senha = "123456",
                TipoUsuario = "U",
                Status = true
            };

            UsuarioServico servico = new UsuarioServico();
            servico.InserirUsuario(u1);
            servico.InserirUsuario(u2);
            servico.InserirUsuario(u3);


            List<Usuario> usuarios = servico.BuscarTodos();


            Assert.NotEmpty(usuarios);

            servico.DeletarUsuario(usuarios[0]);
            servico.DeletarUsuario(usuarios[1]);
            servico.DeletarUsuario(usuarios[2]);

        }

    }
}
