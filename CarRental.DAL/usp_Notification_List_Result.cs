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
    
    public partial class usp_Notification_List_Result
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public byte IsRead { get; set; }
        public System.DateTime CreationDate { get; set; }
        public byte IsForAdmin { get; set; }
        public byte IsForNewRequest { get; set; }
        public int IdBooking { get; set; }
    }
}
