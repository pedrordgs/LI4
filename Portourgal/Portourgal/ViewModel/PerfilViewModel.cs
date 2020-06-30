using Portourgal.InteractionsAPI;
using Portourgal.View;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Portourgal.Model;

namespace Portourgal.ViewModel
{

    class PerfilViewModel
    {

        public PerfilViewModel()
        {
            ComandoEditarPerfil = new Command(EntrarEditarUtilizadorAsync);
            NomeUtilizador = UserInteraction.user.Nome;
            Localidade =  UserInteraction.user.Cidade + ", " + UserInteraction.user.Distrito;
            TextoPontos = UserInteraction.user.Pontos + " pontos";
            Imagem = UserInteraction.user.Imagem;
            Historico = UserInteraction.user.Historico;
            Historico.Reverse();
        }

        void EntrarEditarUtilizadorAsync()
        {
            App.Current.MainPage.Navigation.PushAsync(new EditarPerfilView());
        }

        public string NomeUtilizador { get; }
        public string Localidade { get; }
        public string TextoPontos { get; }
        public string Imagem { get; }
        public List<Publicacao> Historico { get; }
        public Command ComandoEditarPerfil { get; }
    }
}
