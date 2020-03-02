﻿using LI4.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LI4.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistarView : ContentPage
    {
        public RegistarView()
        {
            InitializeComponent();
            BindingContext = new RegistarViewModel();
            NavigationPage.SetHasBackButton(this, true);
            NavigationPage.SetHasNavigationBar(this, true);
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#C65F4A");
        }
    }
}