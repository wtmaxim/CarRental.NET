using System.Collections.Generic;
using CarRental.Model;

namespace CarRental.DAL
{
    public interface IUtilisateurEngine
    {
        UserDTO GetByMail(string email);
        List<UserDTO> List();
        void UpdatePasswordByMail(string password, string mail);

        UserDTO GetByMailAndPassword(string email, string passowrd);
        UserDTO Get(int id);

    }
}
