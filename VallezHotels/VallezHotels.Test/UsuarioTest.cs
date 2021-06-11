using System;
using System.Collections.Generic;
using System.Text;
using Xunit;// Necessário usar a biblioteca Xunit para executar os teste.
using VallezHotels.Source.Entidades;// Necessário vincular o NAMESPACE que contem as entidades no projeto Vallez-Hottels para visualizar nos testes.

namespace VallezHotels.Test
{
    public class UsuarioTest
    {

        [Fact]
        public void DeveInserirUmUsuarioNoBanco() // Função sem retorno para testar um parte do software.
        {
            // Inicio do Teste

            // Cria um objeto do usuário para ser testado.
            Usuario usuario = new Usuario();

            // Define as propríedades a serem inseridas no banco de dados.
            usuario.NomeUsuario = "teste123";
            usuario.Senha = "abc1234";
            usuario.TipoUsuario = "A";

            // Executa a função Inserir Usuário e retorna verdadeiro se o processo foi concluido sem erros.
            bool retorno = usuario.InserirUsuario();

            // Testa se o retorno da função Inserir Usuários é verdadeiro.
            // Se for verdadeiro o teste passa, se for falso o teste é invalidado.
            Assert.True(retorno);

            // ******
            // NECESSARIO DELETAR O USUÁRIO CRIADO PARA NÃO GERAR ERROS DE USUÁRIO DUPLICADO
            // ESSE ERRO OCORRO POIS O CAMPO vallez.usuarios.usuario ESTA COMO 'unique'
            // ESSA OPÇÃO DIZ AO BANCO QUE ESSE CAMPO usuario *NÃO* PODE SE REPETIR.
            // ******

        }

    }
}
