﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.BLL
{
    public class UserLogic
    {
        private readonly IUserEngine userEngine;

        public UserLogic()
        {
            userEngine = new UserEngine();
        }


    }
}
