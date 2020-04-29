using System;
using System.Collections.Generic;
using System.Linq;
using Syncfusion.XForms.iOS.TabView;
using Foundation;
using UIKit;
using static System.Net.Mime.MediaTypeNames;

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
            global::Xamarin.Forms.Forms.Init();
            //render Sftabview
            SfTabViewRenderer.Init();

            //First, iOS 8 requires applications to ask for the user's permission to display notifications
            if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0))
            {
                UIUserNotificationType notificationTypes = UIUserNotificationType.Alert |
                            UIUserNotificationType.Badge |
                            UIUserNotificationType.Sound;

                var userNoticationSettings = UIUserNotificationSettings.GetSettingsForTypes(notificationTypes, new NSSet(new string[] { }));

                UIApplication.SharedApplication.RegisterUserNotificationSettings(userNoticationSettings);
            }
            LoadApplication(new App());
            return base.FinishedLaunching(app, options);

        }
    }
}
