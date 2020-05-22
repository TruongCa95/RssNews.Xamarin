using System;
using System.Threading.Tasks;
using SmartNewsDemo.ViewModel;
using Xamarin.Forms;

namespace SmartNewsDemo.View
{
    public class BasePage:ContentPage
    {
        public BasePage()
        {
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            SetBinding(BindingContext);
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            TearDownBinding(BindingContext);
        }

        private void TearDownBinding(object bindingContext)
        {
            if (bindingContext is BaseViewModel viewModel)
            {
                viewModel.DoDisplayAlert += OnDisplayAlert;
                viewModel.OnDisappearing();
            }
        }

        private void SetBinding(object bindingContext)
        {
            if(bindingContext is BaseViewModel viewModel)
            {
                viewModel.OnDisappearing();
                viewModel.DoDisplayAlert -= OnDisplayAlert;
            }
        }
        Task OnDisplayAlert(string message)
        {
            return DisplayAlert(Title, message, "OK");
        }
    }
}
