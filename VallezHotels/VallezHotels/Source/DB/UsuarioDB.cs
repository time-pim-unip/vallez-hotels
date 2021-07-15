using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VallezHotels.Source.DB.Interfaces;
using VallezHotels.Source.Entidades;

namespace VallezHotels.Source.DB
{
    public class UsuarioDB : IDBComandosBasicosEntidade<Usuario>
    {

        private readonly IDBConexao _conn;

        public UsuarioDB(IDBConexao conn)
        {
            _conn = conn;
        }

        public Usuario PreencherUsuario(DbDataReader reader)
        {
            Usuario u = new Usuario();
            u.Id = int.Parse(reader["id_usuario"].ToString());
            u.Uuid = reader["uuid_usuario"].ToString();
            u.NomeUsuario = reader["usuario"].ToString();
            u.Senha = reader["senha"].ToString();
            u.TipoUsuario = reader["tipo_usuario"].ToString();
            u.Status = bool.Parse(reader["status"].ToString());
            u.CreatedAt = DateTime.Parse(reader["created_at"].ToString());
            u.UpdatedAt = DateTime.Parse(reader["updated_at"].ToString());

            return u;

        }

        public Usuario Atualizar(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Usuario BuscarPeloID(int id)
        {
            try
            {
                using (var conn = _conn.Conexao())
                {
                    conn.Open();

                    using (var select = conn.CreateCommand())
                    {

                        select.CommandText = "SELECT * FROM vallez.usuarios WHERE id_usuario = @ID;";
                        select.AddParameter("@ID", id, DbType.Int32);

                        var reader = select.ExecuteReader();

                        if (reader.Read())
                        {
                            Usuario u = this.PreencherUsuario(reader);              
                            return u;
                        } else
                        {
                            return null;
                        }

                    }


                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Usuario> BuscarTodos()
        {
            throw new NotImplementedException();
        }

        public void Deletar(Usuario usuario)
        {
            try
            {
                using (var conn = _conn.Conexao())
                {
                    conn.Open();

                    using (var delete = conn.CreateCommand())
                    {
                        delete.CommandText = "DELETE FROM vallez.usuarios WHERE id_usuario = @ID;";
                        delete.AddParameter("@ID", usuario.Id);

                        delete.ExecuteNonQuery();

                    }


                }
            }
            catch (Npgsql.NpgsqlException e)
            {
                throw new Exception(e.Message);
            }
        }

        public Usuario Inserir(Usuario usuario)
        {
           
            try
            {
                using (var conn = _conn.Conexao())
                {

                    conn.Open();

                    using (var insert = conn.CreateCommand())
                    {

                        insert.CommandText = "INSERT INTO vallez.usuarios (uuid_usuario, usuario, senha, tipo_usuario, status) VALUES(vallez.uuid_generate_v4(), @USUARIO, @SENHA, @TIPO_USUARIO, @STATUS) returning *; ";
                        insert.AddParameter("@USUARIO", usuario.NomeUsuario);
                        insert.AddParameter("@SENHA", usuario.Senha, DbType.String );
                        insert.AddParameter("@TIPO_USUARIO", usuario.TipoUsuario);
                        insert.AddParameter("@STATUS", usuario.Status);
                        
                        var reader = insert.ExecuteReader();

                        if (reader.Read())
                        {
                            Usuario u = this.PreencherUsuario(reader);
                            return u;
                        }else
                        {
                            return null;
                        }

                    }

                }

            }
            catch (Exception e )
            {
                throw new Exception("REPOSITORY: " + e.Message);
            }
        }

    }
}
