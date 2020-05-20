using System;
using System.Collections.Generic;
using System.Linq;
using Syncfusion.XForms.iOS.TabView;
using Foundation;
using UIKit;
using UserNotifications;
using ImageCircle.Forms.Plugin.iOS;

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

            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App());
            return base.FinishedLaunching(app, options);

        }
        private void InitControl()
        {
            global::Xamarin.Forms.Forms.SetFlags("IndicatorView_Experimental");
            global::Xamarin.Forms.Forms.SetFlags("RadioButton_Experimental");
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
