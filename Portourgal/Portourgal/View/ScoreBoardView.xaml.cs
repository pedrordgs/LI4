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
    public partial class ScoreBoardView : ContentPage
    {
        public ScoreBoardView()
        {
            InitializeComponent();
            BindingContext = new ScoreBoardViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = new ScoreBoardViewModel();
        }
    }
}