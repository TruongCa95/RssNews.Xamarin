using SmartNewsDemo.iOS;
using SmartNewsDemo.Utilitis;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(SleepMode))]
namespace SmartNewsDemo.iOS
{
    public class SleepMode : ISleepMode
    {
        public void ActivateAutoSleepMode(bool activateAutoSleepMode)
        {
            UIApplication.SharedApplication.InvokeOnMainThread(() =>
            {
                //force active/inactive, refer https://stackoverflow.com/questions/1679814/iphone-phone-goes-to-sleep-even-if-idletimerdisabled-is-yes
                UIApplication.SharedApplication.IdleTimerDisabled = activateAutoSleepMode; 
                UIApplication.SharedApplication.IdleTimerDisabled = !activateAutoSleepMode;
            });
        }
    }
}