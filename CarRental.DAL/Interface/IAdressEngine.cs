﻿using CarRental.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.DAL
{
    public interface IAdressEngine
    {
        List<AddressDTO> List();
        AddressDTO GetAddress(int idBooking);
        AddressDTO GetAddress(int idBooking, byte isDeparture);
    }
}
