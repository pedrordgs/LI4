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
    public partial class EditarPerfilView : ContentPage
    {
        public EditarPerfilView()
        {
            InitializeComponent();
            BindingContext = new EditarPerfilViewModel();
        }
    }
}