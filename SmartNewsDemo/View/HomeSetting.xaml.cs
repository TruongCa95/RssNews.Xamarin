using SmartNewsDemo.ViewModel;
using System;
using System.Collections.Generic;
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
        public HomeSetting()
        {
            InitializeComponent();
            BindingContext = new HomeSettingViewModel();
            if (Device.RuntimePlatform == Device.iOS)
            {
                NavigationPage.SetHasNavigationBar(this, true);
            }
            else if (Device.RuntimePlatform == Device.Android)
            {
                NavigationPage.SetHasNavigationBar(this, false);
            }
        }

        private void SwitchCell_OnChanged(object sender, ToggledEventArgs e)
        {
            Application.Current.Resources["labelStyleColor"] =(e.Value) ? "#232323" : "#FFFFFF";
        }
    }
}