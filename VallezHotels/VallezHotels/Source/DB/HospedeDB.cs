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
    class HospedeDB : IDBComandosBasicosEntidade<Hospede>
    {
        private readonly IDBConexao _conn;

        public HospedeDB(IDBConexao conn)
        {
            _conn = conn;
        }

        public Hospede PreencherHospede(DbDataReader reader)
        {

            Hospede h= new Hospede();
            h.IdHospede = int.Parse(reader["id_hospede"].ToString());
            h.UuidHospede = reader["uuid_hospede"].ToString();
            h.IdPessoa = int.Parse(reader["id_pessoa"].ToString());
            h.Usuario.Id = int.Parse(reader["id_usuario"].ToString());
            h.Consentimento = bool.Parse(reader["consentimento_pais"].ToString());
            h.CreatedAtHospede = DateTime.Parse(reader["created_at"].ToString());
            h.UpdatedAtHospede = DateTime.Parse(reader["updated_at"].ToString());
            return h;
        }

        public Hospede Atualizar(Hospede hospede)
        {
            try
            {
                using (var conn = _conn.Conexao())
                {
                    conn.Open();

                    using (var update = conn.CreateCommand())
                    {
                        update.CommandText = "UPDATE vallez.hospedes SET consentimento_pais=@CONSENTIMENTO, updated_at=now() WHERE id_hospede=@ID; ";
                        update.AddParameter("@ID", hospede.IdHospede, System.Data.DbType.Int32);
                        update.AddParameter("@CONSENTIMENTO", hospede.Consentimento, System.Data.DbType.Boolean);

                        var affectedRows = (int) update.ExecuteNonQuery();

                        if (affectedRows == 1)
                        {
                            return hospede;
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

        public Hospede BuscarPeloID(int id)
        {
            try
            {
                using (var conn = _conn.Conexao())
                {
                    conn.Open();

                    using (var select = conn.CreateCommand())
                    {
                        select.CommandText = "SELECT * FROM vallez.hospedes WHERE id_hospede = @ID";
                        select.AddParameter("@ID", id,System.Data.DbType.Int32);

                        var reader = select.ExecuteReader();
                        if (reader.Read())
                        {
                            Hospede h = this.PreencherHospede(reader);

                            return h;
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

        public List<Hospede> BuscarTodos()
        {
            try
            {
                using (var conn = _conn.Conexao())
                {
                    conn.Open();
                    using (var select = conn.CreateCommand())
                    {
                        select.CommandText = "SELECT * FROM vallez.hospedes;";

                        var reader = select.ExecuteReader();

                        List<Hospede> hospedes = new List<Hospede>();
                        while (reader.Read())
                        {
                            Hospede h = this.PreencherHospede(reader);
                            hospedes.Add(h);
                        }

                        return hospedes;

                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Deletar(Hospede hospede)
        {
            try
            {
                using (var conn = _conn.Conexao())
                {
                    conn.Open();

                    using (var delete = conn.CreateCommand())
                    {
                        delete.CommandText = "DELETE FROM vallez.hospedes WHERE id_hospede = @ID";
                        delete.AddParameter("@ID", hospede.IdHospede, System.Data.DbType.Int32);

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

        public Hospede Inserir(Hospede hospede)
        {
            try
            {
                using (var conn = _conn.Conexao())
                {
                    conn.Open();
                    using (var insert = conn.CreateCommand())
                    {
                        insert.CommandText = "INSERT INTO vallez.hospedes (uuid_hospede, id_pessoa, id_usuario, consentimento_pais, created_at, updated_at) VALUES(vallez.uuid_generate_v4(), @PESSOA, @USUARIO, @CONSENTIMENTO, now(), now()) returning *;";
                        insert.AddParameter("@PESSOA", hospede.IdPessoa, System.Data.DbType.Int32);
                        insert.AddParameter("@USUARIO", hospede.Usuario.Id, System.Data.DbType.Int32);
                        insert.AddParameter("@CONSENTIMENTO", hospede.Consentimento, System.Data.DbType.Boolean);

                        var reader = insert.ExecuteReader();

                        if (reader.Read())
                        {
                            Hospede h = this.PreencherHospede(reader);

                            return h;

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
