using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VallezHotels.Source.DB;
using VallezHotels.Source.DB.Conexao;
using VallezHotels.Source.DB.Exceptions;
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

        public void DeletarUsuario(Usuario u)
        {
            try
            {
                if (!(u is Usuario))
                {
                    throw new ArgumentException("Objeto não é do tipo Usuario, impossivel fazer a exclusão");
                }

                if (u == null)
                {
                    throw new ArgumentException("Objeto não pode ser nulo, impossivel fazer a exclusão");
                }

                _db.Deletar(u);

                u = null;
            }
            catch (Exception e)
            {
                throw new Exception("SERVICE: " + e.Message);
            }
        }

        public Usuario BuscarPeloId(int id)
        {
            try
            {

                if (!(id > 0))
                {
                    throw new ArgumentException("Id deve ser maior que zero para realizar uma busca");
                }

                Usuario u = _db.BuscarPeloID(id);
                
                if (u == null)
                {
                    throw new NullReturnException($"A consulta não retornou nenhum valor para os parametros informados. '{nameof(id)}:{id.ToString()}'");
                }

                return u;

            }
            catch (NullReturnException e)
            {
                throw new NullReturnException(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception("SERVICE: " + e.Message);
            }
        }


        public Usuario EditarUsuario(Usuario usuario)
        {
            try
            {

                Usuario u = _db.Atualizar(usuario);

                if (u == null)
                {
                    throw new NullReturnException("A atualização retornou um objeto nullo");
                } else
                {
                    return u;
                }

            }
            catch (NullReturnException e)
            {
                throw new NullReturnException(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Usuario> BuscarTodos()
        {
            try
            {
                List<Usuario> lista = _db.BuscarTodos();
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
