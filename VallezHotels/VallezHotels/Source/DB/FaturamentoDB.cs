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
    class FaturamentoDB : IDBComandosBasicosEntidade<Faturamento>
    {
        private readonly IDBConexao _conn;

        public FaturamentoDB(IDBConexao conn)
        {
            _conn = conn;
        }

        public Faturamento PreencherFaturamento(DbDataReader reader)
        {
            Faturamento f = new Faturamento();
            f.Id = int.Parse(reader["id_faturamento"].ToString());
            f.Uuid = reader["uuid_faturamento"].ToString();
            f.Locacao.Id = int.Parse(reader["id_locacao"].ToString());
            f.ValorTotal = double.Parse(reader["valor_total"].ToString());
            f.ValorDesconto = double.Parse(reader["valor_desconto"].ToString());
            f.ValorPago = double.Parse(reader["valor_pago"].ToString());
            f.CreatedAt = DateTime.Parse(reader["created_at"].ToString());
            f.UpdatedAt = DateTime.Parse(reader["updated_at"].ToString());
            return f;
        }

        public Faturamento Atualizar(Faturamento faturamento)
        {
            try
            {
                using (var conn = _conn.Conexao())
                {
                    conn.Open();

                    using (var update = conn.CreateCommand())
                    {
                        update.CommandText = "UPDATE vallez.faturamentos SET id_locacao=@LOCACAO, valor_total=@TOTAL, valor_desconto=@DESCONTO, valor_pago=@PAGO, updated_at=now() WHERE id_faturamento=@ID; ";
                        update.AddParameter("@ID", faturamento.Id, System.Data.DbType.Int32);
                        update.AddParameter("@LOCACAO", faturamento.Locacao.Id, System.Data.DbType.Int32);
                        update.AddParameter("@TOTAL", faturamento.ValorTotal, System.Data.DbType.Double);
                        update.AddParameter("@DESCONTO", faturamento.ValorDesconto, System.Data.DbType.Double);
                        update.AddParameter("@PAGO", faturamento.ValorPago, System.Data.DbType.Double);

                        var affectedRows = (int)update.ExecuteNonQuery();

                        if (affectedRows == 1)
                        {
                            return faturamento;
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

        public Faturamento BuscarPeloID(int id)
        {
            try
            {
                using (var conn = _conn.Conexao())
                {
                    conn.Open();

                    using (var select = conn.CreateCommand())
                    {
                        select.CommandText = "SELECT * FROM vallez.faturamentos WHERE id_faturamento = @ID";
                        select.AddParameter("@ID", id, System.Data.DbType.Int32);

                        var reader = select.ExecuteReader();
                        if (reader.Read())
                        {
                            Faturamento f = this.PreencherFaturamento(reader);

                            return f;
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

        public List<Faturamento> BuscarTodos()
        {
            try
            {
                using (var conn = _conn.Conexao())
                {
                    conn.Open();
                    using (var select = conn.CreateCommand())
                    {
                        select.CommandText = "SELECT * FROM vallez.faturamentos;";

                        var reader = select.ExecuteReader();

                        List<Faturamento> faturamentos = new List<Faturamento>();
                        while (reader.Read())
                        {
                            Faturamento f = this.PreencherFaturamento(reader);
                            faturamentos.Add(f);
                        }

                        return faturamentos;

                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Deletar(Faturamento faturamento)
        {
            try
            {
                using (var conn = _conn.Conexao())
                {
                    conn.Open();

                    using (var delete = conn.CreateCommand())
                    {
                        delete.CommandText = "DELETE FROM vallez.faturamentos WHERE id_faturamento = @ID";
                        delete.AddParameter("@ID", faturamento.Id, System.Data.DbType.Int32);

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

        public Faturamento Inserir(Faturamento faturamento)
        {
            try
            {
                using (var conn = _conn.Conexao())
                {
                    conn.Open();
                    using (var insert = conn.CreateCommand())
                    {
                        insert.CommandText = "INSERT INTO vallez.faturamentos (uuid_faturamento, id_locacao, valor_total, valor_desconto, valor_pago, created_at, updated_at) VALUES(vallez.uuid_generate_v4(), @LOCACAO, @TOTAL, @DESCONTO, @PAGO, now(), now()) returning *;";
                        insert.AddParameter("@LOCACAO", faturamento.Locacao.Id, System.Data.DbType.Int32);
                        insert.AddParameter("@TOTAL", faturamento.ValorTotal, System.Data.DbType.Double);
                        insert.AddParameter("@DESCONTO", faturamento.ValorDesconto, System.Data.DbType.Double);
                        insert.AddParameter("@PAGO", faturamento.ValorPago, System.Data.DbType.Double);

                        var reader = insert.ExecuteReader();

                        if (reader.Read())
                        {
                            Faturamento f = this.PreencherFaturamento(reader);

                            return f;

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
