using Portourgal.Model;
using Portourgal.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Portourgal.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainContentPage : ContentPage
    {
        public MainContentPage()
        {
            InitializeComponent();
            BindingContext = new MainContentPageViewModel();
        }

        private void ImageClicked(object sender,EventArgs e)
        {
            string distrito = ((ImageButton)sender).ClassId;
            //DisplayAlert("Demo", distrito, "OK");
            Navigation.PushAsync(new DistritosInfView(distrito));
            //App.Current.MainPage = new NavigationPage(new DistritosInfView(distrito));
        }
    }
}