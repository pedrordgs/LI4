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
            ComandoDistrito = new Command(SelecionarDistrito);
        }

        void SelecionarDistrito(object d)
        {
            string distrito = ((string)d);
            Distrito dist = Distritos.Find(x => string.Equals(x.Nome, distrito));
            App.Current.MainPage.Navigation.PushAsync(new DistritosInfView(dist.ASCIIName));
        }

        public List<Distrito> Distritos { get; set; }
        public Command ComandoDistrito { get; }
    }
}
