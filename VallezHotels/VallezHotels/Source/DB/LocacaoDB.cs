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
    class LocacaoDB : IDBComandosBasicosEntidade<Locacao>
    {
        private readonly IDBConexao _conn;

        public LocacaoDB(IDBConexao conn)
        {
            _conn = conn;
        }

        public Locacao PreencherLocacao(DbDataReader reader)
        {
            Locacao l = new Locacao();
            l.Id = int.Parse(reader["id_locacao"].ToString());
            l.Uuid = reader["uuid_locacao"].ToString();
            l.Quarto.Id = int.Parse(reader["id_quarto"].ToString());
            l.DataEntrada = DateTime.Parse(reader["dt_entrada"].ToString());
            l.DataSaida = DateTime.Parse(reader["dt_saida"].ToString());
            //l.CheckIn = (reader["dt_checkin"].ToString() != "") ? DateTime.Parse(reader["dt_checkin"].ToString()) : new DateTime() ;
            //l.CheckOut = DateTime.Parse(reader["dt_checkout"].ToString());
            l.CreatedAt = DateTime.Parse(reader["created_at"].ToString());
            l.UpdatedAt = DateTime.Parse(reader["updated_at"].ToString());

            if (reader["dt_checkin"].ToString() != "")
            {
                l.CheckIn = DateTime.Parse(reader["dt_checkin"].ToString());
            } else
            {
                l.CheckIn = null;
            }

            if (reader["dt_checkout"].ToString() != "")
            {
                l.CheckOut = DateTime.Parse(reader["dt_checkout"].ToString());
            } else
            {
                l.CheckOut = null;
            }


            return l;
        }

        public Locacao Atualizar(Locacao locacao)
        {
            try
            {
                using (var conn = _conn.Conexao())
                {
                    conn.Open();

                    using (var update = conn.CreateCommand())
                    {
                        update.CommandText = "UPDATE vallez.locacoes SET id_quarto=@QUARTO, dt_entrada=@ENTRADA, dt_saida=@SAIDA, dt_checkin=@CHECKIN, dt_checkout=@CHECKOUT, updated_at=now() WHERE id_locacao=@ID; ";
                        update.AddParameter("@ID", locacao.Id, System.Data.DbType.Int32);
                        update.AddParameter("@QUARTO", locacao.Quarto.Id, System.Data.DbType.Int32);
                        update.AddParameter("@ENTRADA", locacao.DataEntrada, System.Data.DbType.Date);
                        update.AddParameter("@SAIDA", locacao.DataSaida, System.Data.DbType.Date);

                        if (locacao.CheckIn != null)
                        {
                            update.AddParameter("@CHECKIN", locacao.CheckIn, System.Data.DbType.DateTime);

                        }else
                        {
                            update.AddParameter("@CHECKIN", DBNull.Value, System.Data.DbType.DateTime);
                        }

                        if (locacao.CheckOut != null)
                        {

                            update.AddParameter("@CHECKOUT", locacao.CheckOut, System.Data.DbType.DateTime);

                        } else
                        {
                            update.AddParameter("@CHECKOUT", DBNull.Value, System.Data.DbType.DateTime);

                        }



                        var affectedRows = (int)update.ExecuteNonQuery();

                        if (affectedRows == 1)
                        {
                            return locacao;
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

        public Locacao BuscarPeloID(int id)
        {
            try
            {
                using (var conn = _conn.Conexao())
                {
                    conn.Open();

                    using (var select = conn.CreateCommand())
                    {
                        select.CommandText = "SELECT * FROM vallez.locacoes WHERE id_locacao = @ID";
                        select.AddParameter("@ID", id, System.Data.DbType.Int32);

                        var reader = select.ExecuteReader();
                        Locacao l = new Locacao();
                        if (reader.Read())
                        {
                            l = this.PreencherLocacao(reader);

                        }
                        return l;

                    }

                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Locacao> BuscarTodos()
        {
            try
            {
                using (var conn = _conn.Conexao())
                {
                    conn.Open();
                    using (var select = conn.CreateCommand())
                    {
                        select.CommandText = "SELECT * FROM vallez.locacoes;";

                        var reader = select.ExecuteReader();

                        List<Locacao> locacoes = new List<Locacao>();
                        while (reader.Read())
                        {
                            Locacao l = this.PreencherLocacao(reader);
                            locacoes.Add(l);
                        }

                        return locacoes;

                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Deletar(Locacao locacao)
        {
            try
            {
                using (var conn = _conn.Conexao())
                {
                    conn.Open();

                    using (var delete = conn.CreateCommand())
                    {
                        delete.CommandText = "DELETE FROM vallez.locacoes WHERE id_locacao = @ID";
                        delete.AddParameter("@ID", locacao.Id, System.Data.DbType.Int32);

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

        public Locacao Inserir(Locacao locacao)
        {
            try
            {
                using (var conn = _conn.Conexao())
                {
                    conn.Open();
                    using (var insert = conn.CreateCommand())
                    {
                        insert.CommandText = "INSERT INTO vallez.locacoes (uuid_locacao, id_quarto, dt_entrada, dt_saida, created_at, updated_at) VALUES(vallez.uuid_generate_v4(), @QUARTO, @ENTRADA, @SAIDA, now(), now()) returning *;";
                        insert.AddParameter("@QUARTO", locacao.Quarto.Id, System.Data.DbType.Int32);
                        insert.AddParameter("@ENTRADA", locacao.DataEntrada, System.Data.DbType.Date);
                        insert.AddParameter("@SAIDA", locacao.DataSaida, System.Data.DbType.Date);
                        //insert.AddParameter("@CHECKIN", locacao.CheckIn);
                        //insert.AddParameter("@CHECKOUT", locacao.CheckOut);

                        var reader = insert.ExecuteReader();

                        if (reader.Read())
                        {
                            Locacao l = this.PreencherLocacao(reader);

                            return l;

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

        public Locacao BuscarPelaDataEQuarto(Quarto q, DateTime data)
        {
            try
            {
                using (var conn = _conn.Conexao())
                {
                    conn.Open();

                    using (var select = conn.CreateCommand())
                    {

                        select.CommandText = "select * from vallez.locacoes l join vallez.disponibilidades d on (d.id_locacao = l.id_locacao) where l.id_quarto = @QUARTO and d.data = to_date(to_char(@DATA, 'yyyy-mm-dd') , 'yyyy-mm-dd');";
                        select.AddParameter("@QUARTO", q.Id, System.Data.DbType.Int32);
                        select.AddParameter("@DATA", data.Date, System.Data.DbType.Date);

                        var reader = select.ExecuteReader();

                        Locacao l = new Locacao();
                        if (reader.Read())
                        {
                            l = this.PreencherLocacao(reader);
                        }

                        return l;
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Locacao BuscarPelaDataEQuarto(Quarto q)
        {
            return this.BuscarPelaDataEQuarto(q, DateTime.Now);
        }

        public void InserirCheckin(Locacao l)
        {
            try
            {
                using (var conn = _conn.Conexao())
                {

                    conn.Open();

                    using (var update = conn.CreateCommand())
                    {

                        update.CommandText = "UPDATE vallez.locacoes SET dt_checkin = @CHECKIN WHERE id_locacao = @ID";
                        update.AddParameter("@CHECKIN", l.CheckIn.Value, System.Data.DbType.DateTime);
                        update.AddParameter("@ID", l.Id, System.Data.DbType.Int32);

                        update.ExecuteNonQuery();

                    }

                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void InserirCheckout(Locacao l)
        {
            try
            {
                using (var conn = _conn.Conexao())
                {

                    conn.Open();

                    using (var update = conn.CreateCommand())
                    {

                        update.CommandText = "UPDATE vallez.locacoes SET dt_checkout = @CHECKOUT WHERE id_locacao = @ID";
                        update.AddParameter("@CHECKOUT", l.CheckOut.Value, System.Data.DbType.DateTime);
                        update.AddParameter("@ID", l.Id, System.Data.DbType.Int32);

                        update.ExecuteNonQuery();

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
