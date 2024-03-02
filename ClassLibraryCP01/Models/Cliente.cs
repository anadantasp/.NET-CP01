using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryCP01.Models
{
    public class Cliente
    {
        public string Nome { get; set; }
        public string Email { get; set;}
        public string Senha { get; set;}
        public List<Reserva> Reservas { get; set; }

        public Cliente()
        {

        }

        public Cliente (string nome, string email, string senha, List<Reserva> reservas)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            Reservas = reservas;

        }
    }

    
}
