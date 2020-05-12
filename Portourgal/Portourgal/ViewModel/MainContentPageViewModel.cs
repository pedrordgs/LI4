using Portourgal.InteractionsAPI;
using Portourgal.Model;
using Portourgal.View;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Portourgal.ViewModel
{
    class MainContentPageViewModel
    {

        public MainContentPageViewModel()
        {
            Distritos = DistritoInteraction.GetDistritos().Result;
        }

        public List<Distrito> Distritos  { get; set; }
    }
}
