using LI4.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace LI4.ViewModel
{
    class RegistarViewModel
    {
        string nome;
        string cidade;
        string distrito;
        string email;
        string password;

        public RegistarViewModel()
        {
            this.nome = "";
            this.cidade = "";
            this.distrito = "";
            this.email = "";
            this.password = "";
            ComandoRegistar = new Command(RegistarUtilizador);
        }

        public string Nome { get { return nome; } set { nome = value; } }
        public string Cidade { get { return cidade; } set { cidade = value; } }
        public string Distrito { get { return distrito; } set { distrito = value; } }
        public string Email { get { return email; } set { email = value; } }
        public string Password { get { return password; } set { password = value; } }

        void RegistarUtilizador()
        {
            new Utilizador(nome, cidade, distrito, email, password);
        }

        public Command ComandoRegistar { get; }
    }
}
