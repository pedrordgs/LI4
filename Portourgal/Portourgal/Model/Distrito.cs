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
            Historia = "";
            Cidades = new List<Cidade> ();
        }

        public Distrito(string n, string h, List<Cidade> c)
        {
            Nome = n;
            Historia = h;
            Cidades = new List<Cidade>(c);
        }

        public string Nome { get; set; }
        public string Historia { get; set; }
        public List<Cidade> Cidades { get; set; }
    }
}