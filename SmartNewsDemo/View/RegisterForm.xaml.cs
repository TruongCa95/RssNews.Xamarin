using System;
using System.Collections.Generic;
using SmartNewsDemo.ViewModel;
using Xamarin.Forms;

namespace SmartNewsDemo.View
{
    public partial class RegisterForm : ContentPage
    {
        public RegisterForm()
        {
            InitializeComponent();
            this.BindingContext = new RegisterFormViewModel();
        }
    }
}
