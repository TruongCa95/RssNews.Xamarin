using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using SmartNewsDemo.Utilitis;
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
        public SfTabItem tabItem;
        public static bool IsTapItem;
        public int countClick = 1;
        public Color ColorSelectionIndicator { get; set; }

        public int TabItemIndex { get; set; }

        #endregion

        #region Command
        public static event EventHandler<string> TappedItemEvent;
        public ICommand SelectionChangeCommand { get; set; }
        #endregion
        #region Data
        string[] ColorItems = { "Red", "Gold", "Orange", "Blue", "Green", "Silver" };
        string[] RssItems = {
            "https://cafebiz.vn/cong-nghe.rss",
            "https://gamek.vn/trang-chu.rss",
            "https://cafef.vn/trang-chu.rss",
            "https://thanhnien.vn/rss/home.rss",
            "https://tuoitre.vn/rss/tin-moi-nhat.rss",
            "https://tinhte.vn/rss"};
        #endregion

        public TabViewViewModel()
        {
            Tabitems = new TabItemCollection();
            SetContent();
            SelectionChangeCommand = new Command(HandleSelected);
            var setting = new HomeSettingViewModel();
            setting.UpdateStateStorage();
        }

        private void HandleSelected(object obj)
        {
            var index = TabItemIndex;
            var colors = ColorItems.GetValue(index).ToString();
            EventHandler<string> handler = TappedItemEvent;
            handler?.Invoke(this, colors);

        }

        public void SetContent()
        {
            var isConnected = HttpResponse.CheckNetwork();
            if (isConnected)
            {
                //Create Dictonary (color, url)
                IDictionary<string[], string[]> RssSource = new Dictionary<string[], string[]>();
                RssSource.Add(ColorItems, RssItems);
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
                            tabItem = new SfTabItem
                            {
                                HeaderContent = headers.Content,
                                //HeaderText=pieces,
                                Content = content.Content,
                                FontIconFontFamily = "Arial",
                                FontIconFontSize = 100
                            };
                            i += 1;
                            Tabitems.Add(tabItem);
                        }
                    }
                }
            }
        }
    }
}
