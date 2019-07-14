
using CarRental.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.DAL
{
    public class CarModelMapping
    {
        //private CarMapping carMapping;
        //private CarMakeMapping carMakeMapping;

        public CarModelMapping()
        {
            //carMapping = new CarMapping();
            //carMakeMapping = new CarMakeMapping();
        }

        public List<CarModelDTO> MapToListCarModelDTO(List<CarModel> carModels)
        {
            List<CarModelDTO> retour = new List<CarModelDTO>();

            foreach (CarModel carModel in carModels)
            {
                CarModelDTO newCar = new CarModelDTO
                {
                    //Car = carMapping.MapToListCarDTO(carModel.Car.ToList()),
                    //CarMake = carMakeMapping.MapToCarMakeDTO(carModel.CarMake),
                    Energy = carModel.Energy,
                    id = carModel.id,
                    id_Car_Make = carModel.id_Car_Make,
                    Model = carModel.Model,
                    Places = carModel.Places
                };

                retour.Add(newCar);
            }

            return retour;
        }

        public CarModelDTO MapToCarModelDTO(CarModel carModel)
        {
            return new CarModelDTO
            {
                //Car = carMapping.MapToListCarDTO(carModel.Car.ToList()),
                //CarMake = carMakeMapping.MapToCarMakeDTO(carModel.CarMake),
                Energy = carModel.Energy,
                id = carModel.id,
                id_Car_Make = carModel.id_Car_Make,
                Model = carModel.Model,
                Places = carModel.Places
            };
        }
    }
}
