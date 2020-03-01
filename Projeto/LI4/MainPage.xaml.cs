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
        }

        int count = 0;
        void Entrar(object sender, System.EventArgs e)
        {
            count++;
            ((Button)sender).Text = $"Entraste {count} vezes.";
        }

        private void Registar(object sender, EventArgs e)
        {
            count++;
            ((Button)sender).Text = $"Registaste {count} vezes.";
        }
    }
}
