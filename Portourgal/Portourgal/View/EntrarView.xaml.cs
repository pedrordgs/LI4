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
    public partial class EntrarView : ContentPage
    {
        public EntrarView()
        {
            InitializeComponent();
            BindingContext = new EntrarViewModel();
            NavigationPage.SetHasBackButton(this, true);
            NavigationPage.SetHasNavigationBar(this, true);
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#C65F4A");
        }
    }
}