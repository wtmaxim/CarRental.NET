using System.Collections.Generic;
using CarRental.Model;

namespace CarRental.DAL
{
    public interface INotificationEngine
    {
        List<NotificationDTO> ListAllForUser(int IdUser);
        void Insert(NotificationDTO notification);
        void MarkAsRead(int IdNotification);
    }
}
