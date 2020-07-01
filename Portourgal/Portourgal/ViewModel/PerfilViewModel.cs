using Portourgal.InteractionsAPI;
using Portourgal.View;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Portourgal.Model;
using System.Linq;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Portourgal.ViewModel
{

    class PerfilViewModel : INotifyPropertyChanged
    {

        public PerfilViewModel()
        {
            ComandoEditarPerfil = new Command(EntrarEditarUtilizadorAsync);
            ComandoLogout = new Command(TerminarSessaoAsync);
            RefreshCommand = new Command(RefreshList);
            NomeUtilizador = UserInteraction.user.Nome;
            Localidade =  UserInteraction.user.Cidade + ", " + UserInteraction.user.Distrito;
            TextoPontos = UserInteraction.user.Pontos + " pontos";
            Imagem = UserInteraction.user.Imagem;
            Historico = UserInteraction.user.Historico;
            ImagemCapa = DistritoInteraction.GetDistritos().Result.FirstOrDefault(d => d.Nome==UserInteraction.user.Distrito).Imagem;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        void RefreshList()
        {
            Historico = UserInteraction.user.Historico;
            IsRefreshing = false;
        }

        void TerminarSessaoAsync()
        {
            UserInteraction.terminarSessao();
            App.Current.MainPage = new NavigationPage(new MainPage());
        }

        void EntrarEditarUtilizadorAsync()
        {
            App.Current.MainPage.Navigation.PushAsync(new EditarPerfilView());
        }

        public string NomeUtilizador { get; }
        public string Localidade { get; }
        public string TextoPontos { get; }
        public string Imagem { get; }
        public string ImagemCapa { get; }
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
        public Command ComandoEditarPerfil { get; }
        public Command ComandoLogout { get; }


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
