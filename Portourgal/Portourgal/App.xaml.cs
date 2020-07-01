using Portourgal.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Portourgal
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
            //MainPage = new DistritosInfView("Braga");
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
