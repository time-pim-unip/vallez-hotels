using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VallezHotels.Source.Entidades
{
    public class ServicoSolicitado
    {
        public int Id { get; set; }
        public string Uuid { get; set; }
        public Servico Servico { get; set; }
        public Locacao Locacao { get; set; }
        public DateTime Solicitacao { get; set; }
        public int Quantidade { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public ServicoSolicitado()
        {
            Servico = new Servico();
            Locacao = new Locacao();
        }

        public double ValorTotalServico()
        {
            return Servico.Valor * Quantidade;
        }

    }
}
