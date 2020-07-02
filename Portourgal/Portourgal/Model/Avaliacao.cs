using System;
using System.Collections.Generic;
using System.Text;

namespace Portourgal.Model
{
    public class Avaliacao
    {
        public Avaliacao(string e, int c)
        {
            Email = e;
            Classificacao = c;
        }
        public string Email { get; set; }
        public int Classificacao { get; set; }
    }
}
