using Portourgal.InteractionsAPI;
using Portourgal.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portourgal.ViewModel
{
    class AtracaoViewModel
    {
        public AtracaoViewModel(Atracao atracao)
        {
            Nome = atracao.Nome;
            Localidade = atracao.Localidade;
            Historia = atracao.Historia;
            Imagem = atracao.Imagem;
        }

        public string Nome { get; set; }
        public string Localidade { get; set; }
        public string Historia { get; set; }
        public string Imagem { get; set; }
    }
}
