using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Model;

namespace CarRental.DAL.Interface
{
   public interface IUtilisateurEngine
    {
        UserDTO Get(string email);
        List<UserDTO> List();
        void Update(UserDTO user);

        UserDTO GetByMailAndPassword(string email, string passowrd);
    }
}
