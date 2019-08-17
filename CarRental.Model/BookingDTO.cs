using System.Collections.Generic;

namespace CarRental.Model
{
    public class BookingDTO
    {
        public int Id { get; set; }
        public byte is_Personal_Car_Used { get; set; }
        public string Licence_Plate { get; set; }
        public int id_Request_Booking { get; set; }
    }
}