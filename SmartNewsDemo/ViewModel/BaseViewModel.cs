using System;
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
        public virtual void OnAppearing()
        {

        }
        public virtual void OnDisappearing()
        {

        }
        internal event Func<string, Task> DoDisplayAlert;
        public Task DisplayAlertAsync(string message)
        {
            return DoDisplayAlert?.Invoke(message) ?? Task.CompletedTask;
        }
    }
}
