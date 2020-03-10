using System;
using System.Collections.Generic;
using System.Text;

namespace Portourgal.Model
{
    class Utilizador
    {
        private String nome;
        private String cidade;
        private String distrito;
        private String email;
        private String password;

        public Utilizador()
        {
            this.nome = "";
            this.cidade = "";
            this.distrito = "";
            this.email = "";
            this.password = "";
        }

        public Utilizador(String n, String c, String d, String m, String p)
        {
            this.nome = n;
            this.cidade = c;
            this.distrito = d;
            this.email = m;
            this.password = p;
        }

        public string Nome { get { return nome; } set { nome = value; } }
        public string Cidade { get { return cidade; } set { cidade = value; } }
        public string Distrito { get { return distrito; } set { distrito = value; } }
        public string Email { get { return email; } set { email = value; } }
        public string Password { get { return password; } set { password = value; } }

    }
}
