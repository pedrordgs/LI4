using System;
using System.Collections.Generic;

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
            this.Imagem = "";
            this.Pontos = 0;
            this.Historico = new List<Publicacao>();
        }

        public Utilizador(String n, String c, String d, String m, String p, String i, int pontos, List<Publicacao> h)
        {
            this.Nome = n;
            this.Cidade = c;
            this.Distrito = d;
            this.Email = m;
            this.Password = p;
            this.Imagem = i;
            this.Pontos = pontos;
            this.Historico = h;
        }

        public string Nome { get; set; }
        public string Cidade { get; set; }
        public string Distrito { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Imagem { get; set; }
        public int Pontos { get; set; }
        public List<Publicacao> Historico { get; set; }

        public bool Equals (Utilizador u)
        {
            return Nome == u.Nome && Cidade == u.Cidade && Distrito == u.Distrito && Email == u.Email && Password == u.Password && Imagem == u.Imagem;
        }

    }
}
