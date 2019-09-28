using System.Collections.Generic;
using CarRental.Model;

namespace CarRental.DAL
{
    public interface INotificationEngine
    {
        List<NotificationDTO> ListAll();
        void Insert(NotificationDTO notification);
    }
}
