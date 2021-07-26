using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VallezHotels.Source.Entidades
{
    public class Disponibilidade
    {

        public int Id { get; set; }
        public string Uuid { get; set; }
        public Quarto Quarto { get; set; }
        public DateTime Data { get; set; }
        public bool Disponivel { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Disponibilidade()
        {
            Quarto = new Quarto();
            Data = new DateTime();
            CreatedAt = new DateTime();
            UpdatedAt = new DateTime();
        }

        public Disponibilidade(int id, string uuid, Quarto quarto, DateTime data, bool disponivel, DateTime createdAt, DateTime updatedAt)
        {
            Id = id;
            Uuid = uuid;
            Quarto = quarto;
            Data = data;
            Disponivel = disponivel;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
    }
}
