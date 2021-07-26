using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VallezHotels.Source.Entidades
{
    public class Quarto
    {
        public int Id { get; set; }
        public string Uuid { get; set; }
        public TipoQuarto TipoQuarto { get; set; }
        public string Bloco { get; set; }
        public int Numero { get; set; }
        public int QuantidadeBanheiros { get; set; }
        public int QuantidadeCamas { get; set; }
        public double ValorDiaria { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Quarto()
        {
            TipoQuarto = new TipoQuarto();
            CreatedAt = new DateTime();
            UpdatedAt = new DateTime();
        }

    }
}
