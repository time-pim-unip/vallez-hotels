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

    }
}
