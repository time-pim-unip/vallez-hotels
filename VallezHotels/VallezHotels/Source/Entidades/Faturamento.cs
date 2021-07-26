using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VallezHotels.Source.Entidades
{
    public class Faturamento
    {
        public int Id { get; set; }
        public string Uuid { get; set; }
        public Locacao Locacao { get; set; }
        public double ValorTotal { get; set; }
        public double ValorDesconto { get; set; }
        public double ValorPago { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Faturamento()
        {
            Locacao = new Locacao();
        }
    }
}
