using SmartNewsDemo.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartNewsDemo.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabView : ContentPage
    {
        public TabView()
        {
            InitializeComponent();
            this.BindingContext = new TabViewViewModel();
        }
    }
}