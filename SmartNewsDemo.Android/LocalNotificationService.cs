using System;
using Android.App;
using Android.Content;
using Android.Support.V4.App;
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

        public LocalNotificationService()
        {
            _context = global::Android.App.Application.Context;
        }
        public void Cancel(int id)
        {
            throw new NotImplementedException();
        }

        public void LocalNotification(string title, string body)
        {
            try
            {
                _builder = new NotificationCompat.Builder(_context);
                _builder.SetSmallIcon(Resource.Drawable.theWitcher);
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
            catch (Exception ex)
            {

            }
            //var intent = CreateIntent(id);
            //var localNotification = new LocalNotification();
            //localNotification.Title = title;
            //localNotification.Body = body;
            //localNotification.Id = id;
        }

        //private Intent CreateIntent(int id)
        //{
        //    return new Intent(Application.Context, typeof(ScheduledAlarmHandler))
        //        .SetAction("LocalNotifierIntent" + id);
        //}
    }
}
