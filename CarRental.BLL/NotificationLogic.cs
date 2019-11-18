using CarRental.DAL;
using CarRental.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.BLL
{
    public class NotificationLogic
    {
        private readonly INotificationEngine notificationEngine;

        public NotificationLogic()
        {
            notificationEngine = new NotificationEngine();
        }

        public List<NotificationDTO> ListAllForUser(int IdUser)
        {
            return notificationEngine.ListAllForUser(IdUser);
        }

        public void Insert(NotificationDTO notification)
        {
            notificationEngine.Insert(notification);
        }

        public void MarkAsRead(int IdNotification)
        {
            notificationEngine.MarkAsRead(IdNotification);
        }
    }
}
