using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortourgalAPI.Models
{
    public class Cidade
    {
        public string Nome { get; set; }
        public List<Atracao> Atracoes {get;set;}
        public List<Restaurante> Restaurantes { get; set; }
        public List<Hotel> Hoteis { get; set; }

    }
}
