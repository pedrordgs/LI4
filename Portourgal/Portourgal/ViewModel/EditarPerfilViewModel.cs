using Plugin.Media;
using Portourgal.InteractionsAPI;
using Portourgal.Model;
using Portourgal.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace Portourgal.ViewModel
{
    class EditarPerfilViewModel : INotifyPropertyChanged
    {
        public EditarPerfilViewModel()
        {
            Nome = "";
            Email = "";
            Cidade = "";
            Distrito = "";
            Password = "";
            Imagem = UserInteraction.user.Imagem;
            NomeAntigo = UserInteraction.user.Nome;
            EmailAntigo = UserInteraction.user.Email;
            CidadeAntiga = UserInteraction.user.Cidade;
            DistritoAntigo = UserInteraction.user.Distrito;
            ListaDistritos = DistritoInteraction.GetDistritos().Result;
            Distritos = ListaDistritos.Select(d => d.Nome).ToList();
            Cidades = ListaDistritos.Select(d => d.Cidades.Select(c => c.Nome).ToList()).SelectMany(x => x).ToList();
            ComandoEditar = new Command(EditarUtilizadorAsync);
            ComandoAlterarImagem = new Command(EditarImagemPerfilAsync);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        async void EditarUtilizadorAsync()
        {
            if (Email != "" && UserInteraction.GetUtilizador(Email).Result != null)
            {
                await App.Current.MainPage.DisplayAlert("ERRO", "O email indicado já está a ser utilizado", "OK");
                return;
            }
            if (Nome == "") Nome = UserInteraction.user.Nome;
            if (Email == "") Email = UserInteraction.user.Email;
            if (Cidade == "" || Cidade==null) Cidade = UserInteraction.user.Cidade;
            if (Distrito == "" || Distrito==null) Distrito = UserInteraction.user.Distrito;
            if (Password == "") Password = UserInteraction.user.Password;
            else
            {
                byte[] data = Encoding.ASCII.GetBytes(Password);
                data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
                Password = Encoding.ASCII.GetString(data);
            }
            if (Imagem == "") Imagem = UserInteraction.user.Imagem;
            Utilizador u = new Utilizador(Nome, Cidade, Distrito, Email, Password, Imagem, UserInteraction.user.Pontos, UserInteraction.user.Historico);
            if (!u.Equals(UserInteraction.user))
            {
                u = await UserInteraction.EditaUtilizador(UserInteraction.user.Email, u);     
                await App.Current.MainPage.Navigation.PopAsync();
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Erro", "Não alterou nenhum elemento", "OK");
                return;
            }
        }

        async void EditarImagemPerfilAsync()
        {
            try
            {
                var media = CrossMedia.Current;

                //pick photo
                var file = await media.PickPhotoAsync();

                // wait until the file is written
                while (File.ReadAllBytes(file.Path).Length == 0)
                {
                    System.Threading.Thread.Sleep(1);
                }

                var stream = file.GetStream();
                var bytes = new byte[stream.Length];
                await stream.ReadAsync(bytes, 0, (int)stream.Length);
                string base64 = System.Convert.ToBase64String(bytes);

                Imagem = base64;
            }
            catch (NullReferenceException e) { }
        }


        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cidade { get; set; }
        public string Distrito
        {
            get { return distrito; }
            set
            {
                distrito = value;
                if (Distrito != "" && Distrito != null) Cidades = ListaDistritos.FirstOrDefault(x => x.Nome == Distrito).Cidades.Select(c => c.Nome).ToList();
            }
        }
        public string distrito { get; set; }
        public string Password { get; set; }
        public string Imagem 
        {
            get { return imagem; }  
            set 
            { 
                imagem = value;
                OnPropertyChanged(nameof(Imagem));
            }
        }
        public string imagem { get; set; }
        public string NomeAntigo { get; set; }
        public string EmailAntigo { get; set; }
        public string CidadeAntiga { get; set; }
        public string DistritoAntigo { get; set; }
        public string PasswordAntiga { get; set; }
        public List<string> Distritos { get; set; }
        public List<string> Cidades
        {
            get { return cidades; }
            set { cidades = value; OnPropertyChanged(nameof(Cidades)); }
        }
        public List<string> cidades { get; set; }
        public List<Distrito> ListaDistritos { get; set; }
        public Command ComandoEditar { get; }
        public Command ComandoAlterarImagem { get; }
    }
}
