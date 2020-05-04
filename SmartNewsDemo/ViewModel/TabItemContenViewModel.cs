using SmartNewsDemo.Model;
using SmartNewsDemo.Utilitis;
using SmartNewsDemo.View;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SmartNewsDemo.ViewModel
{

    public class TabItemContenViewModel : BaseViewModel
    {
        #region Properties, Variable
        public ObservableCollection<NewsArticles> Arctiles { get; set; }
        public NewsArticles SelectedArctile { get; set; }
        public bool IsRefreshing { get; set; }
        public bool IsLoading { get; set; }
        public bool lstVisiable { get; set; }
        public string SearchText { get; set; }
        #endregion

        #region Command
        public ICommand RefreshCommand { get; private set; }
        public ICommand SelectedCommand { get; private set; }
        public ICommand FilterCommand { get; private set; }
        public ICommand ReloadCommand { get; private set; }
        #endregion
        public TabItemContenViewModel(string url)
        {
            GetDataAsync(url);
            RefreshCommand = new Command((async) =>
            {
                IsRefreshing = true;
                GetDataAsync(url);
                IsRefreshing = false;
            });
            ReloadCommand = new Command(() =>
            {
                if (SearchText == string.Empty)
                {
                    GetDataAsync(url);
                }
                else
                {
                    GetDataAsync(url);
                    HandleFilterItems();
                }
            });
            SelectedCommand = new Command(HandleSelectedItem);
            FilterCommand = new Command(() =>
            {
                HandleFilterItems();
            });
        }
        #region Event
        public async void HandleSelectedItem()
        {
            if (SelectedArctile != null)
            {
                var source = SelectedArctile.Link;
                await Application.Current.MainPage.Navigation.PushAsync(new ContentDetail(source));
            }
            SelectedArctile = null;
        }
        private void HandleFilterItems()
        {
            var Results = Arctiles.ToList();
            if (!string.IsNullOrWhiteSpace(SearchText))
            {
                var SearchResult = Results.Where(c => c.Title.ToLower().Contains(SearchText.ToLower()));
                Arctiles = new ObservableCollection<NewsArticles>(SearchResult);
            }

        }
        private async void GetDataAsync(string url)
        {
            IsLoading = true;
            var task = Task.Run(() =>
            {
                HttpResponse.ReponseServer(url);
                Arctiles = new ObservableCollection<NewsArticles>(HttpResponse.listresult);
            });
            await task;
            IsLoading = false;
        }
        #endregion
    }
}

