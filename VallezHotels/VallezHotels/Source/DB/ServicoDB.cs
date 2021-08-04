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
    class ServicoDB : IDBComandosBasicosEntidade<Servico>
    {

        private readonly IDBConexao _conn;

        public ServicoDB(IDBConexao conn)
        {
            _conn = conn;
        }

        private Servico PreencherServico(DbDataReader reader)
        {
            Servico s = new Servico();
            s.Id = int.Parse(reader["id_servico"].ToString());
            s.Uuid = reader["uuid_servico"].ToString();
            s.Descricao = reader["descricao"].ToString();
            s.Valor = double.Parse(reader["valor"].ToString());
            s.CreatedAt = DateTime.Parse(reader["created_at"].ToString());
            s.UpdatedAt = DateTime.Parse(reader["updated_At"].ToString());

            return s;
        
        }


        public Servico Atualizar(Servico servico)
        {
            try
            {
                using (var conn = _conn.Conexao())
                {
                    conn.Open();

                    using (var update = conn.CreateCommand())
                    {

                        update.CommandText = "UPDATE vallez.servicos SET descricao=@DESCRICAO, valor=@VALOR, updated_at=now() WHERE id_servico=@ID;";
                        update.AddParameter("@ID", servico.Id);
                        update.AddParameter("@DESCRICAO", servico.Descricao);
                        update.AddParameter("@VALOR", servico.Valor, System.Data.DbType.Double);

                        int affectedRows = update.ExecuteNonQuery();

                        if (affectedRows >= 1)
                        {
                            return servico;
                        }
                        else
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

        public Servico BuscarPeloID(int id)
        {
            try
            {
                using (var conn = _conn.Conexao())
                {
                    conn.Open();

                    using (var select = conn.CreateCommand())
                    {

                        select.CommandText = "SELECT * FROM vallez.servicos WHERE id_servico = @ID";
                        select.AddParameter("@ID", id, System.Data.DbType.Int32);


                        var reader = select.ExecuteReader();

                        if (reader.Read())
                        {
                            Servico s = this.PreencherServico(reader);
                            return s;
                        }
                        else
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

        public List<Servico> BuscarTodos()
        {
            try
            {
                using (var conn = _conn.Conexao())
                {
                    conn.Open();

                    using (var select = conn.CreateCommand())
                    {

                        select.CommandText = "SELECT * FROM vallez.servicos";


                        var reader = select.ExecuteReader();

                        List<Servico> lista = new List<Servico>();
                        while (reader.Read())
                        {
                            Servico s = this.PreencherServico(reader);
                            lista.Add(s);
                        }

                        return lista;

                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Deletar(Servico servico)
        {
            try
            {
                using (var conn = _conn.Conexao())
                {
                    conn.Open();

                    using (var delete = conn.CreateCommand())
                    {

                        delete.CommandText = "DELETE FROM vallez.servicos WHERE id_servico = @ID";
                        delete.AddParameter("@ID", servico.Id, System.Data.DbType.Int32);


                        int affectedRows = delete.ExecuteNonQuery();

                        return (affectedRows == 1) ? true : false;
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Servico Inserir(Servico servico)
        {
            try
            {
                using (var conn = _conn.Conexao())
                {
                    conn.Open();

                    using (var insert = conn.CreateCommand())
                    {

                        insert.CommandText = "INSERT INTO vallez.servicos (uuid_servico, descricao, valor, created_at, updated_at) VALUES(vallez.uuid_generate_v4(), @DESCRICAO, @VALOR, now(), now()) returning *";
                        insert.AddParameter("@DESCRICAO", servico.Descricao);
                        insert.AddParameter("@VALOR", servico.Valor, System.Data.DbType.Double);

                        var reader = insert.ExecuteReader();

                        if (reader.Read())
                        {
                            Servico s = this.PreencherServico(reader);
                            return s;
                        }else
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
