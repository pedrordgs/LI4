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
    class Params
    {
        public Params(string n, string d, string da)
        {
            Nome = n;
            Distrito = d;
            DistritoASCII = da;
        }
        public string Nome { get; set; }
        public string Distrito { get; set; }
        public string DistritoASCII { get; set; }
    }
    class Info
    {
        public Info(string n, string i, Params p)
        {
            Nome = n;
            Imagem = i;
            Params = p;
        }
        public string Nome { get; set; }
        public string Imagem { get; set; }
        public Params Params { get; set; }
    }
    class InformacaoCaminho
    {
        public InformacaoCaminho(string c, string d, List<Info> a, List<Info> r, List<Info> h)
        {
            Cidade = c;
            Distrito = d;
            Atracoes = a;
            Restaurantes = r;
            Hoteis = h;
        }
        public string Cidade { get; set; }
        public string Distrito { get; set; }
        public List<Info> Atracoes{ get; set; }
        public List<Info> Restaurantes { get; set; }
        public List<Info> Hoteis { get; set; }
    }
    class RoteirosViewModel
    {
        public RoteirosViewModel(Roteiro r)
        {
            Cidades = r.Percurso.Select(str => "• " + str).ToList();
            Descricao = r.Descricao;
            ImagemPercurso = r.ImagemPercurso;
            Nome = r.Nome;
            List<Distrito> distritos = DistritoInteraction.GetDistritos().Result;
            List<Distrito> aux;
            Detalhes = new List<InformacaoCaminho>();
            r.Percurso.ForEach(c =>
            {
                aux = distritos.Where(d => d.Cidades.Where(city => city.Nome == c).Count() > 0).ToList();
                if (aux.Count() > 0)
                {
                    Cidade cid = aux[0].Cidades.Where(city => city.Nome == c).ToList()[0];
                    List<Info> at = new List<Info>();
                    List<Info> rest = new List<Info>();
                    List<Info> hot = new List<Info>();
                    cid.Atracoes.Take(2).ToList().ForEach(a => at.Add(new Info(a.Nome, a.Imagem, new Params(a.Nome, aux[0].Nome, aux[0].ASCIIName))));
                    cid.Restaurantes.Take(2).ToList().ForEach(re => rest.Add(new Info(re.Nome, re.Imagem, new Params(re.Nome, aux[0].Nome, aux[0].ASCIIName))));
                    cid.Hoteis.Take(2).ToList().ForEach(h => hot.Add(new Info(h.Nome, h.Imagem, new Params(h.Nome, aux[0].Nome, aux[0].ASCIIName))));
                    Detalhes.Add(new InformacaoCaminho(cid.Nome, aux[0].Nome, at, rest, hot));
                }
            });
            ComandoAtracao = new Command(CliqueAtracao);
            ComandoRestaurante = new Command(CliqueRestaurante);
            ComandoHotel = new Command(CliqueHotel);
        }

        void CliqueAtracao(object d)
        {
            Params p = (Params)d;
            App.Current.MainPage.Navigation.PushAsync(new AtracaoView(p.Nome, p.Distrito, p.DistritoASCII));
        }

        void CliqueRestaurante(object d)
        {
            Params p = (Params)d;
            Distrito dist = DistritoInteraction.GetDistrito(p.DistritoASCII).Result;
            bool found = false;
            for (int i = 0; !found && i < dist.Cidades.Count; i++)
            {
                for (int j = 0; !found && j < dist.Cidades[i].Restaurantes.Count; j++)
                {
                    if (dist.Cidades[i].Restaurantes[j].Nome == p.Nome)
                    {
                        App.Current.MainPage.Navigation.PushAsync(new RestauranteView(dist.Cidades[i].Restaurantes[j]));
                        found = true;
                    }
                }
            }
        }

        void CliqueHotel(object d)
        {
            Params p = (Params)d;
            Distrito dist = DistritoInteraction.GetDistrito(p.DistritoASCII).Result;
            bool found = false;
            for (int i = 0; !found && i < dist.Cidades.Count; i++)
            {
                for (int j = 0; !found && j < dist.Cidades[i].Hoteis.Count; i++)
                {
                    if (dist.Cidades[i].Hoteis[j].Nome == p.Nome)
                    {
                        App.Current.MainPage.Navigation.PushAsync(new HotelView(dist.Cidades[i].Hoteis[j]));
                        found = true;
                    }
                }
            }
        }

        public List<string> Cidades { get; set; }
        public string Descricao { get; set; }
        public string ImagemPercurso { get; set; }
        public string Nome { get; set; }
        public List<InformacaoCaminho> Detalhes { get; set; }
        public Command ComandoAtracao { get; set; }
        public Command ComandoRestaurante { get; set; }
        public Command ComandoHotel { get; set; }
    }
}
