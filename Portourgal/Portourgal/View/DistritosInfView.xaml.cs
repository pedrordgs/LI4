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
        public DistritosInfView(Distrito distrito)
        {
            InitializeComponent();
            BindingContext = new DistritosInfViewModel(distrito);
        }
    }
}