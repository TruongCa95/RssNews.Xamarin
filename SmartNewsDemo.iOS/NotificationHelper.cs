using System;
using SmartNewsDemo.Common.Services.Interface;
using SmartNewsDemo.iOS;
using Xamarin.Forms;

[assembly: Dependency(typeof(NotificationHelper))]
namespace SmartNewsDemo.iOS
{
    public class NotificationHelper: ILocalNotificationService
    {
        public void LocalNotification(string title, string body)
        {
            new NotificationDelegate().RegisterNotification(title, body);
        }
    }
}
