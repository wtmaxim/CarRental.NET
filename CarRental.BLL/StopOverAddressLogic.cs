using CarRental.DAL;
using CarRental.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.BLL
{
    public class StopOverAddressLogic
    {
        private readonly IStopOverAddressEngine stopOverAddressEngine;

        public StopOverAddressLogic()
        {
            stopOverAddressEngine = new StopOverAddressEngine();
        }

        public void AddStopOverAddress(StopOverAddressDTO stopOverAddress)
        {
            stopOverAddressEngine.Insert(stopOverAddress);
        }

        public void Insert(int address, int idStopOver, byte isDeparture)
        {
            StopOverAddressDTO stopOverAddress = new StopOverAddressDTO
            {
                id_Address = address,
                Id_Stop_Over = idStopOver,
                is_Departure = isDeparture
            };

            stopOverAddressEngine.Insert(stopOverAddress);
        }

        public StopOverAddressDTO GetStopOverAddress(int idStopOver)
        {
            return stopOverAddressEngine.Get(idStopOver);
        }
    }
}
