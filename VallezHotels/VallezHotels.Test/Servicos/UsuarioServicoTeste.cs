using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using VallezHotels.Source.Entidades;
using VallezHotels.Source.Servicos;

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

        public void Deve_Falhar_Ao_Buscar_Um_Usuario_Por_Id_Inexistente()
        {


        }

    }
}
