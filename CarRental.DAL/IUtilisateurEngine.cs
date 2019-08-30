using CarRental.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.DAL
{
    public interface IUtilisateurEngine
    {
        void Insert(UserDTO user);
        List<UserDTO> List();
        UserDTO Get(int id);
        List<UserDTO> Search(string value);
        void Archive(int IdUser);
    }
}