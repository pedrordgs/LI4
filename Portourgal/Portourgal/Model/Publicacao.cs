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
            Atracao = "";
            Imagem = "";
        }

        public Publicacao(string d, string a, string i)
        {
            Distrito = d;
            Atracao = a;
            Imagem = i;
        }

        public string Distrito { get; set; }
        public string Atracao { get; set; }
        public string Imagem { get; set; }
    }
}
