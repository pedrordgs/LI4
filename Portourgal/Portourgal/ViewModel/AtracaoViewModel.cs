using Newtonsoft.Json.Linq;
using Portourgal.InteractionsAPI;
using Portourgal.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace Portourgal.ViewModel
{
    public class Estrela
    {
        public Estrela(string i, int index)
        {
            Imagem = i;
            Index = index;
        }
        public string Imagem { get; set; }
        public int Index { get; set; }
    }

    public class AtracaoViewModel : INotifyPropertyChanged
    {
        public AtracaoViewModel(string atracao, string distrito, string distritoASCII)
        {
            bool found = false;
            Distrito d = DistritoInteraction.GetDistrito(distritoASCII).Result;
            for (int i = 0; !found && i < d.Cidades.Count; i++)
            {
                for (int j = 0; !found && j < d.Cidades[i].Atracoes.Count; j++)
                {
                        Atracao = d.Cidades[i].Atracoes[j];
                        found = true;
                }
            }
            Nome = Atracao.Nome;
            Localidade = Atracao.Localidade;
            Historia = Atracao.Historia;
            Imagem = Atracao.Imagem;
            Distrito = distrito;
            DistritoASCII = distritoASCII;
            Avaliacao c = null;
            if (Atracao.Classificacao != null)
            {
                c = Atracao.Classificacao.FirstOrDefault(x => x.Email.Equals(UserInteraction.user.Email));
            }
            List<Estrela> aux = new List<Estrela>();
            if (c != null)
            {
                int i;
                for (i = 0; i < c.Classificacao; i++)
                {
                    aux.Add(new Estrela("estrela_cor.png", i));
                }
                while (i < 5)
                    aux.Add(new Estrela("estrela.png", i++));
            }
            else
            {
                for (int i = 0; i < 5; i++)
                {
                    aux.Add(new Estrela("estrela.png", i));
                }
            }
            Estrelas = aux;
            if (Atracao.Classificacao != null)
            {
                List<int> l = Atracao.Classificacao.Select(x => x.Classificacao).ToList();
                Classificacao = l.Count > 0 ? l.Average() : 0.0;
            }
            else Classificacao = 0.0;
            ComandoEstrela = new Command(EstrelaClassificacao);
            Visitado = UserInteraction.user.Historico.Where(x => string.Equals(x.Distrito, distrito) && string.Equals(x.Atracao, Atracao.Nome) && string.Equals(x.Imagem, Atracao.Imagem)).ToList().Count > 0;

            HttpClient client = new HttpClient();
            string request = "http://api.openweathermap.org/data/2.5/weather?q=" + distrito + ",PT&lang=pt&units=metric&appid=1decd1e1c8bd4de66f557d9924560d6a";
            HttpResponseMessage response = client.GetAsync(request).Result;
            if (response.IsSuccessStatusCode)
            {
                String json = response.Content.ReadAsStringAsync().Result;
                dynamic data = JObject.Parse(json);
                WeatherDesc = Convert.ToString(data["weather"][0]["description"]);
                WeatherIcon = "http://openweathermap.org/img/wn/" + Convert.ToString(data["weather"][0]["icon"]) + ".png";
                Temp = Convert.ToString(data["main"]["temp"]) + " °C";
            }
        }

        public void EstrelaClassificacao(object o)
        {
            int index = (int)o;
            Avaliacao c = new Avaliacao(UserInteraction.user.Email, index+1);
            Distrito d = DistritoInteraction.GetDistrito(DistritoASCII).Result;
            Avaliacao help;
            bool found = false;
            for(int i = 0; !found && i < d.Cidades.Count; i++)
            {
                for (int j = 0; !found && j < d.Cidades[i].Atracoes.Count; j++)
                {
                    if (d.Cidades[i].Atracoes[j].Nome.Equals(Atracao.Nome))
                    {
                        if (d.Cidades[i].Atracoes[j].Classificacao == null)
                        {
                            d.Cidades[i].Atracoes[j].Classificacao = new List<Avaliacao>();
                        }
                        if ((help=d.Cidades[i].Atracoes[j].Classificacao.FirstOrDefault(x=> x.Email.Equals(UserInteraction.user.Email))) != null)
                        {
                            if (help.Classificacao == index + 1) d.Cidades[i].Atracoes[j].Classificacao.Remove(help);
                            else
                            {
                                d.Cidades[i].Atracoes[j].Classificacao.Remove(help);
                                d.Cidades[i].Atracoes[j].Classificacao.Add(c);
                            }
                        }
                        else d.Cidades[i].Atracoes[j].Classificacao.Add(c);
                        Atracao = d.Cidades[i].Atracoes[j];
                        found = true;
                    }
                }
            }
            DistritoInteraction.UpdateDistrito(DistritoASCII,d);
            c = Atracao.Classificacao.FirstOrDefault(x => x.Email.Equals(UserInteraction.user.Email));
            List<Estrela> aux = new List<Estrela>();
            if (c != null)
            {
                int i;
                for (i = 0; i < c.Classificacao; i++)
                {
                    aux.Add(new Estrela("estrela_cor.png", i));
                }
                while (i < 5)
                    aux.Add(new Estrela("estrela.png", i++));
            }
            else
            {
                for (int i = 0; i < 5; i++)
                {
                    aux.Add(new Estrela("estrela.png", i));
                }
            }
            Estrelas = aux;
            if (Atracao.Classificacao != null)
            {
                List<int> l = Atracao.Classificacao.Select(x => x.Classificacao).ToList();
                Classificacao = l.Count > 0 ? l.Average() : 0.0;
            }
            else Classificacao = 0.0;
        }

        public void acrescentaHistorico(string distrito, string atracao, string imagem)
        {
            Publicacao p = new Publicacao(distrito, atracao, imagem);
            if (UserInteraction.user.Historico.Where(x => string.Equals(x.Distrito, distrito) && string.Equals(x.Atracao, atracao) && string.Equals(x.Imagem, imagem)).ToList().Count > 0) return;
            UserInteraction.user.Historico.Insert(0, p);
            UserInteraction.user.Pontos++;
            UserInteraction.updateUser();
        }

        public void removeHistorico(string distrito, string atracao, string imagem)
        {
            Publicacao p = new Publicacao(distrito, atracao, imagem);
            if (!(UserInteraction.user.Historico.Where(x => string.Equals(x.Distrito, distrito) && string.Equals(x.Atracao, atracao) && string.Equals(x.Imagem, imagem)).ToList().Count > 0)) return;
            UserInteraction.user.Historico.RemoveAll(x => string.Equals(x.Distrito, distrito) && string.Equals(x.Atracao, atracao) && string.Equals(x.Imagem, imagem));
            UserInteraction.user.Pontos--;
            UserInteraction.updateUser();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public string Nome { get; set; }
        public string Localidade { get; set; }
        public string Historia { get; set; }
        public string Imagem { get; set; }
        public string Distrito { get; set; }
        public string DistritoASCII { get; set; }
        public List<Estrela> estrelas { get; set; }
        public List<Estrela> Estrelas
        {
            get { return estrelas; }
            set { estrelas = value; OnPropertyChanged(nameof(Estrelas)); }
        }
        
        public double classificacao { get; set; }
        public double Classificacao 
        {
            get { return classificacao; } 
            set { classificacao = value; OnPropertyChanged(nameof(Classificacao)); }
        }
        private bool visitado;

        public bool Visitado {
            get { return visitado; }
            set { 
                visitado = value;
                if (visitado) acrescentaHistorico(Distrito, Nome, Imagem);
                if (!visitado) removeHistorico(Distrito, Nome, Imagem);
            }
        }
        public Atracao Atracao { get; set; }
        public Command ComandoEstrela { get;}
        public string Temp { get; set; }
        public string WeatherDesc { get; set; }
        public string WeatherIcon { get; set; }
    }
}
