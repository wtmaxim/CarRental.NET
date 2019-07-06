using CarRental.DAL;
using CarRental.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.BLL
{
    public class CarMakeLogic
    {
        private readonly CarMakeEngine carMake;

        public CarMakeLogic()
        {
            carMake = new CarMakeEngine();
        }

        public CarMakeDTO Get(int id)
        {
            return carMake.Get(id);
        }
    }
}
