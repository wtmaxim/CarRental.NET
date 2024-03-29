﻿using CarRental.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.DAL
{
    public interface IStopOverAddressEngine
    {
        StopOverAddressDTO Get(int idStopOver);
        void Insert(StopOverAddressDTO stopOverAddress);
    }
}
