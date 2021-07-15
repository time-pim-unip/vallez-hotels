using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VallezHotels.Source.DB;
using VallezHotels.Source.DB.Conexao;
using VallezHotels.Source.Entidades;

namespace VallezHotels.Source.Servicos
{
    public class UsuarioServico
    {

        private readonly UsuarioDB _db;

        public UsuarioServico()
        {

            _db = new UsuarioDB(new PGConexao());

        }

        public Usuario InserirUsuario(Usuario usuario)
        {
            try
            {
                Usuario u = _db.Inserir(usuario);
                return u;
            }
            catch (Exception e)
            {
                throw new Exception("SERVICE: " + e.Message);
            }
        }

    }
}
