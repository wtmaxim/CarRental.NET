using System.Collections.Generic;


namespace CarRental.Model
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class UserDTO
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        [DisplayName("Email")]
        [Required(ErrorMessage ="Veuillez saisir votre Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DisplayName("Mot de passe")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage ="Veuillez saisir votre mot de passe")]
        public string Password { get; set; }
        public byte Is_Active { get; set; }
        public string Job { get; set; }
        public string Note { get; set; }
        public string Phone_Number { get; set; }
        public byte Is_Address_Private { get; set; }
        public int? Id_Company { get; set; }
        public string LoginErrorMessage { get; set; }
        
    }
}
