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
            Visitado = UserInteraction.user.Historico.Where(x => string.Equals(x.Distrito,distrito) && string.Equals(x.Atracao,atracao.Nome) && string.Equals(x.Imagem,atracao.Imagem)).ToList().Count > 0;
        }


        public void acrescentaHistorico(string distrito, string atracao, string imagem)
        {
            Publicacao p = new Publicacao(distrito, atracao, imagem);
            if (UserInteraction.user.Historico.Where(x => string.Equals(x.Distrito, distrito) && string.Equals(x.Atracao, atracao) && string.Equals(x.Imagem, imagem)).ToList().Count > 0) return;
            UserInteraction.user.Historico.Add(p);
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


        public string Nome { get; set; }
        public string Localidade { get; set; }
        public string Historia { get; set; }
        public string Imagem { get; set; }

        private bool visitado;
        public bool Visitado {
            get { return visitado; }
            set { 
                visitado = value;
                if (visitado) acrescentaHistorico(Distrito, Nome, Imagem);
                if (!visitado) removeHistorico(Distrito, Nome, Imagem);
            }
        }
        public string Distrito { get; set; }
    }
}
