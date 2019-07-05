using System.Collections.Generic;

namespace CarRental.Model
{
    public class StatusDTO
    {
        public int Id { get; set; }
        public string Libelle { get; set; }
        public virtual ICollection<RequestBookingDTO> RequestBooking { get; set; }
    }
}