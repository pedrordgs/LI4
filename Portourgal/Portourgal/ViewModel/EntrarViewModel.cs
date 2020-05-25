using Portourgal.View;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Portourgal.InteractionsAPI;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

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
            if (b) App.Current.MainPage = new NavigationPage(new HomePage());
            //if (b) App.Current.MainPage = new DistritosInfView("Braga");
            else await App.Current.MainPage.DisplayAlert("Login","As credenciais fornecidas não estão corretas", "OK");
        }
    }   
}