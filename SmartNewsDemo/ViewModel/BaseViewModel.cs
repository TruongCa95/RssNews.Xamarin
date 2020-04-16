using System.ComponentModel;
using System.Runtime.CompilerServices;

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
        #region INotifyPropertyChanged

        /// <summary>
        /// Occurs when property changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
       
        #endregion
    }
}
