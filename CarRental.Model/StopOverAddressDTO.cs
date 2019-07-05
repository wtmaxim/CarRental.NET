﻿namespace CarRental.Model
{
    public class StopOverAddressDTO
    {
        public byte is_Departure { get; set; }
        public int Id_Stop_Over { get; set; }
        public int id_Address { get; set; }
        public virtual AddressDTO Address { get; set; }
        public virtual StopOverDTO StopOver { get; set; }
    }
}