using CarRental.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.DAL
{
    public interface IRoleEngine
    {
        List<RoleDTO> List();
        RoleDTO Get(string roleName);
        List<RoleDTO> Get_User_Roles(string mail);
        void Update(RoleDTO role);
        List<UserDTO> Ger_Users_With_Role(string roleName);
        bool Is_User_In_Role(string mail, string roleName);
        void Add_User_Role(int roleID, int userId);
        void Add(string roleName);

    }
}
