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
            home.Height = 100;
            home.Width = 100;

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
            ScrollView scrollView = sender as ScrollView;
            var y = e.ScrollY;
            try
            {
                var size = scrollView.ContentSize.Height;
               
            }
            catch (Exception ex)
            {

            }
            //if (size - y < 600)
            //{
            //    home.Height = 100;
            //    home.Width = 100;
            //    //Application.Current.MainPage.DisplayAlert("Notification", "End page", "OK");
            //}
            //else if(size-y >600)
            //{

            //    home.Height = 150;
            //    home.Width = 150;
            //}
        }
    }
}