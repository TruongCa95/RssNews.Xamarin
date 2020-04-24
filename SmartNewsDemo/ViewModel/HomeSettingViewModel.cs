using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SmartNewsDemo.ViewModel
{
    public class HomeSettingViewModel : BaseViewModel
    {
        #region properties, value
        public double SliderValue { get; set; }
        public double Numbersize { get; set; }
        public Color BoldClick { get; set; }
        public Color ItalicClick { get; set; }
        public Color NoneClick { get; set; }
        #endregion
        #region command
        public ICommand LabelCLickCommand { get; set; }
        public ICommand SliderChangedCommand { get; set; }
        #endregion
        public HomeSettingViewModel()
        {
            Numbersize = 15;
            LabelCLickCommand = new Command<string>(HandleLabelCLik);
            SliderChangedCommand = new Command(HandleSliderChanged);
        }
        #region event
        private void HandleSliderChanged(object obj)
        {
            Application.Current.Resources["labelStylesize"] = Numbersize;
        }

        private async void HandleLabelCLik(string font)
        {
            if (font == "Bold")
            {
                BoldClick = Color.FromHex("#E7E0E4");
                Application.Current.Resources["labelStyleFontAtribute"] = FontAttributes.Bold;
                await Task.Delay(100);
                BoldClick = Color.White;
            }
            else if (font == "Italic")
            {
                ItalicClick = Color.FromHex("#E7E0E4");
                Application.Current.Resources["labelStyleFontAtribute"] = FontAttributes.Italic;
                await Task.Delay(100);
                ItalicClick = Color.White;
            }
            else
            {
                NoneClick = Color.FromHex("#E7E0E4");
                Application.Current.Resources["labelStyleFontAtribute"] = FontAttributes.None;
                await Task.Delay(100);
                NoneClick = Color.White;
            }
        }
        #endregion
    }
}
