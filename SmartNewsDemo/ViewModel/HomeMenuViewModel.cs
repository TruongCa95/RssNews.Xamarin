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
        public List<Banners> Banner { get; set; }
        public NewsPaper ItemSelected { get; set; }
        public string JsonString;
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
            //Collection View Data
            JsonString= ReadAndWriteFile.GetJsonData("ListNewpaperData.json");
            var resultNews = JsonConvert.DeserializeObject<List<NewsPaper>>(JsonString);
            NewsPapers = new ObservableCollection<NewsPaper>(resultNews);
            //Image Slider Data
            JsonString = ReadAndWriteFile.GetJsonData("ListBannerData.json");
            Banner = JsonConvert.DeserializeObject<List<Banners>>(JsonString);
           
        }
    }
}
