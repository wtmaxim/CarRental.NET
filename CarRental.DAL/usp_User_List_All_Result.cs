//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CarRental.DAL
{
    using System;
    
    public partial class usp_User_List_All_Result
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public byte is_Active { get; set; }
        public string Job { get; set; }
        public string Note { get; set; }
        public string Phone_Number { get; set; }
        public byte is_Address_Private { get; set; }
        public Nullable<int> Id_Company { get; set; }
        public int Id_Role { get; set; }
    }
}