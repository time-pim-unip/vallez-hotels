using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VallezHotels.Source.Entidades
{
    public class TipoQuarto
    {

        public int Id { get; set; }
        public string Uuid { get; set; }
        public string Descricao { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public TipoQuarto()
        {
            CreatedAt = new DateTime();
            UpdatedAt = new DateTime();
        }

        public TipoQuarto(int id, string uuid, string descricao, DateTime createdAt, DateTime updatedAt)
        {
            Id = id;
            Uuid = uuid;
            Descricao = descricao;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
    }
}
