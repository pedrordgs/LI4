using Portourgal.InteractionsAPI;
using Portourgal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Portourgal.ViewModel
{
    class ScoreBoardViewModel
    {
        public ScoreBoardViewModel()
        {
            List<Utilizador> users = UserInteraction.getUtilizadores().Result;
            users = users.OrderByDescending(x => x.Pontos).ToList<Utilizador>();
            if (users.Count > 0)
            {
                ImagemPrimeiro = users[0].Imagem;
                NomePrimeiro = users[0].Nome;
                PontosPrimeiro = users[0].Pontos + " pontos";
            }
            if (users.Count > 1)
            {
                ImagemSegundo = users[1].Imagem;
                NomeSegundo = users[1].Nome;
                PontosSegundo = users[1].Pontos + " pontos";
            }
            if (users.Count > 2)
            {
                ImagemTerceiro = users[2].Imagem;
                NomeTerceiro = users[2].Nome;
                PontosTerceiro = users[2].Pontos + " pontos";
            }
            ImagemUser = UserInteraction.user.Imagem;
            NomeUser = UserInteraction.user.Nome;
            PontosUser = UserInteraction.user.Pontos + " pontos";
            for(int i = 0; i < users.Count; i++)
            {
                if (string.Equals(users[i].Email, UserInteraction.user.Email))
                {
                    LugarUser = i+1;
                    break;
                }
            }
        }

        public List<Utilizador> Leaderboard { get; set; }
        public string ImagemPrimeiro {get;set;}
        public string NomePrimeiro { get; set; }
        public string PontosPrimeiro { get; set; }
        public string ImagemSegundo { get; set; }
        public string NomeSegundo { get; set; }
        public string PontosSegundo { get; set; }
        public string ImagemTerceiro { get; set; }
        public string NomeTerceiro { get; set; }
        public string PontosTerceiro { get; set; }
        public string ImagemUser { get; set; }
        public string NomeUser { get; set; }
        public string PontosUser { get; set; }
        public int LugarUser { get; set; }
    }
}
