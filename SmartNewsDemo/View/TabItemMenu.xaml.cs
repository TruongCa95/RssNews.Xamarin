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
    public partial class TabItemMenu : ContentPage
    {
        public TabItemMenu()
        {
            InitializeComponent();
            this.BindingContext = new TabItemMenuViewModel();
        }
    }
}