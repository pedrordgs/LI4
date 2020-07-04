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
    class OtherPerfilViewModel : INotifyPropertyChanged
    {
        public OtherPerfilViewModel(string email)
        {
            Utilizador u = UserInteraction.GetUtilizador(email).Result;
            if (u == null) App.Current.MainPage.Navigation.PopAsync();
            Email = email;
            RefreshCommand = new Command(RefreshList);
            NomeUtilizador = u.Nome;
            Localidade = u.Cidade + ", " + u.Distrito;
            TextoPontos = u.Pontos + " pontos";
            Imagem = u.Imagem;
            Historico = u.Historico;
            ImagemCapa = DistritoInteraction.GetDistritos().Result.FirstOrDefault(d => d.Nome == u.Distrito).Imagem;
        }


        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        void RefreshList()
        {
            Utilizador u = UserInteraction.GetUtilizador(Email).Result;
            if (u == null) App.Current.MainPage.Navigation.PopAsync();
            Email = u.Email;
            RefreshCommand = new Command(RefreshList);
            NomeUtilizador = u.Nome;
            Localidade = u.Cidade + ", " + u.Distrito;
            TextoPontos = u.Pontos + " pontos";
            Imagem = u.Imagem;
            Historico = u.Historico;
            IsRefreshing = false;
        }
        public string NomeUtilizador
        {
            get { return nomeUtilizador; }
            set { nomeUtilizador = value; OnPropertyChanged(nameof(NomeUtilizador)); }
        }
        public string nomeUtilizador { get; set; }
        public string Localidade
        {
            get { return localidade; }
            set { localidade = value; OnPropertyChanged(nameof(Localidade)); }
        }
        public string localidade { get; set; }
        public string TextoPontos
        {
            get { return textoPontos; }
            set { textoPontos = value; OnPropertyChanged(nameof(TextoPontos)); }
        }
        public string textoPontos { get; set; }
        public string Imagem
        {
            get { return imagem; }
            set { imagem = value; OnPropertyChanged(nameof(Imagem)); }
        }
        public string imagem { get; set; }
        public string ImagemCapa 
        {
            get { return imagemCapa; } 
            set { imagemCapa = value; OnPropertyChanged(nameof(ImagemCapa)); }
        }
        public string imagemCapa { get; set; }
        public string Email { get; set; }
        public List<Publicacao> Historico
        {
            get { return historico; }
            set
            {
                historico = value;
                OnPropertyChanged(nameof(Historico));
            }
        }
        public List<Publicacao> historico { get; set; }

        public Command RefreshCommand { protected set; get; }
        public bool isRefreshing = false;

        public event PropertyChangedEventHandler PropertyChanged;

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
