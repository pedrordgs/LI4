using Portourgal.Model;
using Portourgal.View;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Portourgal.ViewModel
{
    class RegistarViewModel
    {
        public RegistarViewModel()
        {
            this.Nome = "";
            this.Cidade = "";
            this.Distrito = "";
            this.Email = "";
            this.Password = "";
            ComandoRegistar = new Command(RegistarUtilizador);
        }

        public string Nome { get; set; }
        public string Cidade { get; set; }
        public string Distrito { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        void RegistarUtilizador()
        {
            Utilizador u = new Utilizador(Nome, Cidade, Distrito, Email, Password);
            _ = u.AddUtilizadorDB();
            App.Current.MainPage = new HomePage();
        }

        public Command ComandoRegistar { get; }
    }
}
