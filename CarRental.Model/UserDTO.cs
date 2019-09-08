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
        [Required(AllowEmptyStrings = false, ErrorMessage = "Veuillez saisir votre Email.")]
        [EmailAddress(ErrorMessage = "Veuillez saisir une addresse email valide.")]
        public string Email { get; set; }
        [DisplayName("Mot de passe")]
        [DataType(DataType.Password)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Veuillez saisir votre mot de passe")]
        public string Password { get; set; }
        [DisplayName("Confirmez votre mot de passe")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Les mots de passe ne correspondent pas")]
        public string confirmPassword { get; set; }
        public byte Is_Active { get; set; }
        public string Job { get; set; }
        public string Note { get; set; }
        public string Phone_Number { get; set; }
        public byte Is_Address_Private { get; set; }
        public int? Id_Company { get; set; }
        public int Id_Role { get; set; }
        public string LoginErrorMessage { get; set; }

    }
}
