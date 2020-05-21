using Foundation;
using ImageCircle.Forms.Plugin.iOS;
using Syncfusion.XForms.iOS.TabView;
using UIKit;
using UserNotifications;
using Xamarin.Forms;

namespace SmartNewsDemo.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            InitControl();
            //First, iOS 8 requires applications to ask for the user's permission to display notifications
            if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0))
            {
                var notificationSettings = UIUserNotificationSettings.GetSettingsForTypes(
                    UIUserNotificationType.Alert | UIUserNotificationType.Badge | UIUserNotificationType.Sound, null
                );

                app.RegisterUserNotificationSettings(notificationSettings);
            }
            //set the Delegate to handle
            UNUserNotificationCenter.Current.Delegate = new NotificationDelegate();
            Forms.SetFlags(new string[] { "CarouselView_Experimental", "RadioButton_Experimental", "IndicatorView_Experimental" });
            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App());
            return base.FinishedLaunching(app, options);

        }
        private void InitControl()
        {
            //render Sftabview
            SfTabViewRenderer.Init();
            //initilaze plugin popup
            Rg.Plugins.Popup.Popup.Init();
            ImageCircleRenderer.Init();
        }
        public override bool OpenUrl(UIApplication app, NSUrl url, NSDictionary options)
        {
            if (Xamarin.Essentials.Platform.OpenUrl(app, url, options))
                return true;

            return base.OpenUrl(app, url, options);
        }
        //public UIInterfaceOrientationMask CurrentOrientation = UIInterfaceOrientationMask.Portrait;

        //public override UIInterfaceOrientationMask GetSupportedInterfaceOrientations(UIApplication application, UIWindow forWindow)
        //{
        //    return CurrentOrientation;
        //}
    }
}
