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
    using System.Collections.Generic;
    
    public partial class UserBooking
    {
        public byte is_Driver { get; set; }
        public byte is_Going { get; set; }
        public int Id_Booking { get; set; }
        public int Id_User { get; set; }
    
        public virtual Booking Booking { get; set; }
        public virtual User User { get; set; }
    }
}
