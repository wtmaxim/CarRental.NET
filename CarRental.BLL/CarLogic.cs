﻿using CarRental.DAL;
using CarRental.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.BLL
{
    public class CarLogic
    {
        private readonly ICarEngine carEngine;

        public CarLogic()
        {
            carEngine = new CarEngine();
        }
    
        public void AddCar(CarDTO car)
        {
            carEngine.Insert(car);
        }

        public List<CarDTO> List(string searchWord)
        {
            return carEngine.List(searchWord);
        }

        public CarDTO Get(string licencePlate)
        {
            return carEngine.Get(licencePlate);
        }

        public List<CarDTO> List()
        {
            return carEngine.List();
        }

        public void Update(string licencePlate, int kilometrage)
        {
            carEngine.Update(licencePlate, kilometrage);
        }
    }
}
