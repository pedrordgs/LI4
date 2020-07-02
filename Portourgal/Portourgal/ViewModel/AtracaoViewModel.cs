using Portourgal.InteractionsAPI;
using Portourgal.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
        public AtracaoViewModel(Atracao atracao, string distrito, string distritoASCII)
        {
            Nome = atracao.Nome;
            Localidade = atracao.Localidade;
            Historia = atracao.Historia;
            Imagem = atracao.Imagem;
            Distrito = distrito;
            DistritoASCII = distritoASCII;
            Atracao = atracao;
            Estrelas = new List<Estrela>();
            Avaliacao c = null;
            if (atracao.Classificacao != null)
            {
                c = atracao.Classificacao.FirstOrDefault(x => x.Email.Equals(UserInteraction.user.Email));
            }
            Estrelas = new List<Estrela>();
            if (c != null)
            {
                int i;
                for (i = 0; i < c.Classificacao; i++)
                {
                    Estrelas.Add(new Estrela("estrela_cor.png", i));
                }
                while (i < 5)
                    Estrelas.Add(new Estrela("estrela.png", i));
            }
            else
            {
                for (int i = 0; i < 5; i++)
                {
                    Estrelas.Add(new Estrela("estrela.png", i));
                }
            }
            if (atracao.Classificacao != null)
            {
                List<int> l = atracao.Classificacao.Select(x => x.Classificacao).ToList();
                Classificacao = l.Count > 0 ? l.Average() : 0.0;
            }
            else Classificacao = 0.0;
            ComandoEstrela = new Command(EstrelaClassificacao);
            Visitado = UserInteraction.user.Historico.Where(x => string.Equals(x.Distrito,distrito) && string.Equals(x.Atracao,atracao.Nome) && string.Equals(x.Imagem,atracao.Imagem)).ToList().Count > 0;
        }

        public void EstrelaClassificacao(object o)
        {
            int index = (int)o;
            Avaliacao c = new Avaliacao(UserInteraction.user.Email, index+1);
            Distrito d = DistritoInteraction.GetDistrito(DistritoASCII).Result;
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
                        d.Cidades[i].Atracoes[j].Classificacao.Add(c);
                        Atracao = d.Cidades[i].Atracoes[j];
                        found = true;
                    }
                }
            }
            DistritoInteraction.UpdateDistrito(DistritoASCII,d);
            c= Atracao.Classificacao.FirstOrDefault(x => x.Email.Equals(UserInteraction.user.Email));
            Estrelas = new List<Estrela>();
            if (c != null)
            {
                int i;
                for (i = 0; i < c.Classificacao; i++)
                {
                    Estrelas.Add(new Estrela("estrela_cor.png", i));
                }
                while (i < 5)
                    Estrelas.Add(new Estrela("estrela.png", i));
            }
            else
            {
                for (int i = 0; i < 5; i++)
                {
                    Estrelas.Add(new Estrela("estrela.png", i));
                }
            }
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
    }
}
