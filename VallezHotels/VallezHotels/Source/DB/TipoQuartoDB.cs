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
    class TipoQuartoDB : IDBComandosBasicosEntidade<TipoQuarto>
    {

        private readonly IDBConexao _conn;

        public TipoQuartoDB(IDBConexao conn)
        {
            _conn = conn;
        }

        private TipoQuarto PreencherTipoQuarto(DbDataReader reader)
        {
            TipoQuarto t = new TipoQuarto();
            t.Id = int.Parse(reader["id_tipo"].ToString());
            t.Uuid = reader["id_tipo"].ToString();
            t.Descricao = reader["descricao"].ToString();
            t.CreatedAt = DateTime.Parse(reader["created_at"].ToString());
            t.UpdatedAt = DateTime.Parse(reader["updated_At"].ToString());

            return t;

        }

        public TipoQuarto Atualizar(TipoQuarto tipoQuarto)
        {
            try
            {
                using (var conn = _conn.Conexao())
                {
                    conn.Open();

                    using (var update = conn.CreateCommand())
                    {

                        update.CommandText = "UPDATE vallez.tipo_quarto SET descricao=@DESCRICAO, updated_at=now() WHERE id_tipo=@ID;";
                        update.AddParameter("@ID", tipoQuarto.Id);
                        update.AddParameter("@DESCRICAO", tipoQuarto.Descricao);

                        int affectedRows = update.ExecuteNonQuery();

                        if (affectedRows >= 1)
                        {
                            return tipoQuarto;
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

        public TipoQuarto BuscarPeloID(int id)
        {
            try
            {
                using (var conn = _conn.Conexao())
                {
                    conn.Open();

                    using (var select = conn.CreateCommand())
                    {

                        select.CommandText = "SELECT * FROM vallez.tipo_quarto WHERE id_tipo = @ID";
                        select.AddParameter("@ID", id, System.Data.DbType.Int32);


                        var reader = select.ExecuteReader();

                        if (reader.Read())
                        {
                            TipoQuarto t = this.PreencherTipoQuarto(reader);
                            return t;
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

        public List<TipoQuarto> BuscarTodos()
        {
            try
            {
                using (var conn = _conn.Conexao())
                {
                    conn.Open();

                    using (var select = conn.CreateCommand())
                    {

                        select.CommandText = "SELECT * FROM vallez.tipo_quarto";


                        var reader = select.ExecuteReader();

                        List<TipoQuarto> lista = new List<TipoQuarto>();
                        while (reader.Read())
                        {
                            TipoQuarto t = this.PreencherTipoQuarto(reader);
                            lista.Add(t);
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

        public bool Deletar(TipoQuarto tipoQuarto)
        {
            try
            {
                using (var conn = _conn.Conexao())
                {
                    conn.Open();

                    using (var delete = conn.CreateCommand())
                    {

                        delete.CommandText = "DELETE FROM vallez.tipo_quarto WHERE id_tipo = @ID";
                        delete.AddParameter("@ID", tipoQuarto.Id, System.Data.DbType.Int32);


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

        public TipoQuarto Inserir(TipoQuarto tipoQuarto)
        {
            try
            {
                using (var conn = _conn.Conexao())
                {
                    conn.Open();

                    using (var insert = conn.CreateCommand())
                    {

                        insert.CommandText = "INSERT INTO vallez.tipo_quarto (uuid_tipo, descricao, created_at, updated_at) VALUES(vallez.uuid_generate_v4(), @DESCRICAO, now(), now()) returning *";
                        insert.AddParameter("@DESCRICAO", tipoQuarto.Descricao);

                        var reader = insert.ExecuteReader();

                        if (reader.Read())
                        {
                            TipoQuarto t = this.PreencherTipoQuarto(reader);
                            return t;
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

        public TipoQuarto BuscarPeloNome(string nome)
        {
            try
            {
                using (var conn = _conn.Conexao())
                {
                    conn.Open();

                    using (var select = conn.CreateCommand())
                    {

                        select.CommandText = "SELECT * FROM vallez.tipo_quarto WHERE descricao LIKE @DESCRICAO";
                        select.AddParameter("@DESCRICAO", nome);


                        var reader = select.ExecuteReader();

                        if (reader.Read())
                        {
                            TipoQuarto t = this.PreencherTipoQuarto(reader);
                            return t;
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


    }
}
