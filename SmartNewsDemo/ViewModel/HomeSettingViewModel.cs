using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SmartNewsDemo.ViewModel
{
    public class HomeSettingViewModel:BaseViewModel
    {
        #region properties, value
        public double SliderValue { get; set; }
        public double Numbersize { get; set; }
        #endregion
        #region command
        public ICommand LabelCLikCommand { get; set; }
        #endregion
        public HomeSettingViewModel()
        {
            LabelCLikCommand = new Command(HandleLabelCLik);
        }

        private void HandleLabelCLik(object obj)
        {
            Application.Current.MainPage.DisplayAlert("OK", "TEST", "Cancel");
        }
    }
}
