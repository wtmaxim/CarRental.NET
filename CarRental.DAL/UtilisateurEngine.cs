using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.DAL.Interface;
using CarRental.Model;

namespace CarRental.DAL
{
    public class UtilisateurEngine : IUserEngine
    {
        UserDTO IUserEngine.Get(string email)
        {
            throw new NotImplementedException();
        }

        List<UserDTO> IUserEngine.List()
        {
            throw new NotImplementedException();
        }

        void IUserEngine.update(UserDTO user)
        {
            throw new NotImplementedException();
        }
    }
}
