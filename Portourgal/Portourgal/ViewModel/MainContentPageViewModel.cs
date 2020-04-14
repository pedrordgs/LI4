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
            GetListaDistritos();
        }

        async void GetListaDistritos()
        {
            Distritos = await DistritoInteraction.GetDistritos();
            //Pd = Distritos[0].Nome;
        }

        public List<Distrito> Distritos  { get; set; }
        public string Pd { get; set; } 
    }
}
