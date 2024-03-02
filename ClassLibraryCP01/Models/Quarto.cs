using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ClassLibraryCP01.Models
{
    public class Quarto
    {
        public int Numero { get; set; }
        public double PrecoPorNoite { get; set; }
        public bool Disponibilidade { get; set; }

        public Quarto() { }

        public Quarto (int numero, double precoPorNoite, bool disponibilidade)
        {
            Numero = numero;
            PrecoPorNoite = precoPorNoite;
            Disponibilidade = disponibilidade;
        }

        public virtual string ObterDescricao()
        {
            return $"Quarto: {Numero}, Preço por noite: {PrecoPorNoite:C}, {(Disponibilidade ? "Disponível" : "Indisponível")}";
        }

    }
 }



