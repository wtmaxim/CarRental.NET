using CarRental.DAL;
using CarRental.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.BLL
{
    public class AdressLogic
    {
        private readonly IAdressEngine adressEngine;
        public AdressLogic()
        {
            adressEngine = new AdressEngine();
        }

        public List<AddressDTO> List()
        {
            return adressEngine.List();
        }

        public AddressDTO GetAddress(int idBooking)
        {
            return adressEngine.GetAddress(idBooking);
        }

        public AddressDTO GetAddress(int idBooking, byte isDeparture)
        {
            return adressEngine.GetAddress(idBooking, isDeparture);
        }
    }
}
