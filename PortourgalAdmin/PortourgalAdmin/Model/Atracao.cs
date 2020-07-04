using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortourgalAdmin.Model
{
    public class Atracao
    {
        public string Nome { get; set; }
        public string Localidade { get; set; }
        public string Historia { get; set; }
        public string Imagem { get; set; }
        public List<Avaliacao> Classificacao { get; set; }
    }
}
