using Portourgal.InteractionsAPI;
using Portourgal.Model;
using Portourgal.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Resources;
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
            ComandoRegistar = new Command(RegistarUtilizadorAsync);
        }

        public string Nome { get; set; }
        public string Cidade { get; set; }
        public string Distrito { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        async void RegistarUtilizadorAsync()   
        {
            List<Publicacao> hist = new List<Publicacao>();
            string type;
            byte[] data;
            var res = new ResourceReader(@".\ApplicationResources.resources");
            res.GetResourceData("defaultProfile.png", out type, out data);
            string base64String = Convert.ToBase64String(data);
            Utilizador u = new Utilizador(Nome, Cidade, Distrito, Email, Password, base64String, 0, hist);
            u = await UserInteraction.AddUtilizadorDB(u);
            App.Current.MainPage = new HomePage();
        }

        public Command ComandoRegistar { get; }
    }
}
