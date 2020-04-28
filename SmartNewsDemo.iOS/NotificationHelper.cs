using System;
using SmartNewsDemo.Common.Services.Interface;

namespace SmartNewsDemo.iOS
{
    public class NotificationHelper: ILocalNotificationService
    {
        public void Cancel(int id)
        {
            throw new NotImplementedException();
        }

        public void LocalNotification(string title, string body)
        {
            new NotificationDelegate().RegisterNotification(title, body);
        }
    }
}
