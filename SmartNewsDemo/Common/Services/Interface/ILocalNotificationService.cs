using System;
namespace SmartNewsDemo.Common.Services.Interface
{
    public interface ILocalNotificationService
    {
        void LocalNotification(string title, string body);
        //void Cancel(int id);
    }
}
