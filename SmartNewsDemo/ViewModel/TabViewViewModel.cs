﻿using System;
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
        public SfTabItem tabItem;
        #endregion

        #region Command
        public ICommand TappedCommand { get; private set; }
        #endregion
        #region Data
        string[] ColorItems = { "Red", "Gold", "Orange", "Blue", "Green","Red","Orange" };
        string[] RssItems = {
            "https://tinhte.vn/rss",
            "https://cafebiz.vn/cong-nghe.rss",
            "https://gamek.vn/trang-chu.rss",
            "https://cafef.vn/trang-chu.rss",
            "https://pcworld.com/index.rss",
            "https://tinhte.vn/rss"};
        #endregion

        public TabViewViewModel()
        {
            Tabitems = new TabItemCollection();
            SetContent();
            TappedCommand = new Command(HandleTappedItem);
        }

        private void HandleTappedItem(object obj)
        {
            Application.Current.MainPage.DisplayAlert("MessageBox", "Test", "OK");
        }

        public void SetContent()
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
