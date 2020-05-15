using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartNewsDemo.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace SmartNewsDemo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterPage : Xamarin.Forms.TabbedPage
    {
        public static event EventHandler<object> SeletedItemEvent;
        public MasterPage(object items)
        {
            InitializeComponent();
            EventHandler<object> handler = SeletedItemEvent;
            handler?.Invoke(this, items);
            On<Xamarin.Forms.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
            On<Xamarin.Forms.PlatformConfiguration.Android>().SetIsSwipePagingEnabled(false);
        }
    }
}