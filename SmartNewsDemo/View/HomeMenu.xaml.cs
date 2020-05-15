using System;
using System.Collections.Generic;
using SmartNewsDemo.ViewModel;
using Xamarin.Forms;

namespace SmartNewsDemo.View
{
    public partial class HomeMenu : ContentPage
    {
        public HomeMenu()
        {
            InitializeComponent();
            this.BindingContext = new HomeMenuViewModel();
        }
    }
}
