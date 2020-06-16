using Portourgal.InteractionsAPI;
using Portourgal.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Portourgal.ViewModel
{
    public class AtracaoViewModel
    {
        public AtracaoViewModel(Atracao atracao, string distrito)
        {
            Nome = atracao.Nome;
            Localidade = atracao.Localidade;
            Historia = atracao.Historia;
            Imagem = atracao.Imagem;
            Distrito = distrito;
            Visitado = UserInteraction.user.Historico.Where(x => string.Equals(x.Distrito,distrito) && string.Equals(x.Atracao,atracao.Nome) && string.Equals(x.Imagem,atracao.Imagem)).ToList().Count() > 0;
        }


        public void acrescentaHistorico(string distrito, string atracao, string imagem)
        {
            Publicacao p = new Publicacao(distrito, atracao, imagem);
            UserInteraction.user.Historico.Add(p);
            UserInteraction.updateUser();
        }

        public void removeHistorico(string distrito, string atracao, string imagem)
        {
            Publicacao p = new Publicacao(distrito, atracao, imagem);
            UserInteraction.user.Historico.Remove(p);
            UserInteraction.updateUser();
        }


        public string Nome { get; set; }
        public string Localidade { get; set; }
        public string Historia { get; set; }
        public string Imagem { get; set; }
        public bool Visitado {
            get { return Visitado; }
            set { 
                Visitado = value; 
                if (Visitado) acrescentaHistorico(Distrito, Nome, Imagem);
                if (!Visitado) removeHistorico(Distrito, Nome, Imagem);
            }
        }
        public string Distrito { get; set; }

        
    }
}
