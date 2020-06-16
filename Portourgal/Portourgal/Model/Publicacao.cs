using System;
using System.Collections.Generic;
using System.Text;

namespace Portourgal.Model
{
    public class Publicacao
    {
        public Publicacao()
        {
            Distrito = "";
            Cidade = "";
            Atracao = "";
        }

        public Publicacao(string d, string c, string a)
        {
            Distrito = d;
            Cidade = c;
            Atracao = a;
        }

        public string Distrito { get; set; }
        public string Cidade { get; set; }
        public string Atracao { get; set; }
    }
}
