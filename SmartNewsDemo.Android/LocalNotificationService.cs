using System;
using Android.App;
using Android.Content;
using Android.Media;
using Android.Support.V4.App;
using Java.Lang;
using SmartNewsDemo.Common.Services.Interface;
using SmartNewsDemo.Droid;
using SmartNewsDemo.Model;

[assembly: Xamarin.Forms.Dependency(typeof(LocalNotificationService))]
namespace SmartNewsDemo.Droid
{
    public class LocalNotificationService: ILocalNotificationService
    {
        private Context _context;
        private NotificationManager _notificationManager;
        private NotificationCompat.Builder _builder;
        public static string NOTIFICATION_CHANNEL_ID = "10023";
        readonly DateTime _jan1st1970 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public LocalNotificationService()
        {
            _context = global::Android.App.Application.Context;
        }
        //public void Cancel(int id)
        //{
        //    var notificationManager = NotificationManagerCompat.From(_context);
        //    notificationManager.CancelAll();
        //    notificationManager.Cancel(id);
        //}
        public void LocalNotification(string title, string body, DateTime time)
        {
            try
            {
                //long repeateDay = 1000 * 60 * 60 * 24;      
                long repeateForMinute = 60000; // In milliseconds     
                long totalMilliSeconds = (long)(time.ToUniversalTime() - _jan1st1970).TotalMilliseconds;
                if (totalMilliSeconds < JavaSystem.CurrentTimeMillis())
                {
                    totalMilliSeconds = totalMilliSeconds + repeateForMinute;
                }
                var intent = new Intent(_context, typeof(MainActivity));
                intent.AddFlags(ActivityFlags.ClearTop);
                intent.PutExtra(title, body);
                var pendingIntent = PendingIntent.GetActivity(_context, 0, intent, PendingIntentFlags.OneShot);

                // Creating an Audio Attribute
                var alarmAttributes = new AudioAttributes.Builder()
                    .SetContentType(AudioContentType.Sonification)
                    .SetUsage(AudioUsageKind.Notification).Build();

                _builder = new NotificationCompat.Builder(_context);
                _builder.SetSmallIcon(Resource.Drawable.app_logo);
                _builder.SetContentTitle(title)
                        .SetAutoCancel(true)
                        .SetContentTitle(title)
                        .SetContentText(body)
                        .SetChannelId(NOTIFICATION_CHANNEL_ID)
                        .SetPriority((int)NotificationPriority.High)
                        .SetVibrate(new long[0])
                        .SetDefaults((int)NotificationDefaults.Sound | (int)NotificationDefaults.Vibrate)
                        .SetVisibility((int)NotificationVisibility.Public)
                        .SetSmallIcon(Resource.Drawable.theWitcher);

                NotificationManager notificationManager = _context.GetSystemService(Context.NotificationService) as NotificationManager;

                if (global::Android.OS.Build.VERSION.SdkInt >= global::Android.OS.BuildVersionCodes.O)
                {
                    NotificationImportance importance = global::Android.App.NotificationImportance.High;

                    NotificationChannel notificationChannel = new NotificationChannel(NOTIFICATION_CHANNEL_ID, title, importance);
                    notificationChannel.EnableLights(true);
                    notificationChannel.EnableVibration(true);
                    notificationChannel.SetShowBadge(true);
                    notificationChannel.Importance = NotificationImportance.High;
                    notificationChannel.SetVibrationPattern(new long[] { 100, 200, 300, 400, 500, 400, 300, 200, 400 });

                    if (notificationManager != null)
                    {
                        _builder.SetChannelId(NOTIFICATION_CHANNEL_ID);
                        notificationManager.CreateNotificationChannel(notificationChannel);
                    }
                }

                notificationManager.Notify(0, _builder.Build());

            }
            catch (Java.Lang.Exception ex)
            {

            }
        }
    }
}
