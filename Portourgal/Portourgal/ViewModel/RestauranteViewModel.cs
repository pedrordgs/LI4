using Portourgal.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portourgal.ViewModel
{
    class RestauranteViewModel
    {
        public RestauranteViewModel(Restaurante restaurante)
        {
            Nome = restaurante.Nome;
            Morada = restaurante.Morada;
            Classificacao = restaurante.Classificacao.ToString();
            Imagem = restaurante.Imagem;
        }

        public string Nome { get; set; }
        public string Morada { get; set; }
        public string Classificacao { get; set; }
        public string Imagem { get; set; }
    }
}
