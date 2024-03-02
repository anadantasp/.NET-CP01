using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ClassLibraryCP01.Models
{
    public class Suite : Quarto
    {
        public int NumeroDeSalas { get; set; }

        public Suite (int numero, double precoPorNoite, bool disponibilidade, int numeroDeSalas) : base(numero, precoPorNoite, disponibilidade) 
        {
            NumeroDeSalas = numeroDeSalas;
        }

        public override string ObterDescricao()
        {
            return $"Quarto: {Numero}, Preço por noite: {PrecoPorNoite:C}, {(Disponibilidade ? "Disponível" : "Indisponível")}, Número de Salas: {NumeroDeSalas}";
        }
    }
}
