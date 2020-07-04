using Portourgal.InteractionsAPI;
using Portourgal.Model;
using Portourgal.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using Xamarin.Forms;

namespace Portourgal.ViewModel
{
    class RegistarViewModel : INotifyPropertyChanged
    {
        public RegistarViewModel()
        {
            this.Nome = "";
            this.Cidade = "";
            this.Distrito = "";
            this.Email = "";
            this.Password = "";
            ListaDistritos = DistritoInteraction.GetDistritos().Result;
            Distritos = ListaDistritos.Select(d => d.Nome).ToList();
            Cidades = ListaDistritos.Select(d => d.Cidades.Select(c=>c.Nome).ToList()).SelectMany(x=>x).ToList();
            ComandoRegistar = new Command(RegistarUtilizadorAsync);
            ComandoComConta = new Command(JaTemConta);
        }

        async void RegistarUtilizadorAsync()
        {
            if (Email == "" || Cidade == "" || Cidade == null || Distrito == null || Distrito == "" || Nome == "" || Password == "")
            {
                await App.Current.MainPage.DisplayAlert("ERRO", "Preencha todos os campos", "OK");
                return;
            }
            if (UserInteraction.GetUtilizador(Email).Result != null)
            {
                await App.Current.MainPage.DisplayAlert("ERRO", "O email indicado já está a ser utilizado", "OK");
                return;
            }
            List<Publicacao> hist = new List<Publicacao>();
            byte[] data = Encoding.ASCII.GetBytes(Password);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            String hashPassword = Encoding.ASCII.GetString(data);
            Utilizador u = new Utilizador(Nome, Cidade, Distrito, Email, hashPassword, "", 0, hist);
            u = await UserInteraction.AddUtilizadorDB(u);
            App.Current.MainPage = new NavigationPage(new HomePage());
        }

        void JaTemConta()
        {
            App.Current.MainPage.Navigation.PushAsync(new EntrarView());
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string Nome { get; set; }
        public string Cidade { get; set; }
        public string Distrito 
        {
            get { return distrito; }
            set 
            {
                distrito = value;
                if (Distrito!="" && Distrito!=null) Cidades = ListaDistritos.FirstOrDefault(x => x.Nome == Distrito).Cidades.Select(c => c.Nome).ToList();
            }
        }
        public string distrito { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<string> Distritos { get; set; }
        public List<string> Cidades 
        {
            get { return cidades; }
            set { cidades = value; OnPropertyChanged(nameof(Cidades)); }
        }

        public List<string> cidades { get; set; }
        public List<Distrito> ListaDistritos { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

       
        public Command ComandoRegistar { get; }
        public Command ComandoComConta { get; set; }
 
    }
}
