using System;
using System.Data.Common;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VallezHotels.Source.DB.Interfaces;
using VallezHotels.Source.Entidades;

namespace VallezHotels.Source.DB
{
    class FuncionarioDB : IDBComandosBasicosEntidade<Funcionario>
    {
        private readonly IDBConexao _conn;

        public FuncionarioDB(IDBConexao conn)
        {
            _conn = conn;
        }

        public Funcionario PreencherFuncionario(DbDataReader reader)
        {

            Funcionario f = new Funcionario();
            f.IdFuncionario = int.Parse(reader["id_funcionario"].ToString());
            f.UuidFuncionario = reader["uuid_funcionario"].ToString();
            f.IdPessoa = int.Parse(reader["id_pessoa"].ToString());
            f.Usuario.Id = int.Parse(reader["id_usuario"].ToString());
            f.CTPS = reader["ctps"].ToString();
            f.Admissao = DateTime.Parse(reader["data_admissao"].ToString());
            f.CreatedAtFuncionario = DateTime.Parse(reader["created_at"].ToString());
            f.UpdatedAtFuncionario = DateTime.Parse(reader["updated_at"].ToString());
            return f;
        }

        public Funcionario Atualizar(Funcionario funcionario)
        {
            try
            {
                using (var conn = _conn.Conexao())
                {
                    conn.Open();

                    using (var update = conn.CreateCommand())
                    {
                        update.CommandText = "UPDATE vallez.funcionarios SET ctps=@CTPS, data_admissao=@ADMISSAO, updated_at=now() WHERE id_funcionario=@ID; ";
                        update.AddParameter("@ID", funcionario.IdFuncionario, System.Data.DbType.Int32);
                        update.AddParameter("@CTPS", funcionario.CTPS);
                        update.AddParameter("@ADMISSAO", funcionario.Admissao,System.Data.DbType.Date);

                        var affectedRows = (int) update.ExecuteNonQuery();

                        if (affectedRows == 1)
                        {
                            return funcionario;
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

        public Funcionario BuscarPeloID(int id)
        {
            try
            {
                using (var conn = _conn.Conexao())
                {
                    conn.Open();

                    using (var select = conn.CreateCommand())
                    {
                        select.CommandText = "SELECT * FROM vallez.funcionarios WHERE id_funcionario = @ID";
                        select.AddParameter("@ID", id,System.Data.DbType.Int32);

                        var reader = select.ExecuteReader();
                        if (reader.Read())
                        {
                            Funcionario f = this.PreencherFuncionario(reader);

                            return f;
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

        public List<Funcionario> BuscarTodos()
        {
            try
            {
                using (var conn = _conn.Conexao())
                {
                    conn.Open();
                    using (var select = conn.CreateCommand())
                    {
                        select.CommandText = "SELECT * FROM vallez.funcionarios;";

                        var reader = select.ExecuteReader();

                        List<Funcionario> funcionarios = new List<Funcionario>();
                        while (reader.Read())
                        {
                            Funcionario f = this.PreencherFuncionario(reader);
                            funcionarios.Add(f);
                        }

                        return funcionarios;

                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Deletar(Funcionario funcionario)
        {
            try
            {
                using (var conn = _conn.Conexao())
                {
                    conn.Open();

                    using (var delete = conn.CreateCommand())
                    {
                        delete.CommandText = "DELETE FROM vallez.funcionarios WHERE id_funcionario = @ID";
                        delete.AddParameter("@ID", funcionario.IdFuncionario, System.Data.DbType.Int32);

                        int affectedRows = (int) delete.ExecuteNonQuery();

                        return (affectedRows >= 1) ? true : false;
                    
                    }

                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Funcionario Inserir(Funcionario funcionario)
        {
            try
            {
                using (var conn = _conn.Conexao())
                {
                    conn.Open();
                    using (var insert = conn.CreateCommand())
                    {
                        insert.CommandText = "INSERT INTO vallez.funcionarios (uuid_funcionario, id_pessoa, id_usuario, ctps, data_admissao, created_at, updated_at) VALUES(vallez.uuid_generate_v4(), @PESSOA, @USUARIO, @CTPS, @ADMISSAO, now(), now()) returning *;";
                        insert.AddParameter("@PESSOA", funcionario.IdPessoa, System.Data.DbType.Int32);
                        insert.AddParameter("@USUARIO", funcionario.Usuario.Id, System.Data.DbType.Int32);
                        insert.AddParameter("@CTPS", funcionario.CTPS);
                        insert.AddParameter("@ADMISSAO", funcionario.Admissao, System.Data.DbType.Date);

                        var reader = insert.ExecuteReader();

                        if (reader.Read())
                        {
                            Funcionario f = this.PreencherFuncionario(reader);                            

                            return f;

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
