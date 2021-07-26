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
    class ServicoSolicitadoDB : IDBComandosBasicosEntidade<ServicoSolicitado>
    {
        private readonly IDBConexao _conn;

        public ServicoSolicitadoDB(IDBConexao conn)
        {
            _conn = conn;
        }

        public ServicoSolicitado PreencherServicoSolicitado(DbDataReader reader)
        {
            ServicoSolicitado ss = new ServicoSolicitado();
            ss.Id = int.Parse(reader["id_servico_solicitado"].ToString());
            ss.Uuid = reader["uuid_servico_solicitado"].ToString();
            ss.Servico.Id = int.Parse(reader["id_servico"].ToString());
            ss.Locacao.Id = int.Parse(reader["id_locacao"].ToString());
            ss.Solicitacao = DateTime.Parse(reader["data_solicitacao"].ToString());
            ss.Quantidade = int.Parse(reader["qtde_solicitacao"].ToString());
            ss.CreatedAt = DateTime.Parse(reader["created_at"].ToString());
            ss.UpdatedAt = DateTime.Parse(reader["updated_at"].ToString());
            return ss;
        }

        public ServicoSolicitado Atualizar(ServicoSolicitado servicoSolicitado)
        {
            try
            {
                using (var conn = _conn.Conexao())
                {
                    conn.Open();

                    using (var update = conn.CreateCommand())
                    {
                        update.CommandText = "UPDATE vallez.servicos_solicitados SET id_servico=@SERVICO, id_locacao=@LOCACAO, data_solicitacao=@DATA, qtde_solicitacao=@QUANTIDADE, updated_at=now() WHERE id_servico_solicitado=@ID; ";
                        update.AddParameter("@ID", servicoSolicitado.Id, System.Data.DbType.Int32);
                        update.AddParameter("@SERVICO", servicoSolicitado.Servico.Id, System.Data.DbType.Int32);
                        update.AddParameter("@LOCACAO", servicoSolicitado.Locacao.Id, System.Data.DbType.Int32);
                        update.AddParameter("@DATA", servicoSolicitado.Solicitacao, System.Data.DbType.Date);
                        update.AddParameter("@QUANTIDADE", servicoSolicitado.Quantidade, System.Data.DbType.Int32);
                        

                        var affectedRows = (int)update.ExecuteNonQuery();

                        if (affectedRows == 1)
                        {
                            return servicoSolicitado;
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

        public ServicoSolicitado BuscarPeloID(int id)
        {
            try
            {
                using (var conn = _conn.Conexao())
                {
                    conn.Open();

                    using (var select = conn.CreateCommand())
                    {
                        select.CommandText = "SELECT * FROM vallez.servicos_solicitados WHERE id_servico_solicitado = @ID";
                        select.AddParameter("@ID", id, System.Data.DbType.Int32);

                        var reader = select.ExecuteReader();
                        if (reader.Read())
                        {
                            ServicoSolicitado ss = this.PreencherServicoSolicitado(reader);

                            return ss;
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

        public List<ServicoSolicitado> BuscarTodos()
        {
            try
            {
                using (var conn = _conn.Conexao())
                {
                    conn.Open();
                    using (var select = conn.CreateCommand())
                    {
                        select.CommandText = "SELECT * FROM vallez.servicos_solicitados;";

                        var reader = select.ExecuteReader();

                        List<ServicoSolicitado> servicoSolicitados = new List<ServicoSolicitado>();
                        while (reader.Read())
                        {
                            ServicoSolicitado ss = this.PreencherServicoSolicitado(reader);
                            servicoSolicitados.Add(ss);
                        }

                        return servicoSolicitados;

                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Deletar(ServicoSolicitado servicoSolicitado)
        {
            try
            {
                using (var conn = _conn.Conexao())
                {
                    conn.Open();

                    using (var delete = conn.CreateCommand())
                    {
                        delete.CommandText = "DELETE FROM vallez.servicos_solicitados WHERE id_servico_solicitado=@ID";
                        delete.AddParameter("@ID", servicoSolicitado.Id, System.Data.DbType.Int32);

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

        public ServicoSolicitado Inserir(ServicoSolicitado servicoSolicitado)
        {
            try
            {
                using (var conn = _conn.Conexao())
                {
                    conn.Open();
                    using (var insert = conn.CreateCommand())
                    {
                        insert.CommandText = "INSERT INTO vallez.servicos_solicitados (uuid_servico_solicitado, id_servico, id_locacao, data_solicitacao, qtde_solicitacao, created_at, updated_at) VALUES(vallez.uuid_generate_v4(), @SERVICO, @LOCACAO, @DATA, @QUANTIDADE, now(), now()) returning *;";
                        insert.AddParameter("@SERVICO", servicoSolicitado.Servico.Id, System.Data.DbType.Int32);
                        insert.AddParameter("@LOCACAO", servicoSolicitado.Locacao.Id, System.Data.DbType.Int32);
                        insert.AddParameter("@DATA", servicoSolicitado.Solicitacao, System.Data.DbType.Date);
                        insert.AddParameter("@QUANTIDADE", servicoSolicitado.Quantidade, System.Data.DbType.Int32);

                        var reader = insert.ExecuteReader();

                        if (reader.Read())
                        {
                            ServicoSolicitado ss = this.PreencherServicoSolicitado(reader);

                            return ss;

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
