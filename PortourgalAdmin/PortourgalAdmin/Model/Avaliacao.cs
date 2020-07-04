using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortourgalAdmin.Model
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
