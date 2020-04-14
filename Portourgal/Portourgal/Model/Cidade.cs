using System;
using System.Collections.Generic;
using System.Text;

namespace Portourgal.Model
{
    public class Cidade
    {
        public Cidade()
        {
            Nome = "";
        }

        public Cidade (string n)
        {
            Nome = n;
        }

        public string Nome { get; set; }
    }
}
