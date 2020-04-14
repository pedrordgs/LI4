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

            /*
            var imagens = new List<string>{
                "https://img.freepik.com/vetores-gratis/imagens-animadas-abstratas-neon-lines_23-2148344065.jpg?size=626&ext=jpg",
                "https://image.freepik.com/vetores-gratis/fundo-de-linhas-abstratas-de-luz-de-neon_52683-13587.jpg"
            };
            */

            BindingContext = new MainContentPageViewModel();


            /*
            MainCarouselView.ItemsSource = imagens;
            MainCarouselViewA.ItemsSource = imagens;
            */
        }
    }
}