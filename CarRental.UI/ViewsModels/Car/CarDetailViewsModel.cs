using CarRental.Model;

namespace CarRental.UI.ViewsModels.Car
{
    public class CarDetailViewsModel
    {
        public CarDTO car { get; set; }
        public CarModelDTO carModel { get; set; }
        public CarMakeDTO carMake { get; set; }
    }
}