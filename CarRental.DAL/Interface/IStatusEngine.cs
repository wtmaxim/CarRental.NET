﻿using CarRental.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.DAL.Interface
{
    public interface IStatusEngine
    {
        StatusDTO Get(int id);
    }
}
