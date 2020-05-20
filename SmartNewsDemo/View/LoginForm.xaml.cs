using System;
using System.Collections.Generic;
using SmartNewsDemo.ViewModel;
using Xamarin.Forms;

namespace SmartNewsDemo.View
{
    public partial class LoginForm : ContentPage
    {
        public LoginForm()
        {
            InitializeComponent();
            this.BindingContext = new LoginFormViewModel();
            //if (Device.RuntimePlatform=="Android")
            //{
            //    NavigationPage.SetHasNavigationBar(this, false);
            //}
            //else
            //{
            //    NavigationPage.SetHasNavigationBar(this, true);
            //}
        }
        //focus entry
        protected override void OnAppearing()
        {
            base.OnAppearing();
            Email.Focus();
        }
    }
}
