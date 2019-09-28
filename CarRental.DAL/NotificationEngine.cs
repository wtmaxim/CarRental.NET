using System.Collections.Generic;
using System.Linq;
using CarRental.DAL.Mapping;
using CarRental.Model;

namespace CarRental.DAL
{
    public class NotificationEngine : INotificationEngine
    {
        private NotificationMapping notificationMapping;

        public NotificationEngine()
        {
            notificationMapping = new NotificationMapping();
        }

        public List<NotificationDTO> ListAll()
        {
            using (CarRentalEntities context = new CarRentalEntities())
            {
                List<Notification> notifications = context.usp_Notification_List().ToList();
                return notificationMapping.MapToListNotificationDTO(notifications);
            }
        }

        public void Insert(NotificationDTO notif)
        {
            using (CarRentalEntities context = new CarRentalEntities())
            {
                context.usp_Notification_Insert(notif.IdUser, notif.IsRead,
                    notif.IsForAdmin, notif.IsForNewRequest, notif.IdBooking);
            }
        }
    }
}
