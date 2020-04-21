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
    public partial class ContentDetail : ContentPage
    {
        public string url;
        public ContentDetail(string link)
        {
            InitializeComponent();
            BindingContext = new ContentViewModel(link);
            url = link;
        }
        //Back page
        async void OnBack(object sender, EventArgs args)
        {
            if (webViewDetail.CanGoBack)
            {
                webViewDetail.GoBack();
            }
            else
            {
                await Navigation.PopAsync();
            }
        }
        //Next Page
        void OnNext(object sender, EventArgs args)
        {
            if (webViewDetail.CanGoForward)
            {
                webViewDetail.GoForward();
            }
        }

        //load Page
        void webviewNavigating(object sender, WebNavigatingEventArgs e)
        {
            labelLoading.IsVisible = true;
        }

        void webviewNavigated(object sender, WebNavigatedEventArgs e)
        {
            labelLoading.IsVisible = false;
        }
        //Reload Page
        void OnRefresh(object sender, EventArgs args)
        {
            webViewDetail.Reload();
        }

    }
}