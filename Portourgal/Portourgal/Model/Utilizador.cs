using System;

namespace Portourgal.Model
{
    public class Utilizador
    {
        public Utilizador()
        {
            this.Nome = "";
            this.Cidade = "";
            this.Distrito = "";
            this.Email = "";
            this.Password = "";
        }

        public Utilizador(String n, String c, String d, String m, String p)
        {
            this.Nome = n;
            this.Cidade = c;
            this.Distrito = d;
            this.Email = m;
            this.Password = p;
        }

        public string Nome { get; set; }
        public string Cidade { get; set; }
        public string Distrito { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public bool Equals (Utilizador u)
        {
            return Nome == u.Nome && Cidade == u.Cidade && Distrito == u.Distrito && Email == u.Email && Password == u.Password;
        }

    }
}
