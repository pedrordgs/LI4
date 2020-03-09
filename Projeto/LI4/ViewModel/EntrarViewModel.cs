using LI4.View;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace LI4.ViewModel
{
    class EntrarViewModel
    {
        string email;
        string password;

        public EntrarViewModel()
        {
            this.email = "NULL";
            this.password = "NULL";
            ComandoEntrar = new Command(EntrarUtilizador);
        }

        public string Email { get; set; }
        public string Password { get; set; }
        
        public Command ComandoEntrar { get; }

        void EntrarUtilizador()
        {
            /*
             * Caso não se verifique o login tem que chamar este metodo
             * App.Current.MainPage.Navigation.PopAsync();
             */
            App.Current.MainPage = new HomePage();
        }
    }
}
