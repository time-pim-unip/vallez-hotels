using System;
using System.Data.Common;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VallezHotels.Source.DB.Interfaces;
using Npgsql;
using System.Data;

namespace VallezHotels.Source.DB.Conexao
{
    public class PGConexao : IDBConexao
    {

        private string StringConexao;

        public PGConexao()
        {
            StringConexao = "Host=127.0.0.1;Username=vallez;Password=#vallez123@;Database=db_vallez";
        }

        public DbConnection Conexao()
        {
            try
            {
                return new NpgsqlConnection(StringConexao);
                                
            }
            catch (NpgsqlException e)
            {
                throw new NpgsqlException("CONNECTION: " + e.Message);
            }
        }
    }
}
