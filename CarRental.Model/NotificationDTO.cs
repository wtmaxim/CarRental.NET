using System;

namespace CarRental.Model
{
    public class NotificationDTO
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public byte IsRead { get; set; }
        public DateTime CreationDateTimestamp { get; set; }
        public byte IsForAdmin { get; set; }
        public byte IsForNewRequest { get; set; }
        public int IdRequestBooking { get; set; }
    }
}
