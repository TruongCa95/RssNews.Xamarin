using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public object ItemsFont { get; set; }
        public List<string> ListFontFamily { get; set; } = new List<string>();
        string[] lstfont = { "Lobster-Regular", "serif", "Times New Roman", "Arial", "Calligraphy" };
        #endregion
        #region command
        public ICommand LabelCLickCommand { get; set; }
        public ICommand SliderChangedCommand { get; set; }
        public ICommand SeletedFontCommand { get; set; }
        #endregion
        public HomeSettingViewModel()
        {
            
            Numbersize = 15;
            LabelCLickCommand = new Command<string>(HandleLabelCLick);
            SliderChangedCommand = new Command(HandleSliderChanged);
            SeletedFontCommand = new Command(HandleSelectedFont);
            ListFontFamily.AddRange(lstfont);
        }

        private void HandleSelectedFont(object obj)
        {
            if(ItemsFont!= null)
            {
                Application.Current.Resources["labelStyleFont"] = ItemsFont;
                //Application.Current.Properties["labelStyleFont"] = ItemsFont;
            }
        }
        #region event
        private void HandleSliderChanged(object obj)
        {
            Application.Current.Resources["labelStylesize"] = Numbersize;
            //Application.Current.Properties["labelStylesize"] = Numbersize;
        }

        private async void HandleLabelCLick(string font)
        {
            if (font == "Bold")
            {
                BoldClick = Color.FromHex("#E7E0E4");
                Application.Current.Resources["labelStyleFontAtribute"] = FontAttributes.Bold;
                //Application.Current.Properties["labelStyleFontAtribute"] = FontAttributes.Bold;
                await Task.Delay(100);
                BoldClick = Color.White;
            }
            else if (font == "Italic")
            {
                ItalicClick = Color.FromHex("#E7E0E4");
                Application.Current.Resources["labelStyleFontAtribute"] = FontAttributes.Italic;
                //Application.Current.Properties["labelStyleFontAtribute"] = FontAttributes.Italic;
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
