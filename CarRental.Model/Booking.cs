﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Model
{
    public class Booking
    {
        public BookingDTO booking { get; set; }
        public RequestBookingDTO requestBooking { get; set; }
        public StopOverDTO stopOver { get; set; }
        public List<UserDTO> passagersAller { get; set; }
        public List<UserDTO> passagerRetour { get; set; }
        public StatusDTO status { get; set; }
        public StopOverAddressDTO stopOverAddress { get; set; }
        public UserDTO driverAller { get; set; }
        public UserDTO driverRetour { get; set; }
        public AddressDTO addressAller { get; set; }
        public AddressDTO addressRetour { get; set; }
        public UserDTO createdBy { get; set; }
    }
}
