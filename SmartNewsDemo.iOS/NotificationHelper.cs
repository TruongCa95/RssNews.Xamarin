using System;
using SmartNewsDemo.Common.Services.Interface;

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
