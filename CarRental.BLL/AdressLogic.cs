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
        private readonly AdressEngine adressEngine;
        public AdressLogic()
        {
            adressEngine = new AdressEngine();
        }

        public List<AddressDTO> List()
        {
            return adressEngine.List();
        }
    }
}
