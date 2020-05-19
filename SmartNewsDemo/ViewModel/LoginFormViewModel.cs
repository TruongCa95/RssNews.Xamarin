using SmartNewsDemo.Common.Constants;
using SmartNewsDemo.View;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SmartNewsDemo.ViewModel
{
    public class LoginFormViewModel : BaseViewModel
    {
        #region properties, variable
        public bool frmIsVisiable { get; set; }
        public string AlertMessage { get; set; }
        public bool Busy { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<string> ListIconOauth2 { get; set; }

        #endregion
        #region command
        public Action DisplayInvalidLoginPrompt;
        public ICommand SubmitCommand { get; set; }
        #endregion
        public LoginFormViewModel()
        {
            SetIconLogin();
            SubmitCommand = new Command((async) =>
            {
                HandleSubmit();
            });

        }
        private void SetIconLogin()
        {
            string[] iconOauth2 =
            {
            "login_facebook.png",
            "login_gmail.png",
            "login_microsoft.png",
            "login_telegram.png",
            "login_twitter.png"
            };
            ListIconOauth2 = new List<string>();
            foreach (var item in iconOauth2)
            {
                ListIconOauth2.Add(item);
            }
        }
        private async void HandleSubmit()
        {
            var current = Connectivity.NetworkAccess;
            var emailPattern = @"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$";
            try
            {
                if (current != NetworkAccess.Internet)
                {
                    frmIsVisiable = true;
                    AlertMessage = AlertMessageConstants.ErrorNetwork;
                    await Task.Delay(3000);
                    frmIsVisiable = false;
                }
                else if (Email == null|| Password == null)
                {
                    frmIsVisiable = true;
                    AlertMessage = AlertMessageConstants.EmptyUserOrPass;
                    await Task.Delay(3000);
                    frmIsVisiable = false;
                }
                else if (!Regex.IsMatch(Email, emailPattern))
                {
                    frmIsVisiable = true;
                    AlertMessage = AlertMessageConstants.WrongEmailFormat;
                    await Task.Delay(3000);
                    frmIsVisiable = false;
                }
                else if (Email != "truong.lavan@vti.com" || Password != "723516")
                {
                    frmIsVisiable = true;
                    AlertMessage = AlertMessageConstants.WrongUserOrPass;
                    await Task.Delay(3000);
                    frmIsVisiable = false;
                }
                else
                {
                    Busy = true;
                    await Task.Delay(2000);
                    await Application.Current.MainPage.Navigation.PushAsync(new HomeMenu());
                    Password = string.Empty;
                    Busy = false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

