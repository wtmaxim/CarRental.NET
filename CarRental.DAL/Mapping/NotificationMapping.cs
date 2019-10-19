using CarRental.Model;
using System.Collections.Generic;

namespace CarRental.DAL.Mapping
{
    public class NotificationMapping
    {
        public List<NotificationDTO> MapToListNotificationDTO(List<Notification> notifs)
        {
            List<NotificationDTO> retour = new List<NotificationDTO>();
            foreach (Notification n in notifs)
            {
                NotificationDTO notif = new NotificationDTO
                {
                    Id = n.Id,
                    IdUser = n.IdUser,
                    IsRead = n.IsRead,
                    IsForAdmin = n.IsForAdmin,
                    IsForNewRequest = n.IsForNewRequest,
                    IdBooking = n.IdBooking,
                    CreationDateTimestamp = n.CreationDateTimestamp
                };

                retour.Add(notif);
            }

            return retour;
        }
    }
}
