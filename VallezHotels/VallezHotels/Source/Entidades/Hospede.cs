using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VallezHotels.Source.Entidades
{
    public class Hospede : Pessoa
    {

        public int IdHospede { get; set; }
        public string UuidHospede { get; set; }
        public Pessoa Pessoa { get; set; }
        public Usuario Usuario { get; set; }
        public bool Consentimento { get; set; }
        public DateTime CreatedAtHospede { get; set; }
        public DateTime UpdatedAtHospede { get; set; }

        public Hospede()
        {
            Usuario = new Usuario();
            CreatedAtHospede = new DateTime();
            UpdatedAtHospede = new DateTime();
        }

        public Hospede(int id, string uuid, Pessoa pessoa, Usuario usuario, bool consentimento, DateTime createdAt, DateTime updatedAt)
        {
            IdHospede = id;
            UuidHospede = uuid;
            Pessoa = pessoa;
            Usuario = usuario;
            Consentimento = consentimento;
            CreatedAtHospede = new DateTime();
            UpdatedAtHospede = new DateTime();
        }
    }
}
