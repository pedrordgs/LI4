using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortourgalAdmin.Model
{
    public class Restaurante
    {
        public Restaurante(string n, string m, double c, string i)
        {
            Nome = n;
            Morada = m;
            Classificacao = c;
            Imagem = i;
        }

        public string Nome { get; set; }
        public string Morada { get; set; }
        public double Classificacao { get; set; }
        public string Imagem { get; set; }
    }
}
