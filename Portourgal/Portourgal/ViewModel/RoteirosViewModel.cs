using Portourgal.InteractionsAPI;
using Portourgal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Portourgal.ViewModel
{
    class RoteirosViewModel
    {
        public RoteirosViewModel()
        {
            Cidades = new List<string>();
            Cidades.Add("p1");
            Cidades.Add("p2");
            Cidades.Add("p3");
            Cidades.Add("p4");
            Cidades.Add("p5");
            Cidades.Add("p6");
            Descricao = "ASDASDASDASDASDASDASDASDA";
        }
        public RoteirosViewModel(Roteiro r)
        {
            Cidades = r.Percurso.Select(str => "&#x2022 " + str).ToList();
            Descricao = r.Descricao;
            ImagemPercurso = r.ImagemPercurso;
            Nome = r.Nome;
        }

        public List<string> Cidades { get; set; }
        public string Descricao { get; set; }
        public string ImagemPercurso { get; set; }
        public string Nome { get; set; }
    }
}
