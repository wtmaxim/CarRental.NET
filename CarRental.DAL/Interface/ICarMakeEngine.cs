using CarRental.Model;
using System.Collections.Generic;

namespace CarRental.DAL
{
    public interface ICarMakeEngine
    {
        CarMakeDTO Get(int id);
        List<CarMakeDTO> List();
    }
}