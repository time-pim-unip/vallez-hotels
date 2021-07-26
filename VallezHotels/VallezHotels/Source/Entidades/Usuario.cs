using System;

namespace VallezHotels.Source.Entidades
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Uuid { get; set; }
        public string NomeUsuario { get; set; }
        public string Senha { get; set; }
        public string TipoUsuario { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Usuario()
        {
            CreatedAt = new DateTime();
            UpdatedAt = new DateTime();
        }

        public Usuario(int id, string uuid, string nomeUsuario, string senha, string tipoUsuario, bool status)
        {
            Id = id;
            Uuid = uuid;
            NomeUsuario = nomeUsuario;
            Senha = senha;
            TipoUsuario = tipoUsuario;
            Status = status;
            CreatedAt = new DateTime();
            UpdatedAt = new DateTime();
        }

    }
}
