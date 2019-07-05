using CarRental.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.DAL
{
    public class CarMapping
    {
        public CarMapping()
        {

        }

        public CarDTO MapToCarDTO(Car car)
        {
            return new CarDTO
            {
                Energy_Value = car.Energy_Value,
                Mileage = car.Mileage,
                Licence_Plate = car.Licence_Plate,
                is_Available = car.is_Available,
                is_Active = car.is_Active,
                id_Car_Model = car.id_Car_Model,
                Id_Company = car.Id_Company,
                Id_User = car.Id_User
            };
        }

        public List<CarDTO> MapToListCarDTO(List<Car> cars)
        {
            List<CarDTO> retour = new List<CarDTO>();

            foreach (Car car in cars)
            {
                CarDTO newCar = new CarDTO
                {
                    Energy_Value = car.Energy_Value,
                    Mileage = car.Mileage,
                    Licence_Plate = car.Licence_Plate,
                    is_Available = car.is_Available,
                    is_Active = car.is_Active,
                    id_Car_Model = car.id_Car_Model,
                    Id_Company = car.Id_Company,
                    Id_User = car.Id_User
                };

                retour.Add(newCar);
            }

            return retour;
        }
    }
}
