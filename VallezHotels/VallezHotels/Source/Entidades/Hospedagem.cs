using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VallezHotels.Source.Entidades
{
    public class Hospedagem
    {
        public Locacao Locacao { get; set; }
        public Hospede Hospede { get; set; }
        public string Uuid { get; set; }
        public bool Detentor { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Hospedagem()
        {
            Locacao = new Locacao();
            Hospede = new Hospede();
        }
    }
}
