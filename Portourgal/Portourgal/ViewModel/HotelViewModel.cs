using Portourgal.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portourgal.ViewModel
{
    class HotelViewModel
    {
        public HotelViewModel(Hotel hotel)
        {
            Nome = hotel.Nome;
            Morada = hotel.Morada;
            Classificacao = new List<string>();
            int i;
            for ( i = 0; i < hotel.Classificacao; i++)
            {
                Classificacao.Add("estrela_cor.png");
            }
            while (i++ < 5)
            {
                Classificacao.Add("estrela.png");
            }
            Imagem = hotel.Imagem;
        }

        public string Nome { get; set; }
        public string Morada { get; set; }
        public List<string> Classificacao { get; set; }
        public string Imagem { get; set; }
    }
}
