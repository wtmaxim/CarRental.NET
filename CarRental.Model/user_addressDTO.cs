namespace CarRental.Model
{
    public class user_addressDTO
    {
        public int id_user { get; set; }
        public int id_address { get; set; }
        public string address_Name { get; set; }
        public virtual AddressDTO Address { get; set; }
        public virtual UserDTO User { get; set; }
    }
}