using Portourgal.View;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Portourgal.InteractionsAPI;

namespace Portourgal.ViewModel
{
    class EntrarViewModel
    {

        public EntrarViewModel()
        {
            Email = "";
            Password = "";
            ComandoEntrar = new Command(EntrarUtilizador);
        }

        public string Email { get; set; }
        public string Password { get; set; }

        public Command ComandoEntrar { get; }

        async void EntrarUtilizador()
        {
            bool b = await UserInteraction.AutenticaUtilizador(Email, Password);
            if (b) App.Current.MainPage = new HomePage();
            else await App.Current.MainPage.DisplayAlert("Login","As credenciais fornecidas não estão corretas", "OK");
        }
    }   
}