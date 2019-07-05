﻿using CarRental.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.DAL
{
    interface IVoitureEngine
    {
        void Insert(CarDTO voiture);
        List<CarDTO> List();

        CarDTO Get(string licencePlate);
    }
}
