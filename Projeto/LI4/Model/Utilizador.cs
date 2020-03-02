using System;
using System.Collections.Generic;
using System.Text;

namespace LI4.Model
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

        public Utilizador (String n, String c, String d, String m, String p)
        {
            this.nome = n;
            this.cidade = c;
            this.distrito = d;
            this.email = m;
            this.password = p;
        }

        public String getNome()
        {
            return this.nome;
        }

        public void setNome(String n)
        {
            this.nome = n;
        }

        public String getCidade()
        {
            return this.cidade;
        }

        public void setCidade(String c)
        {
            this.cidade = c;
        }

        public String getDistrito()
        {
            return this.distrito;
        }

        public void setDistrito(String d)
        {
            this.distrito = d;
        }

        public String getEmail()
        {
            return this.email;
        }

        public void setEmail(String u)
        {
            this.email = u;
        }

        public String getPassword()
        {
            return this.password;
        }

        public void setPassword(String u)
        {
            this.password = u;
        }

    }
}
