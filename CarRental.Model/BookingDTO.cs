using System.Collections.Generic;

namespace CarRental.Model
{
    public class BookingDTO
    {
        public int Id { get; set; }
        public byte is_Personal_Car_Used { get; set; }
        public string Licence_Plate { get; set; }
        public int id_Request_Booking { get; set; }
        public virtual RequestBookingDTO RequestBooking { get; set; }
        public virtual CarDTO Car { get; set; }
        public virtual ICollection<CarReportDTO> CarReport { get; set; }
        public virtual ICollection<CostDTO> Cost { get; set; }
        public virtual ICollection<StopOverDTO> StopOver { get; set; }
        public virtual ICollection<UserBookingDTO> UserBooking { get; set; }
    }
}