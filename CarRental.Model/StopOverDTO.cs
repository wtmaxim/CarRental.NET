using System;

namespace CarRental.Model
{
    public class StopOverDTO
    {
        public int Id { get; set; }
        public DateTime Departure_Date { get; set; }
        public DateTime Arrival_Date { get; set; }
        public int Id_Booking { get; set; }
        public int Id_Stop_Over_Type { get; set; }
    }
}