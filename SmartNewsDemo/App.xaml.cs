using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartNewsDemo
{
    public partial class App : Application
    {
        public App()
        {
            //Register Syncfusion license
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjQyNDcwQDMxMzgyZTMxMmUzMG5xNjQ4YVhXdEdPaG00U1NsdXZBcFlGZmlvUm1qeThQYVFoclhTV2FaN3c9");
            InitializeComponent();
            Xamarin.Essentials.VersionTracking.Track();
            MainPage = new NavigationPage(new SmartNewsDemo.View.HomeSetting());
            //MainPage = new NavigationPage(new MasterPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
