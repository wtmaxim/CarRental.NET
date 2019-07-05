using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Model;

namespace CarRental.DAL
{
    public class CarEngine : ICarEngine
    {
        private CarMapping carMapping;

        public CarEngine()
        {
            carMapping = new CarMapping();
        }

        public CarDTO Get(string licencePlate)
        {
            using (CarRentalEntities context = new CarRentalEntities())
            {
                Car car = context.usp_Car_Get(licencePlate).FirstOrDefault();
                return carMapping.MapToCarDTO(car);
            }
        }

        public void Insert(CarDTO car)
        {
            using (CarRentalEntities context = new CarRentalEntities())
            {
                context.usp_Car_Insert(car.is_Available, car.Mileage, car.Licence_Plate, car.Energy_Value, car.is_Active, car.Id_Company, car.Id_User, car.id_Car_Model);
            }
        }

        public List<CarDTO> List()
        {
            using (CarRentalEntities context = new CarRentalEntities())
            {
                var cars = context.usp_Car_List().ToList();
                return carMapping.MapToListCarDTO(cars);
            }
        }
    }
}
