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
        public DateTime DateValue { get; set; }
        public string AlertMessage { get; set; }
        public string Email { get; set; }
        public string RetypePassword { get; set; }
        public string BtnName { get; set; }
        public string Password { get; set; }
        #endregion
        #region command
        public ICommand SubmitCommand { get; set; }
        public ICommand CheckedCommand { get; set; }
        public ICommand SelectedDateCommand { get; set; }
        #endregion
        public RegisterFormViewModel()
        {
            DateValue = DateTime.UtcNow;
            BtnName = "Sign In";
            SubmitCommand = new Command((async) =>
            {
                HandleSubmit();
            });
            SelectedDateCommand = new Command(HandeleSelectedDate);
            CheckedCommand = new Command(HandleCheckedGender);
        }

        private void HandeleSelectedDate(object obj)
        {
            var date = DateValue;
        }

        private void HandleCheckedGender(object obj)
        {
            var rdb = (RadioButton)obj;
            var val = rdb.Text;
            Console.WriteLine(val);
            val = null;
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
                else if(Password!= RetypePassword)
                {
                    FrmIsVisiable = true;
                    AlertMessage = AlertMessageConstants.PasswordIncorrect;
                    await Task.Delay(3000);
                    FrmIsVisiable = false;
                }
                else
                {
                    Busy = true;
                    BtnName = "";
                    await Task.Delay(2000);
                    await Application.Current.MainPage.Navigation.PushAsync(new LoginForm());
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
