using System.Collections.Generic;

namespace CarRental.Model
{
    public class CompanyDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int id_Address { get; set; }
        public virtual AddressDTO Address { get; set; }
        public virtual ICollection<CarDTO> Car { get; set; }
        public virtual ICollection<UserDTO> User { get; set; }
    }
}