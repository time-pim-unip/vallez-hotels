using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace VallezHotels.Source.Core
{
    /// <summary>
    /// Classe para abrir uma conexão com o banco de dados.
    /// </summary>
    public class ConexaoBanco
    {

        /// <summary>
        /// Função que retorna a conexão pronta para ser utilizada.
        /// 
        /// Função com a definição 'static' não precisam ter um objeto criado para serem chamadas.
        /// </summary>
        /// <returns></returns>
        public static NpgsqlConnection GetConexao()
        {
            // String de conexão com banco
            string connString = "Host=127.0.0.1;Username=vallez;Password=#vallez123@;Database=db_vallez";

            // Inicia um bloco TRY
            // Esse bloco diz ao código para TENTAR executar o código
            // casso um erro aconteça, o código preseten no bloco CATCH será executado.
            // Essa estrutura é importante para capturarmos os erros gerados pelo código e para podermos tratar eles.
            try
            {

                // Cria uma nova conexão com o banco utilizando a string de conexão
                NpgsqlConnection conn = new NpgsqlConnection(connString);

                // Abre a conexão com o banco
                conn.Open();

                // Retorna um objeto com a conexão já aberta
                return conn;

            }
            catch (NpgsqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
