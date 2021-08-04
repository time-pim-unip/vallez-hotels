using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VallezHotels.Source.Entidades
{
    public class Locacao
    {
        public int Id { get; set; }
        public string Uuid { get; set; }
        public Quarto Quarto { get; set; }
        public List<Hospedagem> Hospedagems { get; set; }
        public List<ServicoSolicitado> ServicosSolicitados { get; set; } 
        public DateTime DataEntrada { get; set; }
        public DateTime DataSaida { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Locacao()
        {
            Hospedagems = new List<Hospedagem>();
            ServicosSolicitados = new List<ServicoSolicitado>();
            Quarto = new Quarto();
        }
        private double ValorTotalDiasLocacao()
        {
            var TotalDiasLocado = Math.Ceiling(DataSaida.Subtract(DataEntrada).TotalDays) + 1;

            return Quarto.ValorDiaria * TotalDiasLocado;
        }

        private double ValorTotalServicos()
        {

            double soma = 0;

            foreach (ServicoSolicitado ss in ServicosSolicitados)
            {
                soma += ss.ValorTotalServico();
            }

            return soma;

        }

        public double ValorDaLocacao()
        {
            return ValorTotalDiasLocacao() + ValorTotalServicos();
        }

    }
}
