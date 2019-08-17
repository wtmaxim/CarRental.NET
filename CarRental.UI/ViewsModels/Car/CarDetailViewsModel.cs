using CarRental.Model;
using System.Collections.Generic;

namespace CarRental.UI.ViewsModels.Car
{
    public class CarDetailViewsModel
    {
        public CarDTO car { get; set; }
        public CarModelDTO carModel { get; set; }
        public CarMakeDTO carMake { get; set; }
        public List<EventDTO> events { get; set; }
    }
}