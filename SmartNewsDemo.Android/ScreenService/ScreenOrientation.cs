using SmartNewsDemo.Droid;
using SmartNewsDemo.Utilitis;

[assembly: Xamarin.Forms.Dependency(typeof(ScreenOrientation))]
namespace SmartNewsDemo.Droid
{
    public class ScreenOrientation : IScreenOrientation
    {
        public void SetLandscape()
        {
            Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
            {
                //(CrossCurrentActivity.Current.Activity).RequestedOrientation = Android.Content.PM.ScreenOrientation.SensorLandscape;
            });
        }

        public void SetPortrait()
        {
            Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
            {
                //(CrossCurrentActivity.Current.Activity).RequestedOrientation = Android.Content.PM.ScreenOrientation.Portrait;
            });
        }

        public void UnlockScreenOrientation()
        {
            Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
            {
                //(CrossCurrentActivity.Current.Activity).RequestedOrientation = Android.Content.PM.ScreenOrientation.Unspecified;
            });
        }

        public bool IsLandCape()
        {
            return true;
            //(CrossCurrentActivity.Current.Activity as MainActivity)?.AdjustDensity();
            //return (CrossCurrentActivity.Current.Activity).Resources.Configuration.Orientation == Android.Content.Res.Orientation.Landscape;
        }

        public bool IsPortrait()
        {
            return true;
            //(CrossCurrentActivity.Current.Activity as MainActivity)?.AdjustDensity();
            //return (CrossCurrentActivity.Current.Activity).Resources.Configuration.Orientation == Android.Content.Res.Orientation.Portrait;
        }

        public bool IsUnlocked()
        {
            return true;
            //(CrossCurrentActivity.Current.Activity as MainActivity)?.AdjustDensity();
            //return (CrossCurrentActivity.Current.Activity).RequestedOrientation == Android.Content.PM.ScreenOrientation.Unspecified;
        }
    }
}