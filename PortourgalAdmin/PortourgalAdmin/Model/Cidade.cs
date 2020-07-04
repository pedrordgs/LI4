using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortourgalAdmin.Model
{
    public class Cidade
    {
        public Cidade()
        {
            Nome = "";
            Atracoes = null;
            Restaurantes = null;
            Hoteis = null;
        }

        public Cidade(string n, List<Atracao> atr, List<Restaurante> rest, List<Hotel> h)
        {
            Nome = n;
            Atracoes = atr;
            Restaurantes = rest;
            Hoteis = h;
        }

        public string Nome { get; set; }
        public List<Atracao> Atracoes { get; set; }
        public List<Restaurante> Restaurantes { get; set; }
        public List<Hotel> Hoteis { get; set; }
    }
}
