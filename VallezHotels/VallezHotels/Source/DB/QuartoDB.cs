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
    class QuartoDB : IDBComandosBasicosEntidade<Quarto>
    {
        private readonly IDBConexao _conn;

        public QuartoDB(IDBConexao conn)
        {
            _conn = conn;
        }

        public Quarto PreencherQuarto(DbDataReader reader)
        {
            Quarto q = new Quarto();
            q.Id = int.Parse(reader["id_quarto"].ToString());
            q.Uuid = reader["uuid_quarto"].ToString();
            q.Descricao = reader["descricao"].ToString();
            q.TipoQuarto.Id = int.Parse(reader["id_tipo_quarto"].ToString());
            q.Bloco = reader["bloco"].ToString();
            q.Numero = int.Parse(reader["numero"].ToString());
            q.QuantidadeBanheiros = int.Parse(reader["qtde_banheiros"].ToString());
            q.QuantidadeCamas = int.Parse(reader["qtde_camas"].ToString());
            q.ValorDiaria = double.Parse(reader["valor_diaria"].ToString());
            q.CreatedAt = DateTime.Parse(reader["created_at"].ToString());
            q.UpdatedAt = DateTime.Parse(reader["updated_at"].ToString());
            return q;
        }

        public Quarto Atualizar(Quarto quarto)
        {
            try
            {
                using (var conn = _conn.Conexao())
                {
                    conn.Open();

                    using (var update = conn.CreateCommand())
                    {
                        update.CommandText = "UPDATE vallez.quartos SET descricao=@DESCRICAO, id_tipo_quarto=@TIPOQUARTO, bloco=@BLOCO, numero=@NUMERO, qtde_banheiros=@QTDEBANHEIROS, qtde_camas=@QTDECAMAS, valor_diaria=@VALORDIARIA, updated_at=now() WHERE id_quarto=@ID; ";
                        update.AddParameter("@ID", quarto.Id, System.Data.DbType.Int32);
                        update.AddParameter("@DESCRICAO", quarto.Descricao);
                        update.AddParameter("@TIPOQUARTO", quarto.TipoQuarto.Id, System.Data.DbType.Int32);
                        update.AddParameter("@BLOCO", quarto.Bloco);
                        update.AddParameter("@NUMERO", quarto.Numero, System.Data.DbType.Int32);
                        update.AddParameter("@QTDEBANHEIROS", quarto.QuantidadeBanheiros, System.Data.DbType.Int32);
                        update.AddParameter("@QTDECAMAS", quarto.QuantidadeCamas, System.Data.DbType.Int32);
                        update.AddParameter("@VALORDIARIA", quarto.ValorDiaria, System.Data.DbType.Double);

                        var affectedRows = (int)update.ExecuteNonQuery();

                        if (affectedRows == 1)
                        {
                            return quarto;
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

        public Quarto BuscarPeloID(int id)
        {
            try
            {
                using (var conn = _conn.Conexao())
                {
                    conn.Open();

                    using (var select = conn.CreateCommand())
                    {
                        select.CommandText = "SELECT * FROM vallez.quartos WHERE id_quarto = @ID";
                        select.AddParameter("@ID", id, System.Data.DbType.Int32);

                        var reader = select.ExecuteReader();
                        if (reader.Read())
                        {
                            Quarto q = this.PreencherQuarto(reader);

                            return q;
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

        public List<Quarto> BuscarTodos()
        {
            try
            {
                using (var conn = _conn.Conexao())
                {
                    conn.Open();
                    using (var select = conn.CreateCommand())
                    {
                        select.CommandText = "SELECT * FROM vallez.quartos;";

                        var reader = select.ExecuteReader();

                        List<Quarto> quartos = new List<Quarto>();
                        while (reader.Read())
                        {
                            Quarto q = this.PreencherQuarto(reader);
                            quartos.Add(q);
                        }

                        return quartos;

                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Deletar(Quarto quarto)
        {
            try
            {
                using (var conn = _conn.Conexao())
                {
                    conn.Open();

                    using (var delete = conn.CreateCommand())
                    {
                        delete.CommandText = "DELETE FROM vallez.quartos WHERE id_quarto = @ID";
                        delete.AddParameter("@ID", quarto.Id, System.Data.DbType.Int32);

                        int affectedRows = (int)delete.ExecuteNonQuery();

                        return (affectedRows >= 1) ? true : false;

                    }

                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Quarto Inserir(Quarto quarto)
        {
            try
            {
                using (var conn = _conn.Conexao())
                {
                    conn.Open();
                    using (var insert = conn.CreateCommand())
                    {
                        insert.CommandText = "INSERT INTO vallez.quartos (uuid_quarto, descricao, id_tipo_quarto, bloco, numero, qtde_banheiros, qtde_camas, valor_diaria, created_at, updated_at) VALUES(vallez.uuid_generate_v4(), @DESCRICAO, @TIPOQUARTO, @BLOCO, @NUMERO, @QTDEBANHEIROS, @QTDECAMAS, @VALORDIARIA, now(), now()) returning *;";
                        insert.AddParameter("@DESCRICAO", quarto.Descricao.ToString(), System.Data.DbType.String);
                        insert.AddParameter("@TIPOQUARTO", quarto.TipoQuarto.Id, System.Data.DbType.Int32);
                        insert.AddParameter("@BLOCO", quarto.Bloco);
                        insert.AddParameter("@NUMERO", quarto.Numero, System.Data.DbType.Int32);
                        insert.AddParameter("@QTDEBANHEIROS", quarto.QuantidadeBanheiros, System.Data.DbType.Int32);
                        insert.AddParameter("@QTDECAMAS", quarto.QuantidadeCamas, System.Data.DbType.Int32);
                        insert.AddParameter("@VALORDIARIA", quarto.ValorDiaria, System.Data.DbType.Double);

                        var reader = insert.ExecuteReader();

                        if (reader.Read())
                        {
                            Quarto q = this.PreencherQuarto(reader);

                            return q;

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
