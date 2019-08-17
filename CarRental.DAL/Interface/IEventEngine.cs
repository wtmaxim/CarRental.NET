using CarRental.Model;
using System.Collections.Generic;

namespace CarRental.DAL.Interface
{
    public interface IEventEngine
    {
        List<EventDTO> List(string licencePlate);
    }
}
