using LI4.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LI4
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
            NavigationPage.SetHasNavigationBar(this, false);
        }

        void Entrar(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new EntrarView());

        }

        private void Registar(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegistarView ());
        }
    }
}
