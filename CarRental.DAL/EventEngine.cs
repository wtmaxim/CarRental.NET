using CarRental.DAL.Interface;
using CarRental.DAL.Mapping;
using CarRental.Model;
using System.Collections.Generic;
using System.Linq;

namespace CarRental.DAL
{
    public class EventEngine : IEventEngine
    {
        private EventMapping eventMapping;

        public EventEngine()
        {
            eventMapping = new EventMapping();
        }

        public List<EventDTO> List(string licencePlate)
        {
            using (CarRentalEntities context= new CarRentalEntities())
            {
                List<Event> events = context.usp_Event_List(licencePlate).ToList();

                if (events.Count.Equals(0))
                    return null;
                else
                    return eventMapping.MapToListEventDTO(events);
            }
        }
    }
}
