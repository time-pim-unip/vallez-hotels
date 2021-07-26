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
        // Propríedades da classe
        public int IdUsuario { get; set; }
        public string Uuid { get; set; }
        public string NomeUsuario { get; set; }
        public string Senha { get; set; }
        public string TipoUsuario { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Função para inserir um novo funcionário no banco
        /// </summary>
        /// <returns>bool</returns>
        public bool InserirUsuario()
        {

            // Pega a conexão com o banco de dados
            var conn = ConexaoBanco.GetConexao();            
            try
            {
                try
                {

                    // Utilizar a conexão para criar uma variavel que vai realizar a consulta com o banco de dados
                    var insert = conn.CreateCommand();

                    // Informar qual o comando SQL a ser executado
                    insert.CommandText = "INSERT INTO vallez.usuarios (uuid_usuario, usuario, senha, tipo_usuario) VALUES(uuid_generate_v4(), @usuario, sha256('@senha'), @tipo_usuario) returning *";
                    
                    // Faz o vinculo dos parametros informados no comando SQL com o prefixo '@' na frente, com os valores presentes nas variaveis                    
                    insert.Parameters.AddWithValue("@usuario", this.NomeUsuario);
                    insert.Parameters.AddWithValue("@senha", this.Senha);
                    insert.Parameters.AddWithValue("@tipo_usuario", this.TipoUsuario);

                    // Executa o comando SQL e salva o retorno na variavel reader
                    var reader = insert.ExecuteReader();

                    // Verifica se o banco retornor algo
                    if (reader.Read())
                    { // Caso o banco tenha retornado alguma consulta, executa o seguinte código:

                        // Salva os valores retornados pelo banco nas suas respectivas propríedades já criadas na classe
                        this.IdUsuario = int.Parse(reader["id_usuario"].ToString());
                        this.Uuid = reader["uuid_usuario"].ToString();
                        this.NomeUsuario = reader["usuario"].ToString();
                        this.Senha = reader["senha"].ToString();
                        this.TipoUsuario = reader["tipo_usuario"].ToString();
                        this.Status = bool.Parse(reader["status"].ToString());
                        this.CreatedAt = DateTime.Parse(reader["created_at"].ToString());
                        this.UpdatedAt = DateTime.Parse(reader["updated_at"].ToString());

                        // Retorna um valor TRUE caso tudo tenha sido executado com sucesso.
                        return true;

                    }
                    else
                    {
                        //Caso não tenha nenhum retorno do banco de dados, retorna um valor FALSE
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
                // Fecha a conexão com o banco
                conn.Close();
            }
        }

    }
}
