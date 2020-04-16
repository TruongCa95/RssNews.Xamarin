using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using SmartNewsDemo.View;
using Syncfusion.XForms.TabView;
using Xamarin.Forms;
using TabItem = Xam.Plugin.TabView.TabItem;

namespace SmartNewsDemo.ViewModel
{
    public class TabViewViewModel : BaseViewModel
    {
        #region properties,variable
        public TabItemCollection Tabitems { get; set; }
        public SfTabView tabView;
        public SelectionIndicatorSettings Setting { get; set; }
        #endregion

        #region Command
        public ICommand Backcommand { get; private set; }
        #endregion
        #region Data
        string[] ColorItems = { "Red", "Gold", "Orange", "Blue", "Green","Red","Orange" };
        string[] RssItems = {
            "https://tinhte.vn/rss",
            "https://laodong.vn/rss/home.rss",
            "https://cafebiz.vn/cong-nghe.rss",
            "https://gamek.vn/trang-chu.rss",
            "https://cafef.vn/trang-chu.rss",
            "https://pcworld.com/index.rss",
            "https://tinhte.vn/rss"};
        #endregion

        public TabViewViewModel()
        {
            SetContent();
            Backcommand = new Command(BackPage);
        }

        private async void BackPage(object obj)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new TabView());
        }

        public void SettingIndicator()
        {
            var selectionIndicatorSettings = new SelectionIndicatorSettings();
            selectionIndicatorSettings.Color = Color.Transparent;
            selectionIndicatorSettings.Position = SelectionIndicatorPosition.Bottom;
            selectionIndicatorSettings.StrokeThickness = -100;
            selectionIndicatorSettings.AnimationDuration = 5;
            Setting = selectionIndicatorSettings;
        }
        public void SetContent()
        {
            //Create Dictonary (color, url)
            IDictionary<string[], string[]> RssSource = new Dictionary<string[], string[]>();
            RssSource.Add(ColorItems, RssItems);
            Tabitems = new TabItemCollection();
            //Process Auto generate tabitem
            if (RssSource.Count != 0)
            {
                int i = 0;
                foreach (var itemRss in RssItems)
                {
                    var NamePath = itemRss.Substring(8);
                    int index = NamePath.IndexOf('.');
                    if (index > 0)
                    {
                        var pieces = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(NamePath.Substring(0, index).ToLower());
                        TabItemContents content = new TabItemContents(itemRss);
                        TabItemHeaders headers = new TabItemHeaders(pieces, ColorItems.GetValue(i).ToString());
                        var TabElement = new SfTabItem
                        {
                            
                            HeaderContent = headers.Content,
                            Content = content.Content,
                            FontIconFontFamily = "Arial",
                            FontIconFontSize = 100
                        };
                        i += 1;
                        Tabitems.Add(TabElement);
                    }
                }
            }
        }
    }
}
