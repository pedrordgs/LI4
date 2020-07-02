using System;
using System.Collections.Generic;
using System.Text;

namespace Portourgal.Model
{
    public class Roteiro
    {
        public List<string> Percurso { get; set; }
        public string Descricao { get; set; }
        public string ImagemRoteiro { get; set; }
        public string ImagemPercurso { get; set; }
        public string Nome { get; set; }
        public int Dist { get; set; }
    }
}
