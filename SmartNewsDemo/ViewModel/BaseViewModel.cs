using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace SmartNewsDemo.ViewModel
{
    /// <summary>
    /// Base of other view model.
    /// Provides a heper to trigger property changed events.
    ///
    /// This class is inspired by others.
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        //Overide Lifecycle using MVVM
        public virtual Task OnAppearing()
        {
            return Task.FromResult<object>(null);
        }

        public virtual Task OnDisappearing()
        {
            return Task.FromResult<object>(null);
        }

        public virtual Task OnResume()
        {
            return Task.FromResult<object>(null);
        }
    }
}
