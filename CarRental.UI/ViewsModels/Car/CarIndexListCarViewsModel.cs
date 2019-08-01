using CarRental.Model;
using System;
using System.Collections.Generic;

namespace CarRental.UI.ViewsModels.Car
{
    public class CarIndexListCarViewsModel
    {
        public List<Tuple<CarDTO, CarModelDTO, CarMakeDTO>> Cars { get; set; }
    }
}