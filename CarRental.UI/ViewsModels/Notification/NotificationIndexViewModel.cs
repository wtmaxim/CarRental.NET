using CarRental.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRental.UI.ViewsModels.Notification
{
    public class NotificationIndexViewModel
    {
        public List<(
            NotificationDTO notification, 
            RequestBookingDTO requestBooking, 
            UserDTO user, 
            string departureCity)> 
            Notifications { get; set; }
    }
}