using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace VallezHotels.Source.Core
{
    public class ConexaoBanco
    {

        public static NpgsqlConnection GetConexao()
        {
            string connString = "Host=127.0.0.1;Username=vallez;Password=#vallez123@;Database=db_vallez";
            try
            {
                NpgsqlConnection conn = new NpgsqlConnection(connString);
                conn.Open();

                return conn;

            }
            catch (NpgsqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
