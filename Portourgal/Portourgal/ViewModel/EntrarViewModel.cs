﻿using Portourgal.View;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Portourgal.ViewModel
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

        public string Email { get { return email; } set { email = value; } }
        public string Password { get { return password; } set { password = value; } }

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