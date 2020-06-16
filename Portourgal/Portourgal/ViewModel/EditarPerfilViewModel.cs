﻿using Portourgal.InteractionsAPI;
using Portourgal.Model;
using Portourgal.View;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Portourgal.ViewModel
{
    class EditarPerfilViewModel
    {
        public EditarPerfilViewModel()
        {
            Imagem = "";
            /*
            Nome = UserInteraction.user.Nome;
            Email = UserInteraction.user.Email;
            Cidade = UserInteraction.user.Cidade;
            Distrito = UserInteraction.user.Distrito;
            Password = "";
            */
            Nome = "";
            Email = "";
            Cidade = "";
            Distrito = "";
            Password = "";
            ComandoEditar = new Command(EditarUtilizadorAsync);
        }

        async void EditarUtilizadorAsync()
        {
                if (Nome == "") Nome = UserInteraction.user.Nome;
                if (Email == "") Email = UserInteraction.user.Email;
                if (Cidade == "") Cidade = UserInteraction.user.Cidade;
                if (Distrito == "") Distrito = UserInteraction.user.Distrito;
                if (Password == "") Password = UserInteraction.user.Password;
                Utilizador u = new Utilizador(Nome, Cidade, Distrito, Email, Password);
                if (!u.Equals(UserInteraction.user))
                {
                    await App.Current.MainPage.DisplayAlert("Novo Perfil", u.Nome + " " + u.Email + " " + u.Cidade + " " + u.Distrito + " " + u.Password, "OK");
                    u = await UserInteraction.EditaUtilizador(UserInteraction.user.Email, u);     
                    await App.Current.MainPage.Navigation.PopAsync();
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Erro", "Não alterou nenhum elemento", "OK");
                }
        }

        public string Imagem { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cidade { get; set; }
        public string Distrito { get; set; }
        public string Password { get; set; }
        public Command ComandoEditar { get; }
    }
}