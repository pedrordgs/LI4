using Portourgal.InteractionsAPI;
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
    public partial class DistritosInfView : ContentPage
    {
        public DistritosInfView(string distritoASCII)
        {
            InitializeComponent();
            BindingContext = new DistritosInfViewModel(distritoASCII);
        }
    }
}