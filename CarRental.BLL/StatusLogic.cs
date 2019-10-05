using CarRental.DAL;
using CarRental.Model;

namespace CarRental.BLL
{
    public class StatusLogic
    {
        private readonly StatusEngine statusEngine;

        public StatusLogic()
        {
            statusEngine = new StatusEngine();
        }

        public StatusDTO GetStatus(int id)
        {
            return statusEngine.Get(id);
        }
    }
}
