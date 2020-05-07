using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using SmartNewsDemo.Common.Services.Interface;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SmartNewsDemo.ViewModel
{
    public class HomeSettingViewModel : BaseViewModel
    {
        #region properties, value
        public string Numbersize { get; set; }
        public Color BoldClick { get; set; }
        public Color ItalicClick { get; set; }
        public Color BadgeColor { get; set; }
        public Color NoneClick { get; set; }
        public bool ModeONOFF{ get; set; }
        public object ItemsFont { get; set; }
        public string MessageText { get; set; }
        public bool NotificationONOFF { get; set; }
        public string VersionApp { get; set; }
        public string BadgeNumber { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public List<string> ListFontFamily { get; set; } = new List<string>();
        string[] lstfont = { "FontAwesome", "serif", "Roboto", "Arial", "Samantha", "MarkerFelt-Thin" };
        #endregion
        #region command
        public ICommand LabelCLickCommand { get; set; }
        public ICommand SliderChangedCommand { get; set; }
        public ICommand SeletedFontCommand { get; set; }
        public ICommand ToggledModeCommand { get; set; }
        public ICommand PushLocalCommand { get; set; }
        public ICommand ScrollChangedCommand { get; set; }
        #endregion
        public HomeSettingViewModel()
        {
            LabelCLickCommand = new Command<string>(HandleLabelCLick);
            SliderChangedCommand = new Command(HandleSliderChanged);
            SeletedFontCommand = new Command(HandleSelectedFont);
            ToggledModeCommand = new Command(HandleToggledMode);
            PushLocalCommand = new Command(HandlePushLocal);
            ScrollChangedCommand = new Command(HandelScrollChanged);
            ListFontFamily.AddRange(lstfont);
            VersionApp = $"{VersionTracking.CurrentVersion}";
            //UpdateStateStorage();
        }

        private void HandelScrollChanged(object obj)
        {
            
        }

        private void HandlePushLocal(object obj)
        {
            if(NotificationONOFF)
            {
                if (!string.IsNullOrEmpty(MessageText))
                {
                    DependencyService.Get<ILocalNotificationService>().LocalNotification("Notification", MessageText);
                }
                else
                {
                    Application.Current.MainPage.DisplayAlert("Notification", "Please enter meassage", "OK");
                }
            }
            else
            {
                Application.Current.MainPage.DisplayAlert("Notification", "Please switch on notification", "OK");
            }
        }

        public void UpdateStateStorage()
        {
            if (Application.Current.Properties.ContainsKey("Mode"))
            {
                Numbersize = Application.Current.Properties["FontSize"].ToString();
                //ItemsFont = Application.Current.Properties["Font"].ToString();
                ModeONOFF = Convert.ToBoolean(Application.Current.Properties["Mode"]);
            }
            else
            {
                //Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                //{
                //    Application.Current.MainPage.DisplayAlert("Storage Status", "empty", "OK");
                //});
            }
        }
        #region events

        private void HandleToggledMode(object obj)
        {
            Application.Current.Properties["Mode"] = ModeONOFF;
            if (ModeONOFF)
            {
                Application.Current.Resources["labelStyleColor"] = "#232323";
                Application.Current.Resources["labelTextColor"] = "#FFFFFF";
                Application.Current.Properties["labelStyleColor"] = "#232323";
                Application.Current.Properties["labelTextColor"] = "#FFFFFF";
            }
            else
            {
                Application.Current.Resources["labelStyleColor"] = "#FFFFFF";
                Application.Current.Resources["labelTextColor"] = "#000000";
                Application.Current.Properties["labelStyleColor"] = "#FFFFFF";
                Application.Current.Properties["labelTextColor"] = "#000000";
            }
            Application.Current.SavePropertiesAsync();
        }
        private  void HandleSelectedFont(object obj)
        {
            if(ItemsFont!= null)
            {
                Application.Current.Resources["labelStyleFont"] = ItemsFont;
                Application.Current.Properties["Font"] = ItemsFont;
                Application.Current.SavePropertiesAsync();
            }
        }

        private void HandleSliderChanged(object obj)
        {
            double number;
            System.Globalization.CultureInfo EnglishCulture = new System.Globalization.CultureInfo("en-GB");
            if( double.TryParse(Numbersize,System.Globalization.NumberStyles.Number, EnglishCulture, out number))
            {
                var newStep = Math.Round(number, 0);
                Application.Current.Resources["labelStylesize"] = newStep;
                Application.Current.Properties["FontSize"] = newStep;
            }
            Application.Current.SavePropertiesAsync();
        }
        
        private async void HandleLabelCLick(string font)
        {
            if (font == "Bold")
            {
                BoldClick = Color.FromHex("#E7E0E4");
                Application.Current.Resources["labelStyleFontAtribute"] = FontAttributes.Bold;
                Application.Current.Properties["FontAtribute"] = FontAttributes.Bold;
                await Task.Delay(100);
                BoldClick = Color.White;
            }
            else if (font == "Italic")
            {
                ItalicClick = Color.FromHex("#E7E0E4");
                Application.Current.Resources["labelStyleFontAtribute"] = FontAttributes.Italic;
                Application.Current.Properties["FontAtribute"] = FontAttributes.Italic;
                await Task.Delay(100);
                ItalicClick = Color.White;
            }
            else
            {
                NoneClick = Color.FromHex("#E7E0E4");
                Application.Current.Resources["labelStyleFontAtribute"] = FontAttributes.None;
                Application.Current.Properties["FontAtribute"] = FontAttributes.None;
                await Task.Delay(100);
                NoneClick = Color.White;
            }
           await Application.Current.SavePropertiesAsync();
        }
        #endregion
    }
}
