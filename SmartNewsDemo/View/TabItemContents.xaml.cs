using SmartNewsDemo.Model;
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
    public partial class TabItemContents : ContentPage
    {
        public TabItemContents(string url)
        {
            InitializeComponent();
            this.BindingContext = new TabItemContenViewModel(url);
        }
    }
}