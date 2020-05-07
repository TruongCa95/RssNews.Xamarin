using SmartNewsDemo.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartNewsDemo.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeSetting : ContentPage
    {
        private HomeSettingViewModel home = new HomeSettingViewModel();
        public HomeSetting()
        {
            InitializeComponent();
            BindingContext = home;
            home.Height = 150;
            home.Width = 150;

            if (Device.RuntimePlatform == Device.iOS)
            {
                NavigationPage.SetHasNavigationBar(this, true);
            }
            else if (Device.RuntimePlatform == Device.Android)
            {
                NavigationPage.SetHasNavigationBar(this, false);
            }
        }
        private void Handle_ScrollChanged(object sender, ScrolledEventArgs e)
        {
            var y = e.ScrollY;
            if (y > 0)
            {
                home.Height = 150 - y;
                home.Width = 150 - y;
            }
            else if (y < 0)
            {
                home.Height = 150 - y;
                home.Width = 150 - y;
            }
        }
    }
}