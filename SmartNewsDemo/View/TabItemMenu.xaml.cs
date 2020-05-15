using SmartNewsDemo.ViewModel;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms.Xaml;
using Rg.Plugins.Popup.Services;
using System;
using Xamarin.Forms;

namespace SmartNewsDemo.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabItemMenu : PopupPage
    {
        private TabItemMenuViewModel viewmodel = new TabItemMenuViewModel();
        public TabItemMenu()
        {
            InitializeComponent();
            this.BindingContext = viewmodel;
        }
        private async void CloseClick(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync();
        }
    }
}