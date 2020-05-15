using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Newtonsoft.Json;
using SmartNewsDemo.Model;
using SmartNewsDemo.Utilitis.Extension_Method;
using SmartNewsDemo.View;
using Xamarin.Forms;

namespace SmartNewsDemo.ViewModel
{
    public class HomeMenuViewModel
    {
        #region properties
        public ObservableCollection<NewsPaper> NewsPapers { get; set; }
        public List<string> Banner { get; set; }
        public NewsPaper ItemSelected { get; set; }
        string[] banner = { "local:EmbeddedImage SmartNewsDemo.Common.Data.banner_Cafebiz.png", "local:EmbeddedImage SmartNewsDemo.Common.Data.Thumbnail.banner_Cafef.jpg", "local:EmbeddedImage SmartNewsDemo.Common.Data.Thumbnail.banner_Gamek.jpg" };
        #endregion
        #region command
        public ICommand SelectedCommand { get; set; }
        #endregion
        public HomeMenuViewModel()
        {
            SelectedCommand = new Command((async) =>
            {
                HandleSelected();
            });
            SetData();
            Banner = new List<string>();
            foreach (var item in banner)
            {
                Banner.Add(item);
            }
        }

        private async void HandleSelected()
        {
            if(ItemSelected!=null)
            {
                await Application.Current.MainPage.Navigation.PushAsync(new MasterPage(ItemSelected));
            }
        }

        private void SetData()
        {
            var jsonstring = ReadAndWriteFile.GetJsonData("ListNewpaperData.json");
            var result = JsonConvert.DeserializeObject<List<NewsPaper>>(jsonstring);
            NewsPapers = new ObservableCollection<NewsPaper>(result);
        }
    }
}
