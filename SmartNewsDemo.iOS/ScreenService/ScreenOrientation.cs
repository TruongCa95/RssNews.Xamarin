using System;
using UIKit;
using Foundation;

using SmartNewsDemo.iOS;
using SmartNewsDemo.Utilitis;

[assembly: Xamarin.Forms.Dependency(typeof(ScreenOrientation))]
namespace SmartNewsDemo.iOS
{
    public class ScreenOrientation : IScreenOrientation
    {
        private static bool IsRotatable = false;

        public void SetLandscape()
        {
            Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
            {
                ((AppDelegate)UIApplication.SharedApplication.Delegate).CurrentOrientation = UIInterfaceOrientationMask.Landscape;
                if (!IsLandCape())
                {
                    UIApplication.SharedApplication.SetStatusBarOrientation(UIInterfaceOrientation.LandscapeRight, false);
                    UIDevice.CurrentDevice.SetValueForKey(new NSNumber((int)UIInterfaceOrientation.LandscapeRight), new NSString("orientation"));
                }
                IsRotatable = false;
            });

        }

        public void SetPortrait()
        {
            Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
            {
                ((AppDelegate)UIApplication.SharedApplication.Delegate).CurrentOrientation = UIInterfaceOrientationMask.Portrait;
                UIApplication.SharedApplication.SetStatusBarOrientation(UIInterfaceOrientation.Portrait, false);
                if (UIDevice.CurrentDevice.Orientation == UIDeviceOrientation.Portrait)
                {
                    UIDevice.CurrentDevice.SetValueForKey(new NSNumber((int)UIInterfaceOrientation.LandscapeRight), new NSString("orientation"));
                }
                UIDevice.CurrentDevice.SetValueForKey(new NSNumber((int)UIInterfaceOrientation.Portrait), new NSString("orientation"));
                IsRotatable = false;
            });
        }

        public void UnlockScreenOrientation()
        {
            Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
            {
                ((AppDelegate)UIApplication.SharedApplication.Delegate).CurrentOrientation = UIInterfaceOrientationMask.All;
                UIApplication.SharedApplication.SetStatusBarOrientation(UIInterfaceOrientation.Unknown, false);
                UIDevice.CurrentDevice.SetValueForKey(new NSNumber((int)UIInterfaceOrientation.Unknown), new NSString("orientation"));
                IsRotatable = true;
            });
        }

        public bool IsLandCape()
        {
            var orientation = UIApplication.SharedApplication.StatusBarOrientation;
            return orientation == UIInterfaceOrientation.LandscapeLeft || orientation == UIInterfaceOrientation.LandscapeRight;
        }

        public bool IsPortrait()
        {
            var orientation = UIApplication.SharedApplication.StatusBarOrientation;
            return orientation == UIInterfaceOrientation.Portrait;
        }

        public bool IsUnlocked()
        {
            return IsRotatable;
        }
    }
}