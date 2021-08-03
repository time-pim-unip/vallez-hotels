using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VallezHotels.Source.Entidades;

namespace VallezHotels.Source.DTO
{
    public class LocacaoPorDisponibilidadeDTO
    {

        public Locacao Locacao { get; set; }
        public Quarto Quarto { get; set; }
        public Disponibilidade Disponibilidade { get; set; }

        public LocacaoPorDisponibilidadeDTO()
        {
            Locacao = new Locacao();
            Quarto = new Quarto();
            Disponibilidade = new Disponibilidade();
        }

    }
}
