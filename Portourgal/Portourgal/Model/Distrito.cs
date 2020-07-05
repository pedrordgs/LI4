using System;
using System.Collections.Generic;
using System.Text;

namespace Portourgal.Model
{
    public class Distrito
    {
        public Distrito()
        {
            Nome = "";
            ASCIIName = "";
            Historia = "";
            Cidades = new List<Cidade> ();
            Imagem = "";
        }

        public Distrito(string n, string an, string h, List<Cidade> c,string i)
        {
            Nome = n;
            Historia = h;
            ASCIIName = an;
            Cidades = new List<Cidade>(c);
            Imagem = i;
        }

        public string Nome { get; set; }
        public string ASCIIName { get; set; }
        public int Pontos { get; set; }
        public string Historia { get; set; }
        public List<Cidade> Cidades { get; set; }
        public string Imagem { get; set; }
    }
}