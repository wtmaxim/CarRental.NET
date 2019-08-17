using System;

namespace CarRental.Model
{
    public class EventDTO
    {
        public int Id { get; set; }
        public string Libelle { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }
        public string Licence_Plate { get; set; }
    }
}
