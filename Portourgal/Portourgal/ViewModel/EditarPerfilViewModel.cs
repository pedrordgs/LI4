using Plugin.Media;
using Portourgal.InteractionsAPI;
using Portourgal.Model;
using Portourgal.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace Portourgal.ViewModel
{
    class EditarPerfilViewModel : INotifyPropertyChanged
    {
        public EditarPerfilViewModel()
        {
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
            Imagem = UserInteraction.user.Imagem;
            NomeAntigo = UserInteraction.user.Nome;
            EmailAntigo = UserInteraction.user.Email;
            CidadeAntiga = UserInteraction.user.Cidade;
            DistritoAntigo = UserInteraction.user.Distrito;
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
                if (Nome == "") Nome = UserInteraction.user.Nome;
                if (Email == "") Email = UserInteraction.user.Email;
                if (Cidade == "") Cidade = UserInteraction.user.Cidade;
                if (Distrito == "") Distrito = UserInteraction.user.Distrito;
                if (Password == "") Password = UserInteraction.user.Password;
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
        public string Distrito { get; set; }
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
        public Command ComandoEditar { get; }
        public Command ComandoAlterarImagem { get; }
    }
}
