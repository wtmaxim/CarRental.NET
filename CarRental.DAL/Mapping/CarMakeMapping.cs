using System;
using System.Collections.Generic;
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
                id = carMake.id,
                Make = carMake.Make
            };
        }

        public List<CarMakeDTO> MapToListCarMakeDTO(List<CarMake> carsMake)
        {
            List<CarMakeDTO> retour = new List<CarMakeDTO>();

            foreach (CarMake carMake in carsMake)
            {
                CarMakeDTO newCarMake = new CarMakeDTO
                {
                    id = carMake.id,
                    Make = carMake.Make
                };

                retour.Add(newCarMake);
            }

            return retour;
        }
    }
}