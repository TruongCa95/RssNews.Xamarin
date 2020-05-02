using System;
using Android.App;
using Firebase.Messaging;

namespace SmartNewsDemo.Droid
{
    [Service]
    [IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]
    public class MyFirebaseMessagingService : FirebaseMessagingService
    {
        public MyFirebaseMessagingService()
        {

        }
        public override void OnMessageReceived(RemoteMessage message)
        {
            base.OnMessageReceived(message);
            new LocalNotificationService().LocalNotification(message.GetNotification().Title, message.GetNotification().Body, DateTime.Now);
        }
    }
}
