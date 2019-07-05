using System.Collections.Generic;

namespace CarRental.Model
{
    public class UserBookingDTO
    {
        public byte is_Driver { get; set; }
        public byte is_Going { get; set; }
        public int Id_Booking { get; set; }
        public int Id_User { get; set; }
        public virtual BookingDTO Booking { get; set; }
        public virtual UserDTO User { get; set; }
    }
}