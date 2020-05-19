using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace SmartNewsDemo.ViewModel
{
    public class LoginFormViewModel : BaseViewModel
    {
        #region properties, variable
        public List<string> ListIconOauth2 { get; set; }
        string[] iconOauth2 =
            {
            "login_facebook.png",
            "login_gmail.png",
            "login_microsoft.png",
            "login_telegram.png",
            "login_twitter.png"
            };
        #endregion
        #region command
        public ICommand SubmitCommand { get; set; }
        #endregion
        public LoginFormViewModel()
        {
            ListIconOauth2 = new List<string>();
            foreach(var item in iconOauth2)
            {
                ListIconOauth2.Add(item);
            }
        }
    }
}

