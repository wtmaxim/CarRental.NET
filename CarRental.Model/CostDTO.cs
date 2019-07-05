namespace CarRental.Model
{
    public class CostDTO
    {
        public string Libelle { get; set; }
        public int Price { get; set; }
        public int Id { get; set; }
        public int Id_Booking { get; set; }
        public int Id_Category_Cost { get; set; }
        public virtual BookingDTO Booking { get; set; }
        public virtual CategoryCostDTO CategoryCost { get; set; }
    }
}