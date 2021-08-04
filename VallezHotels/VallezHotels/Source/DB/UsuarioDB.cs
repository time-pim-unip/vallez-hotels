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
            try
            {
                using (var conn = _conn.Conexao())
                {
                    conn.Open();
                    using (var update = conn.CreateCommand())
                    {

                        update.CommandText = "UPDATE vallez.usuarios SET usuario = @USUARIO, senha = @SENHA, tipo_usuario = @TIPO_USUARIO, status = @STATUS, updated_at = now() where id_usuario = @ID;";
                        update.AddParameter("@ID", usuario.Id, DbType.Int32);
                        update.AddParameter("@USUARIO", usuario.NomeUsuario);
                        update.AddParameter("@SENHA", usuario.Senha, DbType.String);
                        update.AddParameter("@TIPO_USUARIO", usuario.TipoUsuario);
                        update.AddParameter("@STATUS", usuario.Status);

                        var updatedRows = (int)update.ExecuteNonQuery();

                        if (updatedRows > 0)
                        {
                            return usuario;
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
            try
            {
                using (var conn = _conn.Conexao())
                {
                    conn.Open();

                    using (var select =  conn.CreateCommand())
                    {
                        select.CommandText = "SELECT * FROM vallez.usuarios;";
                        var reader = select.ExecuteReader();

                        List<Usuario> usuarios = new List<Usuario>();
                        while (reader.Read())
                        {
                            Usuario u = this.PreencherUsuario(reader);
                            usuarios.Add(u);

                        }

                        return usuarios;

                    }

                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Deletar(Usuario usuario)
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

                        int affectedRows =  (int) delete.ExecuteNonQuery();

                        return (affectedRows >= 1) ? true : false;

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

        public Usuario BuscarUsuarioESenha(string usuario, string senha)
        {
            try
            {

                using (var conn = _conn.Conexao())
                {
                    conn.Open();

                    using (var select = conn.CreateCommand())
                    {

                        select.CommandText = "SELECT * FROM vallez.usuarios WHERE usuario=@USUARIO AND senha=@SENHA;";
                        select.AddParameter("@USUARIO", usuario);
                        select.AddParameter("@SENHA", senha);

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


    }
}
