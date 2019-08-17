using System.Collections.Generic;

namespace CarRental.Model
{
    public class RequestBookingDTO
    {
        public int id { get; set; }
        public byte is_Personal_Car_Available { get; set; }
        public System.DateTime Date { get; set; }
        public string Reason { get; set; }
        public int Id_Status { get; set; }
    }
}