using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VallezHotels.Source.Entidades
{
    public class Servico
    {
        public int Id { get; set; }
        public string Uuid { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Servico()
        {
            CreatedAt = new DateTime();
            UpdatedAt = new DateTime();
        }

        public Servico(int id, string uuid, string descricao, double valor, DateTime createdAt, DateTime updatedAt)
        {
            Id = id;
            Uuid = uuid;
            Descricao = descricao;
            Valor = valor;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
    }
}
