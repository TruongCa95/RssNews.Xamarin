using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Essentials;
using System.Windows.Input;
using SmartNewsDemo.Model;
using SmartNewsDemo.View;
using Syncfusion.XForms.TabView;
using Xamarin.Forms;
using Xamarin.Forms.PancakeView;

namespace SmartNewsDemo.ViewModel
{
    public class TabViewViewModel : BaseViewModel
    {
        #region properties,variable
        public TabItemCollection Tabitems { get; set; }
        public List<string> ColorItems;
        public SfTabItem tabItem;
        public bool isConnected;
        public int countClick = 1;
        public Color ColorSelectionIndicator { get; set; }

        public int TabItemIndex { get; set; }
        #endregion

        #region Command
        //Raise event when select item header
        public static event EventHandler<string> SelectedItemEvent;
        public ICommand SelectionChangeCommand { get; set; }
        #endregion

        public TabViewViewModel()
        {
            Tabitems = new TabItemCollection();
            CheckConnected();
            Connectivity.ConnectivityChanged += Current_ConnectivityChanged;
            SelectionChangeCommand = new Command(HandleSelected);
        }

        private void HandleSelected(object obj)
        {
            //Raise event selected and pass color to TabHeader
            var index = TabItemIndex;
            var colors = ColorItems[index].ToString();
            EventHandler<string> handler = SelectedItemEvent;
            handler?.Invoke(this, colors);

            //get property element in list header
            TabItemCollection tabItems = (obj as SfTabView).Items;
            foreach (var item in tabItems)
            {
                int selectedIndex = tabItems.IndexOf(item);

                if (selectedIndex == index)
                {
                    ((item.HeaderContent as StackLayout).Children[0] as PancakeView).Margin = new Thickness(0, 5, 0, 0);
                    ((item.HeaderContent as StackLayout).Children[0] as PancakeView).Padding = new Thickness(0, 0, 0, -1);
                }
                else
                {
                    ((item.HeaderContent as StackLayout).Children[0] as PancakeView).Margin = new Thickness(0, 10, 0, 0);
                    ((item.HeaderContent as StackLayout).Children[0] as PancakeView).Padding = new Thickness(0, 0, 0, -6);
                }
            }
        }
        //Capture network status change
        private void Current_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            var access = e.NetworkAccess;
            if (access == NetworkAccess.Internet)
            {
                Tabitems = new TabItemCollection();
                MasterPage.SeletedItemEvent += MasterPage_SeletedItemEvent;
            }
            else
            {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    Application.Current.MainPage.DisplayAlert("No Internet Connection", "Please connect to Internet", "OK");
                });
            }
        }
        //Check Network
        public void CheckConnected()
        {
            var current = Connectivity.NetworkAccess;

            if (current == NetworkAccess.Internet)
            {
                MasterPage.SeletedItemEvent += MasterPage_SeletedItemEvent;
            }
            else
            {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    Application.Current.MainPage.DisplayAlert("No Internet Connection", "Please connect to Internet", "OK");
                });
            }
            //var profiles = Connectivity.ConnectionProfiles;
            //if (profiles.Contains(ConnectionProfile.WiFi))
            //{
            //    // Active Wi-Fi connection.
            //}
        }

        private void MasterPage_SeletedItemEvent(object sender, object e)
        {
            if(e!=null)
            {
                NewsPaper newsPaper = (NewsPaper)e;
                var RssItems = newsPaper.NewsCategory;
                ColorItems = newsPaper.NewsCategoryColor;
                //Process Auto generate tabitem
                for(int i=0; i<RssItems.Count;i++)
                {
                    int idx = RssItems[i].LastIndexOf('/');
                    var NamePath = RssItems[i].Substring(idx + 1);
                    var TrimPath = NamePath.Replace("-", string.Empty);
                    //find index '.' first in string
                    int index = TrimPath.IndexOf('.');
                    if (index > 0)
                    {
                        var pieces = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(TrimPath.Substring(0, index).ToLower());
                        TabItemContents content = new TabItemContents(RssItems[i]);
                        TabItemHeaders headers = new TabItemHeaders(pieces, ColorItems[i].ToString());
                        tabItem = new SfTabItem
                        {
                            HeaderContent = headers.Content,
                            Content = content.Content,
                        };
                        Tabitems.Add(tabItem);
                    }
                }
            }
        }
    }
}
