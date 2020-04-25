using Portourgal.InteractionsAPI;
using Portourgal.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portourgal.ViewModel
{
    class MainContentPageViewModel
    {

        public MainContentPageViewModel()
        {
            Distritos = DistritoInteraction.GetDistritos().Result;
            //Distritos = new List<Distrito>();
            //Distritos.Add(new Distrito("Aveiro", "", new List<Cidade>()));
            //Distritos.Add(new Distrito("Braga", "", new List<Cidade>()));
            //Distritos.Add(new Distrito("Beja", "", new List<Cidade>()));
            //Distritos.Add(new Distrito("Evora", "", new List<Cidade>()));
            //Distritos.Add(new Distrito("Porto", "", new List<Cidade>()));
            //Distritos.Add(new Distrito("Lisboa", "", new List<Cidade>()));
            //Distritos.Add(new Distrito("Portalegre", "", new List<Cidade>()));
            //Distritos.Add(new Distrito("Bragança", "", new List<Cidade>()));
            //Distritos.Add(new Distrito("Aveiro", "", new List<Cidade>()));
            //Distritos.Add(new Distrito("Braga", "", new List<Cidade>()));
            //Distritos.Add(new Distrito("Beja", "", new List<Cidade>()));
            //Distritos.Add(new Distrito("Evora", "", new List<Cidade>()));
            //Distritos.Add(new Distrito("Porto", "", new List<Cidade>()));
            //Distritos.Add(new Distrito("Lisboa", "", new List<Cidade>()));
            //Distritos.Add(new Distrito("Portalegre", "", new List<Cidade>()));
            //Distritos.Add(new Distrito("Bragança", "", new List<Cidade>()));
            //Distritos.Add(new Distrito("Portalegre", "", new List<Cidade>()));
            //Distritos.Add(new Distrito("Bragança", "", new List<Cidade>()));
            Pd = Distritos[0].Nome;
        }

        public List<Distrito> Distritos  { get; set; }
        public string Pd { get; set; } 
    }
}
