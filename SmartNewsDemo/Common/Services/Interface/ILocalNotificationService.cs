using System;
namespace SmartNewsDemo.Common.Services.Interface
{
    public interface ILocalNotificationService
    {
        void LocalNotification(string title, string body, DateTime time);
        //void Cancel(int id);
    }
}
