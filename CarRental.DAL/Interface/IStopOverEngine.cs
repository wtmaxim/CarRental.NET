using CarRental.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.DAL
{
    public interface IStopOverEngine
    {
        List<StopOverDTO> List(int idBooking);
        StopOverDTO Add(StopOverDTO stopOver);
        StopOverDTO GetByBooking(int idBooking);
    }
}
