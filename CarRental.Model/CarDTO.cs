using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Model
{
    public class CarDTO
    {
        public byte is_Available { get; set; }
        public int Mileage { get; set; }
        public string Licence_Plate { get; set; }
        public int Energy_Value { get; set; }
        public byte is_Active { get; set; }
        public int Id_Company { get; set; }
        public int Id_User { get; set; }
        public int id_Car_Model { get; set; }
    }
}
