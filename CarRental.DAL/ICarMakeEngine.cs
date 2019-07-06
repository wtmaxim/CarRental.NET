using CarRental.Model;

namespace CarRental.DAL
{
    public interface ICarMakeEngine
    {
        CarMakeDTO Get(int id);
    }
}