using CarRental.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.DAL.Interface
{
    public interface IActionEngine
    {
        List<ActionDTO> Get_User_Actions(string email);
    }
}
