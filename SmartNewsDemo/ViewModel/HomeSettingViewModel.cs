using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using SmartNewsDemo.Common.Services.Interface;
using SmartNewsDemo.Utilitis.ExtensionMethod;
using SmartNewsDemo.View;
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
        public bool ModeONOFF { get; set; }
        public int numberNoti = 0;
        public object ItemsFont { get; set; }
        public string MessageText { get; set; }
        public bool NotificationONOFF { get; set; }
        public string VersionApp { get; set; }
        public string BadgeNumber { get; set; }
        public double ImageSize { get; set; }
        public List<string> ListFontFamily { get; set; } = new List<string>();
        string[] lstfont = { "FontAwesome", "serif", "Roboto", "Arial", "Samantha", "MarkerFelt-Thin" };
        #endregion
        #region command
        public ICommand LabelCLickCommand { get; set; }
        public ICommand SliderChangedCommand { get; set; }
        public ICommand SeletedFontCommand { get; set; }
        public ICommand ToggledModeCommand { get; set; }
        public ICommand PushLocalCommand { get; set; }
        public ICommand ScrollVerticalCommand { get; set; }
        public ICommand OpenPopupCommand { get; set; }
        public static event EventHandler<int> NotificationEvent;
        #endregion
        public HomeSettingViewModel()
        {
            LabelCLickCommand = new Command<string>(HandleLabelCLick);
            SliderChangedCommand = new Command(HandleSliderChanged);
            SeletedFontCommand = new Command(HandleSelectedFont);
            ToggledModeCommand = new Command(HandleToggledMode);
            PushLocalCommand = new Command(HandlePushLocal);
            ScrollVerticalCommand = new Command(HandelScrollChanged);
            OpenPopupCommand = new Command((async) =>
            {
                HandleOpenPopup();
            }) ;
            ListFontFamily.AddRange(lstfont);
            VersionApp = $"{VersionTracking.CurrentVersion}";
            ImageSize = 200;
            //UpdateStateStorage();
        }

        #region event
        private async void HandleOpenPopup()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new TabItemMenu());
        }
        private void HandelScrollChanged(object obj)
        {
            ScrollView sender = obj as ScrollView;
            var minHeight = 50;
            var maxHeight = 200;
            var buffer = 5;
            var y = sender.ScrollY;
            {
                var NewY = ToDoubleExtension.ConvertToDouble(y,0);
                //scroll down
                if (NewY < 0)
                {
                    if (ImageSize - NewY >= minHeight && ImageSize - NewY < maxHeight)
                    {
                        ImageSize -= NewY;
                    }
                }
                //scroll up
                else if (NewY > 0)
                {
                    if (ImageSize - NewY >= minHeight && ImageSize - NewY < maxHeight)
                    {
                        ImageSize -= (NewY/ buffer);
                    }
                }
                else return;
                Console.WriteLine(ImageSize.ToString() + " y:" + y.ToString());
            }
        }

        private void HandlePushLocal(object obj)
        {
            if (NotificationONOFF)
            {
                if (!string.IsNullOrEmpty(MessageText))
                {
                    DependencyService.Get<ILocalNotificationService>().LocalNotification("Notification", MessageText);
                    EventHandler<int> handler = NotificationEvent;
                    handler?.Invoke(this, numberNoti);
                    numberNoti += 1;
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
        private void HandleSelectedFont(object obj)
        {
            if (ItemsFont != null)
            {
                Application.Current.Resources["labelStyleFont"] = ItemsFont;
                Application.Current.Properties["Font"] = ItemsFont;
                Application.Current.SavePropertiesAsync();
            }
        }

        private void HandleSliderChanged(object obj)
        {

            var newStep = ToDoubleExtension.ConvertToDouble(Convert.ToDouble(Numbersize),0);
            Application.Current.Resources["labelStylesize"] = newStep;
            Application.Current.Properties["FontSize"] = newStep;
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
