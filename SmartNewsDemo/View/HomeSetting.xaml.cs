using SmartNewsDemo.ViewModel;
using System;
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

            //if (Device.RuntimePlatform == Device.iOS)
            //{
            //    NavigationPage.SetHasNavigationBar(this, true);
            //}
            //else if (Device.RuntimePlatform == Device.Android)
            //{
            //    NavigationPage.SetHasNavigationBar(this, false);
            //}
        }
    }
}