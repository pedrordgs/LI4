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
            Morada = hotel.Nome;
            Classificacao = hotel.Classificacao + " estrelas";
            Imagem = hotel.Imagem;
        }

        public string Nome { get; set; }
        public string Morada { get; set; }
        public string Classificacao { get; set; }
        public string Imagem { get; set; }
    }
}
