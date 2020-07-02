using Portourgal.InteractionsAPI;
using Portourgal.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Portourgal.ViewModel
{
    class ScoreBoardViewModel : INotifyPropertyChanged
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
            RefreshCommand = new Command(Refresh);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        void Refresh()
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
            for (int i = 0; i < users.Count; i++)
            {
                if (string.Equals(users[i].Email, UserInteraction.user.Email))
                {
                    LugarUser = i + 1;
                    break;
                }
            }
            IsRefreshing = false;
        }

        public string ImagemPrimeiro 
        {
            get { return imagemPrimeiro; }
            set 
            {
                imagemPrimeiro = value;
                OnPropertyChanged(nameof(ImagemPrimeiro));
            }
        }
        public string NomePrimeiro
        {
            get { return nomePrimeiro; }
            set
            {
                nomePrimeiro = value;
                OnPropertyChanged(nameof(NomePrimeiro));
            }
        }
        public string PontosPrimeiro
        {
            get { return pontosPrimeiro; }
            set
            {
                pontosPrimeiro = value;
                OnPropertyChanged(nameof(PontosPrimeiro));
            }
        }
        public string ImagemSegundo
        {
            get { return imagemSegundo; }
            set
            {
                imagemSegundo = value;
                OnPropertyChanged(nameof(ImagemSegundo));
            }
        }
        public string NomeSegundo
        {
            get { return nomeSegundo; }
            set
            {
                nomeSegundo = value;
                OnPropertyChanged(nameof(NomeSegundo));
            }
        }
        public string PontosSegundo
        {
            get { return pontosSegundo; }
            set
            {
                pontosSegundo = value;
                OnPropertyChanged(nameof(PontosSegundo));
            }
        }
        public string ImagemTerceiro
        {
            get { return imagemTerceiro; }
            set
            {
                imagemTerceiro = value;
                OnPropertyChanged(nameof(ImagemTerceiro));
            }
        }
        public string NomeTerceiro
        {
            get { return nomeTerceiro; }
            set
            {
                nomeTerceiro = value;
                OnPropertyChanged(nameof(NomeTerceiro));
            }
        }
        public string PontosTerceiro
        {
            get { return pontosTerceiro; }
            set
            {
                pontosTerceiro = value;
                OnPropertyChanged(nameof(PontosTerceiro));
            }
        }
        public string ImagemUser
        {
            get { return imagemUser; }
            set
            {
                imagemUser = value;
                OnPropertyChanged(nameof(ImagemUser));
            }
        }
        public string NomeUser
        {
            get { return nomeUser; }
            set
            {
                nomeUser = value;
                OnPropertyChanged(nameof(NomeUser));
            }
        }
        public string PontosUser
        {
            get { return pontosUser; }
            set
            {
                pontosUser = value;
                OnPropertyChanged(nameof(PontosUser));
            }
        }
        public int LugarUser
        {
            get { return lugarUser; }
            set
            {
                lugarUser = value;
                OnPropertyChanged(nameof(LugarUser));
            }
        }
        public string imagemPrimeiro { get; set; }
        public string nomePrimeiro { get; set; }
        public string pontosPrimeiro { get; set; }
        public string imagemSegundo { get; set; }
        public string nomeSegundo { get; set; }
        public string pontosSegundo { get; set; }
        public string imagemTerceiro { get; set; }
        public string nomeTerceiro { get; set; }
        public string pontosTerceiro { get; set; }
        public string imagemUser { get; set; }
        public string nomeUser { get; set; }
        public string pontosUser { get; set; }
        public int lugarUser { get; set; }

        public Command RefreshCommand { protected set; get; }
        public bool isRefreshing = false;
        public bool IsRefreshing
        {
            get
            {
                return isRefreshing;
            }
            set
            {
                isRefreshing = value;
                OnPropertyChanged(nameof(IsRefreshing));
            }
        }
    }
}