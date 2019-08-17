using CarRental.DAL;
using CarRental.DAL.Interface;
using CarRental.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.BLL
{
    public class EventLogic
    {
        private readonly IEventEngine eventEngine;

        public EventLogic()
        {
            eventEngine = new EventEngine();
        }

        public List<EventDTO> List(string licencePlate)
        {
            return eventEngine.List(licencePlate);
        }
    }
}
