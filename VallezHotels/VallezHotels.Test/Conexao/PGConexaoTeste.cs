using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using VallezHotels.Source.DB.Conexao;
using VallezHotels.Source.DB.Interfaces;

namespace VallezHotels.Test.Conexao
{
    public class PGConexaoTeste
    {
        [Fact]
        public void Deve_Ser_Uma_Instancia_De_IDBConexao()
        {

            PGConexao conexao = new PGConexao();

            bool instanciaDeIDBConexao = conexao is IDBConexao ? true : false;

            Assert.True(instanciaDeIDBConexao);

        }

        [Fact]
        public void Deve_Abrir_Uma_Conexao_Com_Banco()
        {

            PGConexao conexao = new PGConexao();

            var conn = conexao.Conexao();
            conn.Open();

            string state = System.Data.ConnectionState.Open.ToString();
            Assert.Equal(state, conn.State.ToString());


        }

    }
}
