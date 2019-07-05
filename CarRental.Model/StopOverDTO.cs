using System.Collections.Generic;

namespace CarRental.Model
{
    public class StopOverDTO
    {
        public int Id { get; set; }
        public System.DateTime Departure_Date { get; set; }
        public System.DateTime Arrival_Date { get; set; }
        public int Id_Booking { get; set; }
        public int Id_Stop_Over_Type { get; set; }
        public virtual BookingDTO Booking { get; set; }
        public virtual StopOverTypeDTO StopOverType { get; set; }
        public virtual ICollection<StopOverAddressDTO> StopOverAddress { get; set; }
    }
}