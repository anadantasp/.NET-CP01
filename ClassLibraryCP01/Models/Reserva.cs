using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ClassLibraryCP01.Models
{
    public class Reserva
    {
        public Cliente Cliente { get; set; }
        public Quarto Quarto { get; set; }
        public DateTime DataCheckin { get; set; }
        public DateTime DataCheckout { get; set; }
        public double PrecoTotal { get; set; }

        public double SimulacaoPrecoTotalReserva(DateTime checkin, DateTime checkout, double precoPorNoiteQuarto)
        {
            double quantidadeDias = CalcularDiferencaDias(checkin, checkout);
            Console.WriteLine($"Quantidade de dias retornados: {quantidadeDias}");

            return quantidadeDias * precoPorNoiteQuarto;
            
        }

        private double CalcularDiferencaDias(DateTime checkin, DateTime checkout)
        {
            TimeSpan diferencaDias = checkout - checkin;

            return diferencaDias.TotalDays;
        }

        public string DetalhesReserva()
        {
            return ($"Checkin: {DataCheckin} - Checkout: {DataCheckout} - Numero quarto escolhido: {Quarto.Numero} - Total: R${PrecoTotal}");
        }

    }
}
