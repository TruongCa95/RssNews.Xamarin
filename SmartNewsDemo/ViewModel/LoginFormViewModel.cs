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
        public string BtnName { get; set; }
        public bool FrmIsVisiable { get; set; }
        public string AlertMessage { get; set; }
        public bool Busy { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsVisiableShowPass { get; set; }
        public bool IsPassword { get; set; }
        public bool IsChecked { get; set; }
        public bool IsVisiableHiddenPass { get; set; }
        public List<string> ListIconOauth2 { get; set; }

        #endregion
        #region command
        public ICommand FacebookCommand { get; set; }
        public ICommand GoogleCommand { get; set; }
        public ICommand MicrosoftCommand { get; set; }
        public ICommand TelegramCommand { get; set; }
        public ICommand TwitterCommand { get; set; }
        public ICommand CheckedCommand { get; set; }
        public ICommand TextChangedCommand { get; set; }
        public ICommand ShowPasswordCommand { get; set; }
        public ICommand HiddenPasswordCommand { get; set; }
        public ICommand SubmitCommand { get; set; }
        public ICommand NavigationRegisterCommand { get; set; }
        #endregion
        public LoginFormViewModel()
        {
            LoginStorage();
            FacebookCommand = new Command(async () => await HandleAuthenticate("Facebook"));
            GoogleCommand = new Command(async () => await HandleAuthenticate("Google"));
            MicrosoftCommand = new Command(async () => await HandleAuthenticate("Microsoft"));
            TelegramCommand = new Command(async () => await HandleAuthenticate("Telegram"));
            TwitterCommand = new Command(async () => await HandleAuthenticate("Twitter"));
            NavigationRegisterCommand = new Command((async) =>
             {
                 HandleNavigationRegister();
             });
            SubmitCommand = new Command((async) =>
            {
                HandleSubmit();
            });
            TextChangedCommand = new Command(HandleTextChanged);
            ShowPasswordCommand = new Command(HandleShowPassword);
            HiddenPasswordCommand = new Command(HandleHiddenPassword);
            CheckedCommand = new Command((async) =>
            {
                HandleChecked();
            });
        }

        async Task HandleAuthenticate(string schema)
        {
            try
            {
               
            }
            catch (Exception ex)
            {

            }
        }
        #region event
        public async void LoginStorage()
        {
            var email = await SecureStorage.GetAsync("email");
            var pass= await SecureStorage.GetAsync("password");
            Password = pass;
            Email = email;
        }
        private async void HandleChecked()
        {
            if(IsChecked)
            {
                try
                {
                    await SecureStorage.SetAsync("email", Email);
                    await SecureStorage.SetAsync("password", Password);
                }
                catch (Exception ex)
                {
                    // Possible that device doesn't support secure storage on device.
                }
            }
        }
        private void HandleHiddenPassword()
        {
            IsPassword = true;
            IsVisiableShowPass = true;
            IsVisiableHiddenPass = false;
        }

        private void HandleShowPassword()
        {
            IsPassword = false;
            IsVisiableHiddenPass = true;
            IsVisiableShowPass = false;
        }

        private void HandleTextChanged()
        {
            if(Password!=string.Empty)
            {
                IsPassword = true;
                IsVisiableShowPass = true;
                IsVisiableHiddenPass = false;
            }
            else
            {
                IsPassword = true;
                IsVisiableShowPass = false;
                IsVisiableHiddenPass = false;
            }
        }

        private async void HandleNavigationRegister()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new RegisterForm());
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
                else if (Email == null|| Password == null)
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
                else if (Email != "truong.lavan@vti.com" || Password != "723516")
                {
                    FrmIsVisiable = true;
                    AlertMessage = AlertMessageConstants.WrongUserOrPass;
                    await Task.Delay(3000);
                    FrmIsVisiable = false;
                }
                else
                {
                    Busy = true;
                    BtnName = "";
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
        #endregion
    }
}

