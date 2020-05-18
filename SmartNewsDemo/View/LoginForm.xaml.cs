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
        }
    }
}
