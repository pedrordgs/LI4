using Portourgal.InteractionsAPI;
using Portourgal.Model;
using Portourgal.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Portourgal.ViewModel
{
    class DistritosInfViewModel
    {
        public DistritosInfViewModel(Distrito distrito)
        {
            Nome = distrito.Nome;
            Historia = distrito.Historia;
            Atracoes = new List<Atracao>();
            foreach(Cidade c in distrito.Cidades)
            {
                if (c.Atracoes != null)
                {
                    foreach (Atracao a in c.Atracoes)
                    {
                        Atracoes.Add(a);
                    }
                }
            }
            Restaurantes = new List<Restaurante>();
            foreach (Cidade c in distrito.Cidades)
            {
                if (c.Restaurantes != null)
                {
                    foreach (Restaurante r in c.Restaurantes)
                    {
                        Restaurantes.Add(r);
                    }
                }
            }
            Hoteis = new List<Hotel>();
            foreach (Cidade c in distrito.Cidades)
            {
                if (c.Hoteis != null)
                {
                    foreach (Hotel h in c.Hoteis)
                    {
                        Hoteis.Add(h);
                    }
                }
            }
            ComandoAtracao = new Command(SelecionarAtracao);
            ComandoHotel = new Command(SelecionarHotel);
            ComandoRestaurante = new Command(SelecionarRestaurante);
        }

        void SelecionarAtracao(object a)
        {
            string atracao = (string)a;
            Atracao atr = Atracoes.Find(x => string.Equals(x.Nome, atracao));
            App.Current.MainPage.Navigation.PushAsync(new AtracaoView(atr));
        }

        void SelecionarHotel(object h)
        {
            string hotel = (string)h;
            Hotel hot = Hoteis.Find(x => string.Equals(x.Nome, hotel));
            App.Current.MainPage.Navigation.PushAsync(new HotelView(hot));
        }

        void SelecionarRestaurante(object r)
        {
            string restaurante = ((string)r);
            Restaurante rest = Restaurantes.Find(x => string.Equals(x.Nome, restaurante));
            App.Current.MainPage.Navigation.PushAsync(new RestauranteView(rest));
        }

        public string Nome { get; set; }
        public string Historia { get; set; }
        public List<Atracao> Atracoes { get; set; }
        public List<Restaurante> Restaurantes { get; set; }
        public List<Hotel> Hoteis { get; set; }

        public Command ComandoAtracao { get; }
        public Command ComandoHotel { get; }
        public Command ComandoRestaurante { get; }
    }
}
