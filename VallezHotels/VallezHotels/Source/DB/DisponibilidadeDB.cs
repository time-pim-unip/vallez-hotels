﻿using System;
using System.Data.Common;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VallezHotels.Source.DB.Interfaces;
using VallezHotels.Source.Entidades;

namespace VallezHotels.Source.DB
{
    class DisponibilidadeDB : IDBComandosBasicosEntidade<Disponibilidade>
    {
        private readonly IDBConexao _conn;

        public DisponibilidadeDB(IDBConexao conn)
        {
            _conn = conn;
        }

        public Disponibilidade PreencherDisponibilidade(DbDataReader reader)
        {
            Disponibilidade d = new Disponibilidade();
            d.Id = int.Parse(reader["id_disponibilidade"].ToString());
            d.Uuid = reader["uuid_disponibilidade"].ToString();
            d.Quarto.Id = int.Parse(reader["id_quarto"].ToString());
            d.CreatedAt = DateTime.Parse(reader["created_at"].ToString());
            d.UpdatedAt = DateTime.Parse(reader["updated_at"].ToString());
            return d;
        }

        public Disponibilidade Atualizar(Disponibilidade disponibilidade)
        {
            try
            {
                using (var conn = _conn.Conexao())
                {
                    conn.Open();

                    using (var update = conn.CreateCommand())
                    {
                        update.CommandText = "UPDATE vallez.disponibilidades SET id_quarto=@QUARTO, data=@DATA, dia_disponivel=@DISPONIVEL, updated_at=now() WHERE id_disponibilidade=@ID; ";
                        update.AddParameter("@ID", disponibilidade.Id, System.Data.DbType.Int32);
                        update.AddParameter("@QUARTO", disponibilidade.Quarto.Id, System.Data.DbType.Int32);
                        update.AddParameter("@DATA", disponibilidade.Data, System.Data.DbType.Date);
                        update.AddParameter("@DISPONIVEL", disponibilidade.Disponivel, System.Data.DbType.Boolean);

                        var affectedRows = (int)update.ExecuteNonQuery();

                        if (affectedRows == 1)
                        {
                            return disponibilidade;
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

        public Disponibilidade BuscarPeloID(int id)
        {
            try
            {
                using (var conn = _conn.Conexao())
                {
                    conn.Open();

                    using (var select = conn.CreateCommand())
                    {
                        select.CommandText = "SELECT * FROM vallez.disponibilidades WHERE id_disponibilidade = @ID";
                        select.AddParameter("@ID", id, System.Data.DbType.Int32);

                        var reader = select.ExecuteReader();
                        if (reader.Read())
                        {
                            Disponibilidade d = this.PreencherDisponibilidade(reader);

                            return d;
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

        public List<Disponibilidade> BuscarTodos()
        {
            try
            {
                using (var conn = _conn.Conexao())
                {
                    conn.Open();
                    using (var select = conn.CreateCommand())
                    {
                        select.CommandText = "SELECT * FROM vallez.disponibilidades;";

                        var reader = select.ExecuteReader();

                        List<Disponibilidade> disponibilidades = new List<Disponibilidade>();
                        while (reader.Read())
                        {
                            Disponibilidade d = this.PreencherDisponibilidade(reader);
                            disponibilidades.Add(d);
                        }

                        return disponibilidades;

                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Deletar(Disponibilidade disponibilidade)
        {
            try
            {
                using (var conn = _conn.Conexao())
                {
                    conn.Open();

                    using (var delete = conn.CreateCommand())
                    {
                        delete.CommandText = "DELETE FROM vallez.disponibilidades WHERE id_disponibilidade = @ID";
                        delete.AddParameter("@ID", disponibilidade.Id, System.Data.DbType.Int32);

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

        public Disponibilidade Inserir(Disponibilidade disponibilidade)
        {
            try
            {
                using (var conn = _conn.Conexao())
                {
                    conn.Open();
                    using (var insert = conn.CreateCommand())
                    {
                        insert.CommandText = "INSERT INTO vallez.disponibilidades (uuid_disponibilidade, id_quarto, data, dia_disponivel, created_at, updated_at) VALUES(vallez.uuid_generate_v4(), @QUARTO, @DATA, @DISPONIVEL, now(), now()) returning *;";
                        insert.AddParameter("@QUARTO", disponibilidade.Quarto.Id, System.Data.DbType.Int32);
                        insert.AddParameter("@DATA", disponibilidade.Data, System.Data.DbType.Date);
                        insert.AddParameter("@DISPONIVEL", disponibilidade.Disponivel, System.Data.DbType.Boolean);

                        var reader = insert.ExecuteReader();

                        if (reader.Read())
                        {
                            Disponibilidade d = this.PreencherDisponibilidade(reader);

                            return d;

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
