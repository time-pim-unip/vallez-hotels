using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VallezHotels.Source.Entidades
{
    class Hospede : Pessoa
    {

        public int Id { get; set; }
        public string Uuid { get; set; }
        public Pessoa Pessoa { get; set; }
        public Usuario Usuario { get; set; }
        public bool Consentimento { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Hospede()
        {
            CreatedAt = new DateTime();
            UpdatedAt = new DateTime();
        }

        public Hospede(int id, string uuid, Pessoa pessoa, Usuario usuario, bool consentimento, DateTime createdAt, DateTime updatedAt)
        {
            Id = id;
            Uuid = uuid;
            Pessoa = pessoa;
            Usuario = usuario;
            Consentimento = consentimento;
            CreatedAt = new DateTime();
            UpdatedAt = new DateTime();
        }
    }
}
