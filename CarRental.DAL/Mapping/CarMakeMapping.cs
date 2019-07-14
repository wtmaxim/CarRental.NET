using System;
using System.Linq;
using CarRental.Model;

namespace CarRental.DAL
{
    public class CarMakeMapping
    {
        //private CarModelMapping carModelMapping;

        public CarMakeMapping()
        {
            //carModelMapping = new CarModelMapping();
        }

        public CarMakeDTO MapToCarMakeDTO(CarMake carMake)
        {
            return new CarMakeDTO
            {
                //CarModel = carModelMapping.MapToListCarModelDTO(carMake.CarModel.ToList()),
                id = carMake.id,
                Make = carMake.Make
            };
        }
    }
}