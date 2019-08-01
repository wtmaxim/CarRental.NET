using CarRental.DAL;
using CarRental.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.BLL
{
    public class CarModelLogic
    {
        private readonly CarModelEngine carModelEngine;

        public CarModelLogic()
        {
            carModelEngine = new CarModelEngine();
        }

        public CarModelDTO Get(int id)
        {
            return carModelEngine.Get(id);
        }

        public List<CarModelDTO> List(int idMake)
        {
            return carModelEngine.List(idMake);
        }
    }
}
