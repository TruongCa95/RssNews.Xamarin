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
        public NewsPaper ItemSelected { get; set; }
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
            var jsonstring = ReadAndWriteFile.GetJsonData("ListNewpaperData.json");
            var result = JsonConvert.DeserializeObject<List<NewsPaper>>(jsonstring);
            NewsPapers = new ObservableCollection<NewsPaper>(result);
        }
    }
}
