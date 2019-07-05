namespace CarRental.Model
{
    public class CarReportDTO
    {
        public int id { get; set; }
        public string Information { get; set; }
        public string Libelle { get; set; }
        public int Id_Booking { get; set; }
        public virtual BookingDTO Booking { get; set; }
    }
}