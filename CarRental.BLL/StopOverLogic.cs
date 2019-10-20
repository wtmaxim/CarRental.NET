using CarRental.DAL;
using CarRental.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.BLL
{
    public class StopOverLogic
    {
        private readonly IStopOverEngine stopOverEngine;

        public StopOverLogic()
        {
            stopOverEngine = new StopOverEngine();
        }

        public StopOverDTO Insert(StopOverDTO stopOver)
        {
            return stopOverEngine.Add(stopOver);
        }

        public StopOverDTO GetByBooking(int idBooking)
        {
            return stopOverEngine.GetByBooking(idBooking);
        }
    }
}
