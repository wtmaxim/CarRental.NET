using System.Collections.Generic;


namespace CarRental.Model
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public byte Is_Active { get; set; }
        public string Job { get; set; }
        public string Note { get; set; }
        public string Phone_Number { get; set; }
        public byte Is_Address_Private { get; set; }
        public int? Id_Company { get; set; }
        public int Id_Role { get; set; }
        public ICollection<CarDTO> Car { get; set; }
        // public CompanyDTO Company { get; set; }
        public ICollection<user_addressDTO> user_address { get; set; }
        public ICollection<UserBookingDTO> UserBooking { get; set; }
        // public ICollection<RoleDTO> Role { get; set; }
    }
}
