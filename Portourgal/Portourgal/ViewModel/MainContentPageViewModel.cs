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
            Image = new Uri("https://img.itinari.com/pages/images/original/5b608edd-a690-49ba-8adf-3c5c0b44516f-istock-883146964.jpg?ch=DPR&dpr=1&w=1600&s=9d2d5b50305a4f9ffb411b649696d080");
            ComandoDistrito = new Command(SelecionarDistrito);
        }

        void SelecionarDistrito(object d)
        {
            string distrito = ((string)d);
            Distrito dist = Distritos.Find(x => string.Equals(x.Nome, distrito));
            App.Current.MainPage.Navigation.PushAsync(new DistritosInfView(dist));
        }

        public List<Distrito> Distritos { get; set; }
        public Command ComandoDistrito { get; }
        public Uri Image { get; }
    }
}
