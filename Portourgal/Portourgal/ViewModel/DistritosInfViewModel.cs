using Portourgal.InteractionsAPI;
using Portourgal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Portourgal.ViewModel
{
    class DistritosInfViewModel
    {
        public DistritosInfViewModel(string distrito)
        {
            Distrito d = DistritoInteraction.GetDistritos(distrito).Result;
            Nome = d.Nome;
            Historia = d.Historia;
            Atracoes = new List<Atracao>();
            foreach(Cidade c in d.Cidades)
            {
                if (c.Atracoes != null)
                {
                    foreach (Atracao a in c.Atracoes)
                    {
                        Atracoes.Add(a);
                    }
                }
            }
            Restaurantes = new List<Restaurante>();
            foreach (Cidade c in d.Cidades)
            {
                if (c.Restaurantes != null)
                {
                    foreach (Restaurante r in c.Restaurantes)
                    {
                        Restaurantes.Add(r);
                    }
                }
            }
            Hoteis = new List<Hotel>();
            foreach (Cidade c in d.Cidades)
            {
                if (c.Hoteis != null)
                {
                    foreach (Hotel h in c.Hoteis)
                    {
                        Hoteis.Add(h);
                    }
                }
            }
        }

        public string Nome { get; set; }
        public string Historia { get; set; }
        public List<Atracao> Atracoes { get; set; }
        public List<Restaurante> Restaurantes { get; set; }
        public List<Hotel> Hoteis { get; set; }
    }
}
