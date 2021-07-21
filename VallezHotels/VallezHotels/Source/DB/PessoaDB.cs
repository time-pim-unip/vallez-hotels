using System;
using System.Data.Common;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VallezHotels.Source.Entidades;
using VallezHotels.Source.DB.Interfaces;

namespace VallezHotels.Source.DB
{
    class PessoaDB : IDBComandosBasicosEntidade<Pessoa>
    {
        private readonly IDBConexao _conn;

        public PessoaDB(IDBConexao conn)
        {
            _conn = conn;
        }

        public Pessoa PreencherPessoa(DbDataReader reader)
        {
            Pessoa p = new Pessoa();
            p.IdPessoa = int.Parse(reader["id_pessoa"].ToString());
            p.UuidPessoa = reader["uuid_pessoa"].ToString();
            p.Nome = reader["nome"].ToString();
            p.DataNascimento = DateTime.Parse(reader["data_nascimento"].ToString());
            p.Cpf = reader["cpf"].ToString();
            p.RG = reader["rg"].ToString();
            p.Email = reader["email"].ToString();
            p.Telefone = reader["telefone"].ToString();
            p.Celular = reader["celular"].ToString();
            p.CreatedAtPessoa = DateTime.Parse(reader["created_at"].ToString());
            p.UpdatedAtPessoa = DateTime.Parse(reader["updated_at"].ToString());

            return p;
        }

        public Pessoa Atualizar(Pessoa pessoa)
        {
            try
            {
                using (var conn = _conn.Conexao())
                {
                    conn.Open();

                    using (var update = conn.CreateCommand())
                    {
                        update.CommandText = "UPDATE vallez.pessoas SET nome=@NOME, data_nascimento=@NASCIMENTO, cpf=@CPF, rg=@RG, email=@EMAIL, telefone=@TELEFONE, celular=@CELULAR, updated_at=now() WHERE id_pessoa=@ID;";
                        update.AddParameter("@ID", pessoa.IdPessoa, System.Data.DbType.Int32);
                        update.AddParameter("@NOME", pessoa.Nome);
                        update.AddParameter("@NASCIMENTO", pessoa.DataNascimento, System.Data.DbType.Date);
                        update.AddParameter("@CPF", pessoa.Cpf);
                        update.AddParameter("@RG", pessoa.RG);
                        update.AddParameter("@EMAIL", pessoa.Email);
                        update.AddParameter("@TELEFONE", pessoa.Telefone);
                        update.AddParameter("@CELULAR", pessoa.Celular);

                        int updatedRows = (int) update.ExecuteNonQuery();

                        if (updatedRows == 1)
                        {
                            return pessoa;
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

        public Pessoa BuscarPeloID(int id)
        {
            try
            {
                using (var conn = _conn.Conexao())
                {
                    conn.Open();

                    using (var select = conn.CreateCommand())
                    {
                        select.CommandText = "SELECT * FROM vallez.pessoas WHERE id_pessoa = @ID";
                        select.AddParameter("@ID", id, System.Data.DbType.Int32);

                        var reader = select.ExecuteReader();

                        if (reader.Read())
                        {
                            Pessoa p = this.PreencherPessoa(reader);
                            return p;
                        } else
                        {
                            return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Pessoa> BuscarTodos()
        {
            try
            {

                using (var conn = _conn.Conexao())
                {
                    conn.Open();

                    using (var select = conn.CreateCommand())
                    {
                        select.CommandText = "SELECT * FROM vallez.pessoas;";

                        var reader = select.ExecuteReader();

                        List<Pessoa> pessoas = new List<Pessoa>();
                        while (reader.Read())
                        {
                            Pessoa p = this.PreencherPessoa(reader);
                            pessoas.Add(p);
                        }

                        return pessoas;
                    }
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Deletar(Pessoa pessoa)
        {
            try
            {
                using (var conn = _conn.Conexao())
                {
                    conn.Open();

                    using (var delete = conn.CreateCommand()) 
                    {
                        delete.CommandText = "DELETE FROM vallez.pessoas WHERE id_pessoa = @ID;";
                        delete.AddParameter("@ID", pessoa.IdPessoa, System.Data.DbType.Int32);

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

        public Pessoa Inserir(Pessoa pessoa)
        {
            try
            {
                using (var conn = _conn.Conexao())
                {
                    conn.Open();

                    using (var insert = conn.CreateCommand())
                    {
                        insert.CommandText = "INSERT INTO vallez.pessoas (uuid_pessoa, nome, data_nascimento, cpf, rg, email, telefone, celular, created_at, updated_at) VALUES(vallez.uuid_generate_v4(), @NOME, @NASCIMENTO, @CPF, @RG, @EMAIL, @TELEFONE, @CELULAR, now(), now()) returning *;";
                        insert.AddParameter("@NOME", pessoa.Nome);
                        insert.AddParameter("@NASCIMENTO", pessoa.DataNascimento, System.Data.DbType.Date);
                        insert.AddParameter("@CPF", pessoa.Cpf);
                        insert.AddParameter("@RG", pessoa.RG);
                        insert.AddParameter("@EMAIL", pessoa.Email);
                        insert.AddParameter("@TELEFONE", pessoa.Telefone);
                        insert.AddParameter("@CELULAR", pessoa.Celular);

                        var reader = insert.ExecuteReader();

                        if (reader.Read())
                        {
                            Pessoa p = this.PreencherPessoa(reader);
                            return p;
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
