using System;
using System.Collections.Generic;
using System.Text;

namespace Portourgal.Model
{
    class Distrito
    {
        public Distrito()
        {
            Nome = "";
            Historia = "";
            Cidade = new List<Cidade> ();
        }

        public Distrito(string n, string h, List<Cidade> c)
        {
            Nome = n;
            Historia = h;
            Cidade = new List<Cidade>(c);
        }

        public string Nome { get; set; }
        public string Historia { get; set; }
        public List<Cidade> Cidade { get; set; }
    }
}