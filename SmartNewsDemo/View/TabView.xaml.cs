using SmartNewsDemo.ViewModel;
using Syncfusion.XForms.TabView;
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
    public partial class TabView : ContentPage
    {
        private TabViewViewModel viewModel = new TabViewViewModel();
        public TabView()
        {
            InitializeComponent();
            this.BindingContext = viewModel;
        }
        //void TabView_TabItemTapped(object sender, TabItemTappedEventArgs e)
        //{

        //    if (e.TabItem.Title == "Favorites")
        //        e.Cancel = true;
        //}
    }
}