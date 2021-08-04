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
    class HospedagemDB : IDBComandosBasicosEntidade<Hospedagem>
    {
        private readonly IDBConexao _conn;

        public HospedagemDB(IDBConexao conn)
        {
            _conn = conn;
        }

        public Hospedagem PreencherHospedagem(DbDataReader reader)
        {
            Hospedagem h = new Hospedagem();
            h.Hospede.IdHospede = int.Parse(reader["id_hospede"].ToString());
            h.Locacao.Id = int.Parse(reader["id_locacao"].ToString());
            h.Detentor = bool.Parse(reader["detentor"].ToString());
            h.Uuid = reader["uuid_hospedagem"].ToString();
            h.CreatedAt = DateTime.Parse(reader["created_at"].ToString());
            h.UpdatedAt = DateTime.Parse(reader["updated_at"].ToString());
            return h;
        }

        public Hospedagem Atualizar(Hospedagem hospedagem)
        {
            try
            {
                using (var conn = _conn.Conexao())
                {
                    conn.Open();

                    using (var update = conn.CreateCommand())
                    {
                        update.CommandText = "UPDATE vallez.hospedagens SET id_locacao=@LOCACAO, id_hospede=@HOSPEDE, detentor=@DETENTOR, updated_at=now() WHERE id_locacao=@LOCACAO and id_hospede=@HOSPEDE; ";
                        update.AddParameter("@LOCACAO", hospedagem.Locacao.Id, System.Data.DbType.Int32);
                        update.AddParameter("@HOSPEDE", hospedagem.Hospede.IdHospede, System.Data.DbType.Int32);
                        update.AddParameter("@DETENTOR", hospedagem.Detentor, System.Data.DbType.Boolean);


                        var affectedRows = (int)update.ExecuteNonQuery();

                        if (affectedRows == 1)
                        {
                            return hospedagem;
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
        public Hospedagem BuscarPeloID(int id)
        {
            throw new Exception("Not Implemented");
        }

        public Hospedagem BuscarPeloID(int idLocacao, int idHospede)
        {
            try
            {
                using (var conn = _conn.Conexao())
                {
                    conn.Open();

                    using (var select = conn.CreateCommand())
                    {
                        select.CommandText = "SELECT * FROM vallez.hospedagens WHERE id_locacao=@LOCACAO AND id_hospede=@HOSPEDE";
                        select.AddParameter("@LOCACAO", idLocacao, System.Data.DbType.Int32);
                        select.AddParameter("@HOSPEDE", idHospede, System.Data.DbType.Int32);

                        var reader = select.ExecuteReader();
                        if (reader.Read())
                        {
                            Hospedagem h = this.PreencherHospedagem(reader);

                            return h;
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

        public List<Hospedagem> BuscarTodos()
        {
            try
            {
                using (var conn = _conn.Conexao())
                {
                    conn.Open();
                    using (var select = conn.CreateCommand())
                    {
                        select.CommandText = "SELECT * FROM vallez.hospedagens;";

                        var reader = select.ExecuteReader();

                        List<Hospedagem> hospedagems = new List<Hospedagem>();
                        while (reader.Read())
                        {
                            Hospedagem h = this.PreencherHospedagem(reader);
                            hospedagems.Add(h);
                        }

                        return hospedagems;

                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Deletar(Hospedagem hospedagem)
        {
            try
            {
                using (var conn = _conn.Conexao())
                {
                    conn.Open();

                    using (var delete = conn.CreateCommand())
                    {
                        delete.CommandText = "DELETE FROM vallez.hospedagens WHERE id_locacao=@LOCACAO AND id_hospede=@HOSPEDE";
                        delete.AddParameter("@LOCACAO", hospedagem.Locacao.Id, System.Data.DbType.Int32);
                        delete.AddParameter("@HOSPEDE", hospedagem.Hospede.IdHospede, System.Data.DbType.Int32);

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

        public Hospedagem Inserir(Hospedagem hospedagem)
        {
            try
            {
                using (var conn = _conn.Conexao())
                {
                    conn.Open();
                    using (var insert = conn.CreateCommand())
                    {
                        insert.CommandText = "INSERT INTO vallez.hospedagens (id_locacao, id_hospede, uuid_hospedagem, detentor, created_at, updated_at) VALUES(@LOCACAO, @HOSPEDE, vallez.uuid_generate_v4(), @DETENTOR, now(), now()) returning *;";
                        insert.AddParameter("@LOCACAO", hospedagem.Locacao.Id, System.Data.DbType.Int32);
                        insert.AddParameter("@HOSPEDE", hospedagem.Hospede.IdHospede, System.Data.DbType.Int32);
                        insert.AddParameter("@DETENTOR", hospedagem.Detentor, System.Data.DbType.Boolean);

                        var reader = insert.ExecuteReader();

                        if (reader.Read())
                        {
                            Hospedagem h = this.PreencherHospedagem(reader);

                            return h;

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

        public List<Hospedagem> BuscarPelaLocacao(Locacao l)
        {
            try
            {
                using (var conn = _conn.Conexao())
                {
                    conn.Open();

                    using (var select = conn.CreateCommand())
                    {
                        select.CommandText = "SELECT * FROM vallez.hospedagens WHERE id_locacao = @LOCACAO";
                        select.AddParameter("@LOCACAO", l.Id, System.Data.DbType.Int32);

                        var reader = select.ExecuteReader();
                        List <Hospedagem> list  = new List<Hospedagem>();

                        while (reader.Read())
                        {
                            Hospedagem h = this.PreencherHospedagem(reader);
                            list.Add(h);
                        }

                        return list;
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
