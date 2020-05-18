using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace SmartNewsDemo.ViewModel
{
    public class LoginFormViewModel : BaseViewModel
    {
        #region properties, variable
        #endregion
        #region command
        public ICommand SubmitCommand { get; set; }
        #endregion
        public LoginFormViewModel()
        {
            
        }
    }
}

