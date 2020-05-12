using Android.Content;
using SmartNewsDemo.Droid;
using SmartNewsDemo.Utilitis;

[assembly: Xamarin.Forms.Dependency(typeof(SleepMode))]
namespace SmartNewsDemo.Droid
{
    public class SleepMode : ISleepMode
    {
        private Android.OS.PowerManager.WakeLock _wakeLock;
        public void ActivateAutoSleepMode(bool activateAutoSleepMode)
        {
            var powerMgr = (Android.OS.PowerManager)Android.App.Application.Context.GetSystemService(Context.PowerService);

            if (_wakeLock == null)
            {
                _wakeLock = powerMgr.NewWakeLock(Android.OS.WakeLockFlags.AcquireCausesWakeup | Android.OS.WakeLockFlags.OnAfterRelease | Android.OS.WakeLockFlags.Full, typeof(SleepMode).FullName);
            }
            if (activateAutoSleepMode)
            {
                while(_wakeLock.IsHeld)
                    _wakeLock.Release();
            }
            else
            {
                _wakeLock.Acquire();
            }
        }
    }
}