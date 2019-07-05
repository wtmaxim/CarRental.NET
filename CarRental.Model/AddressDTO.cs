using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Model
{
    public class AddressDTO
    {
        public int Id { get; set; }
        public string Street_Number { get; set; }
        public string Locality { get; set; }
        public string Postal_Code { get; set; }
        public string Country { get; set; }
        public string Administrative_Area { get; set; }
        public string Route { get; set; }
        public string Name { get; set; }
    }
}
