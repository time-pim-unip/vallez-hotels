using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VallezHotels.Source.DB.Interfaces
{
    public interface IDBConexao
    {
        DbConnection Conexao();
    }
}
