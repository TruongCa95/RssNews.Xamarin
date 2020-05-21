using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using SmartNewsDemo.Common.Constants;
using SmartNewsDemo.View;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SmartNewsDemo.ViewModel
{
    public class RegisterFormViewModel: BaseViewModel
    {
        #region properties, variable
        public bool FrmIsVisiable { get; set; }
        public bool Busy { get; set; }
        public string AlertMessage { get; set; }
        public string Email { get; set; }
        public string RetypePassword { get; set; }
        public string BtnName { get; set; }
        public string Password { get; set; }
        #endregion
        #region command
        public ICommand SubmitCommand { get; set; }
        #endregion
        public RegisterFormViewModel()
        {
            BtnName = "Sign In";
            SubmitCommand = new Command((async) =>
            {
                HandleSubmit();
            });
        }

        private async void HandleSubmit()
        {
            var current = Connectivity.NetworkAccess;
            var emailPattern = @"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$";
            try
            {
                if (current != NetworkAccess.Internet)
                {
                    FrmIsVisiable = true;
                    AlertMessage = AlertMessageConstants.ErrorNetwork;
                    await Task.Delay(3000);
                    FrmIsVisiable = false;
                }
                else if (Email == null || Password == null)
                {
                    FrmIsVisiable = true;
                    AlertMessage = AlertMessageConstants.EmptyUserOrPass;
                    await Task.Delay(3000);
                    FrmIsVisiable = false;
                }
                else if (!Regex.IsMatch(Email, emailPattern))
                {
                    FrmIsVisiable = true;
                    AlertMessage = AlertMessageConstants.WrongEmailFormat;
                    await Task.Delay(3000);
                    FrmIsVisiable = false;
                }
                else
                {
                    Busy = true;
                    BtnName = "";
                    await Task.Delay(2000);
                    await Application.Current.MainPage.Navigation.PushAsync(new LoginForm());
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
