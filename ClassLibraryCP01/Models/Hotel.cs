using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryCP01.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Classificacao { get; set; }
        public string Descricao { get; set; }
        public List<Quarto> Quartos { get; set; }

        public Hotel() { }

        public Hotel(int id, string nome, string endereco, string classificacao, string descricao, List<Quarto> quartos)
        {
            Id = id;
            Nome = nome;
            Endereco = endereco;
            Classificacao = classificacao;
            Descricao = descricao;
            Quartos = quartos;
        }

        public String DetalharHotel()
        {
            return $"ID: {Id} - {Nome} - classificação: {Classificacao} - endereço: {Endereco} - descrição: {Descricao}";
        }
    }
}
