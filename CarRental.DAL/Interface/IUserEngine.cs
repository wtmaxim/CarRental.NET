using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Model;

namespace CarRental.DAL.Interface
{
    interface IUserEngine
    {
        UserDTO Get(string email);
        List<UserDTO> List();
        void update(UserDTO user);
    }
}
