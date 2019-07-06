using CarRental.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRental.UI.ViewsModels.Car
{
    public class CarIndexViewsModel
    {
        public List<CarDTO> cars { get; set; }
        public CarDTO car { get; set; }
    }
}