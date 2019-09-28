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

        public List<NotificationDTO> ListAll()
        {
            return notificationEngine.ListAll();
        }

        public void Insert(NotificationDTO notification)
        {
            notificationEngine.Insert(notification);
        }
    }
}
