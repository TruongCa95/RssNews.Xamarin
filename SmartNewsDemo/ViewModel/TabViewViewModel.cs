using SmartNewsDemo.Utilitis;
using SmartNewsDemo.View;
using Syncfusion.XForms.TabView;
using System;
using Plugin.Connectivity;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;
using System.Threading.Tasks;
using Xamarin.Forms.PancakeView;

namespace SmartNewsDemo.ViewModel
{
    public class TabViewViewModel : BaseViewModel
    {
        #region properties,variable
        public TabItemCollection Tabitems { get; set; }
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

        #region Data
        string[] ColorItems = { "Red", "Gold", "Orange", "Blue", "Green", "Silver" };
        string[] RssItems = {
            "https://gamek.vn/trang-chu.rss",
            "https://cafef.vn/trang-chu.rss",
            "https://thanhnien.vn/rss/home.rss",
            "https://tuoitre.vn/rss/tin-moi-nhat.rss",
            "https://tinhte.vn/rss",
            "https://cafebiz.vn/cong-nghe.rss"};
        #endregion

        public TabViewViewModel()
        {
            Tabitems = new TabItemCollection();
            CheckConnected();
            CrossConnectivity.Current.ConnectivityChanged += Current_ConnectivityChanged;
            SelectionChangeCommand = new Command(HandleSelected);
            var setting = new HomeSettingViewModel();
            setting.UpdateStateStorage();
        }


        //private Xamarin.Forms.View GetItemContent(int index)
        //{
        //    return new TabItemContents(RssItems.GetValue(index).ToString()).Content;
        //}
        private void HandleSelected(object obj)
        {
            //Raise event selected and pass color to TabHeader
            var index = TabItemIndex;
            var colors = ColorItems.GetValue(index).ToString();
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
                    //if (item.Content == null)
                    //{
                    //    item.Content = GetItemContent(selectedIndex);
                    //}
                }
                else
                {
                    ((item.HeaderContent as StackLayout).Children[0] as PancakeView).Margin = new Thickness(0, 10, 0, 0);
                    ((item.HeaderContent as StackLayout).Children[0] as PancakeView).Padding = new Thickness(0, 0, 0, -6);
                }
            }
        }
        //Capture network status change
        private void Current_ConnectivityChanged(object sender, Plugin.Connectivity.Abstractions.ConnectivityChangedEventArgs e)
        {
            if (e.IsConnected)
            {
                Tabitems = new TabItemCollection();
                SetContent();
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
            if (CrossConnectivity.Current.IsConnected)
            {
                SetContent();
            }
            else
            {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    Application.Current.MainPage.DisplayAlert("No Internet Connection", "Please connect to Internet", "OK");
                });
            }
        }
        public void SetContent()
        {
            //Process Auto generate tabitem
            if (RssItems.Length != 0)
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
