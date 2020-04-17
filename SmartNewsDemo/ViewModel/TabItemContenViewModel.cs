using SmartNewsDemo.Model;
using SmartNewsDemo.Utilitis;
using SmartNewsDemo.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;
using Xamarin.Forms;

namespace SmartNewsDemo.ViewModel
{

    public class TabItemContenViewModel : BaseViewModel
    {
        #region properties, variable
        public ObservableCollection<NewsArticles> Arctiles { get; set; }
        public NewsArticles SelectedArctile { get; set; }
        public bool IsRefreshing { get; set; }
        public bool IsLoading { get; set; }
        public string SearchText { get; set; }
        #endregion

        #region Command
        public ICommand RefreshCommand { get; private set; }
        public ICommand SelectedCommand { get; private set; }
        public ICommand FilterCommand { get; private set; }
        //public ICommand BackCommand { get; private set; }
        #endregion
        public TabItemContenViewModel(string url)
        {
            IsLoading = true;
            GetData(url);
            RefreshCommand = new Command(() =>
            {
                IsRefreshing = true;
                GetData(url);
                IsRefreshing = false;
            });
            SelectedCommand = new Command(HandleSelectedItem);
            FilterCommand = new Command(()=>
            {
               FilterItems();
            });
            IsLoading = false;
        }
        public async void HandleSelectedItem()
        {
            if (SelectedArctile != null)
            {
                var source = SelectedArctile.Link;
                await Application.Current.MainPage.Navigation.PushAsync(new ContentDetail(source));
            }
            SelectedArctile = null;
        }
        private void FilterItems()
        {
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                Arctiles= HttpResponse.listresult;
            }
            else
            {
                var SearchResults = HttpResponse.listresult.ToList();
                SearchResults.Where(x => x.Title.StartsWith(SearchText, StringComparison.InvariantCultureIgnoreCase))
                        .ToList();
                Arctiles = new ObservableCollection<NewsArticles>(SearchResults);
            }
        }

        private void GetData(string url)
        {
            var isConnected = HttpResponse.CheckNetwork();
            if (isConnected)
            {
                HttpResponse.ReponseServer(url);
                Arctiles = HttpResponse.listresult;
            }
                
        }
    }
}

