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
            //MainPage = new NavigationPage(new SmartNewsDemo.View.TabView());
            MainPage = new MasterPage();
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
