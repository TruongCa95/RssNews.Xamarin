using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SmartNewsDemo.Common.Services.Interface;
using Xamarin.Forms;

namespace SmartNewsDemo.ViewModel
{
    public class HomeSettingViewModel : BaseViewModel
    {
        #region properties, value
        public string Numbersize { get; set; }
        public Color BoldClick { get; set; }
        public Color ItalicClick { get; set; }
        public Color NoneClick { get; set; }
        public bool ModeONOFF{ get; set; }
        public object ItemsFont { get; set; }
        public string MessageText { get; set; }
        public bool NotificationONOFF { get; set; }
        public List<string> ListFontFamily { get; set; } = new List<string>();
        string[] lstfont = { "Lobster-Regular", "serif", "Times New Roman", "Arial", "MarkerFelt-Thin"};
        #endregion
        #region command
        public ICommand LabelCLickCommand { get; set; }
        public ICommand SliderChangedCommand { get; set; }
        public ICommand SeletedFontCommand { get; set; }
        public ICommand ToggledModeCommand { get; set; }
        public ICommand ToggledNotificationCommand { get; set; }
        public ICommand PushLocalCommand { get; set; }
        #endregion
        public HomeSettingViewModel()
        {
            LabelCLickCommand = new Command<string>(HandleLabelCLick);
            SliderChangedCommand = new Command(HandleSliderChanged);
            SeletedFontCommand = new Command(HandleSelectedFont);
            ToggledModeCommand = new Command(HandleToggledMode);
            ToggledNotificationCommand = new Command(HandleToggledNoti);
            PushLocalCommand = new Command(HandlePushLocal);
            ListFontFamily.AddRange(lstfont);
        }

        private void HandlePushLocal(object obj)
        {
            if(NotificationONOFF)
            {
                if (!string.IsNullOrEmpty(MessageText))
                {
                    //DependencyService.Get<ILocalNotificationService>().Cancel(0);
                    DependencyService.Get<ILocalNotificationService>().LocalNotification("Local Notification", MessageText);
                    Application.Current.MainPage.DisplayAlert("Notification", "Notification details saved successfully ", "Ok");
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
            try
            {
                if(Numbersize!= null|| !ModeONOFF|| ItemsFont!=null)
                {
                    Numbersize = Application.Current.Properties["FontSize"].ToString();
                    ItemsFont = Application.Current.Properties["Font"].ToString();
                    ModeONOFF = Convert.ToBoolean(Application.Current.Properties["Mode"]);
                }
                else
                {
                    Numbersize = "15";
                    ItemsFont = "MarkerFelt-Thin";
                    ModeONOFF = true;
                }
            }
            catch (Exception)
            {
                Numbersize = "15";
                ItemsFont = "MarkerFelt-Thin";
                ModeONOFF = false;
            }
        }
        #region events
        private void HandleToggledNoti(object obj)
        {
            if(!NotificationONOFF)
            {
                MessageText = string.Empty;
                DependencyService.Get<ILocalNotificationService>().Cancel(0);
            }
        }

        private void HandleToggledMode(object obj)
        {
            Application.Current.Resources["labelStyleColor"] = (ModeONOFF) ? "#232323" : "#FFFFFF";
            Application.Current.Properties["Mode"] = (ModeONOFF) ? "#232323" : "#FFFFFF";
        }
        private void HandleSelectedFont(object obj)
        {
            if(ItemsFont!= null)
            {
                Application.Current.Resources["labelStyleFont"] = ItemsFont;
                Application.Current.Properties["Font"] = ItemsFont;
            }
        }

        private void HandleSliderChanged(object obj)
        {
            Application.Current.Resources["labelStylesize"] = Convert.ToDouble(Numbersize);
            Application.Current.Properties["FontSize"] = Convert.ToDouble(Numbersize);
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
        }
        #endregion
    }
}
