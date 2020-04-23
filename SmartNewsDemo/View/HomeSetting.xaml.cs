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
        }
        private void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            Application.Current.Resources["labelStylesize"] = e.NewValue;
        }
    }
}