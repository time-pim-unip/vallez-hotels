using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VallezHotels.Source.Core;

namespace VallezHotels.Source.Entidades
{
    public class Usuario
    {

        public int IdUsuario { get; set; }
        public string Uuid { get; set; }
        public string NomeUsuario { get; set; }
        public string Senha { get; set; }
        public string TipoUsuario { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }


        public bool InserirUsuario()
        {

            var conn = ConexaoBanco.GetConexao();            
            try
            {
                try
                {
                    var insert = conn.CreateCommand();
                    insert.CommandText = "INSERT INTO vallez.usuarios (uuid_usuario, usuario, senha, tipo_usuario) VALUES(uuid_generate_v4(), @usuario, sha256('@senha'), @tipo_usuario) returning *";
                    insert.Parameters.AddWithValue("@usuario", this.NomeUsuario);
                    insert.Parameters.AddWithValue("@senha", this.Senha);
                    insert.Parameters.AddWithValue("@tipo_usuario", this.TipoUsuario);

                    var reader = insert.ExecuteReader();

                    if (reader.Read())
                    {

                        this.IdUsuario = int.Parse(reader["id_usuario"].ToString());
                        this.Uuid = reader["uuid_usuario"].ToString();
                        this.NomeUsuario = reader["usuario"].ToString();
                        this.Senha = reader["senha"].ToString();
                        this.TipoUsuario = reader["tipo_usuario"].ToString();
                        this.Status = bool.Parse(reader["status"].ToString());
                        this.CreatedAt = DateTime.Parse(reader["created_at"].ToString());
                        this.UpdatedAt = DateTime.Parse(reader["updated_at"].ToString());

                        return true;

                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {

                conn.Close();
            }
        }

    }
}
