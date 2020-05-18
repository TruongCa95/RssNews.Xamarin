using System;
using System.Collections.Generic;
using SmartNewsDemo.ViewModel;
using Xamarin.Forms;

namespace SmartNewsDemo.View
{
    public partial class HomeMenu : ContentPage
    {
        public HomeMenuViewModel viewmodel = new HomeMenuViewModel();
        public HomeMenu()
        {
            InitializeComponent();
            this.BindingContext = viewmodel;
            SetTimeImageSlider();
        }

        //Automatic Image Slider
        private void SetTimeImageSlider()
        {
            Device.StartTimer(TimeSpan.FromSeconds(2), (Func<bool>)(() =>
            {
                MainCarouselView.Position = (MainCarouselView.Position + 1) % viewmodel.Banner.Count;
                return true;
            }));
        }
    }
}
