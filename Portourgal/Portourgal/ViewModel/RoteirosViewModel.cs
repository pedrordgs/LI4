using Portourgal.InteractionsAPI;
using Portourgal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Portourgal.ViewModel
{
    class Info
    {
        public Info(string n, string i, string d)
        {
            Nome = n;
            Imagem = i;
            Distrito = d;
        }
        public string Nome { get; set; }
        public string Imagem { get; set; }
        public string Distrito { get; set; }
    }
    class InformacaoCaminho
    {
        public InformacaoCaminho(string c, string d, List<Info> a, List<Info> r, List<Info> h)
        {
            Cidade = c;
            Distrito = d;
            Atracoes = a;
            Restaurantes = r;
            Hoteis = h;
        }
        public string Cidade { get; set; }
        public string Distrito { get; set; }
        public List<Info> Atracoes{ get; set; }
        public List<Info> Restaurantes { get; set; }
        public List<Info> Hoteis { get; set; }
    }
    class RoteirosViewModel
    {
        public RoteirosViewModel(Roteiro r)
        {
            Cidades = r.Percurso.Select(str => "• " + str).ToList();
            Descricao = r.Descricao;
            ImagemPercurso = r.ImagemPercurso;
            Nome = r.Nome;
            List<Distrito> distritos = DistritoInteraction.GetDistritos().Result;
            List<Distrito> aux;
            Detalhes = new List<InformacaoCaminho>();
            r.Percurso.ForEach(c =>
            {
                aux = distritos.Where(d => d.Cidades.Where(city => city.Nome == c).Count() > 0).ToList();
                if (aux.Count() > 0)
                {
                    Cidade cid = aux[0].Cidades.Where(city => city.Nome == c).ToList()[0];
                    List<Info> at = new List<Info>();
                    List<Info> rest = new List<Info>();
                    List<Info> hot = new List<Info>();
                    cid.Atracoes.Take(2).ToList().ForEach(a => at.Add(new Info(a.Nome, a.Imagem, aux[0].Nome)));
                    cid.Restaurantes.Take(2).ToList().ForEach(re => rest.Add(new Info(re.Nome, re.Imagem, aux[0].Nome)));
                    cid.Hoteis.Take(2).ToList().ForEach(h => hot.Add(new Info(h.Nome, h.Imagem, aux[0].Nome)));
                    Detalhes.Add(new InformacaoCaminho(cid.Nome, aux[0].Nome, at, rest, hot));
                }
            });
        }

        public List<string> Cidades { get; set; }
        public string Descricao { get; set; }
        public string ImagemPercurso { get; set; }
        public string Nome { get; set; }
        public List<InformacaoCaminho> Detalhes { get; set; }
    }
}
