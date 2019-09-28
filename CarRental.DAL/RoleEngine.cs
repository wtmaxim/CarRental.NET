using CarRental.DAL.Mapping;
using CarRental.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarRental.DAL
{
    public class RoleEngine : IRoleEngine
    {
        private readonly RoleMapping roleMapping;
        private readonly UserMapping userMapping;

        public RoleEngine()
        {
            roleMapping = new RoleMapping();
            userMapping = new UserMapping();
        }


        void IRoleEngine.Add(string roleName)
        {
            using (CarRentalEntities context = new CarRentalEntities())
            {
                try
                {
                    context.usp_Role_Insert(roleName);
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        void IRoleEngine.Add_User_Role(int roleID, int userId)
        {
            using (CarRentalEntities context = new CarRentalEntities())
            {
                try
                {
                    context.usp_UserRole_INSERT(userId, roleID);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        List<UserDTO> IRoleEngine.Ger_Users_With_Role(string roleName)
        {
            using (CarRentalEntities context = new CarRentalEntities())
            {
                try
                {
                    return userMapping.MapToListUserDTO(context.usp_Role_GET_List_Users_BY_Libelle(roleName).ToList());
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        RoleDTO IRoleEngine.Get(string roleName)
        {
            using (CarRentalEntities context = new CarRentalEntities())
            {
                try
                {
                    return roleMapping.MapToRoleDTO(context.usp_Role_GET(roleName).FirstOrDefault());
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        List<RoleDTO> IRoleEngine.Get_User_Roles(string mail)
        {
            using (CarRentalEntities context = new CarRentalEntities())
            {
                try
                {
                    return roleMapping.MapToListRoleDTO(context.usp_User_GET_List_Roles(mail));
                }
                catch (Exception)
                {
                    throw;
                }
            }

            throw new NotImplementedException();
        }

        bool IRoleEngine.Is_User_In_Role(string mail, string roleName)
        {
            using (CarRentalEntities context = new CarRentalEntities())
            {
                try
                {
                    User user = context.usp_UserRole_GET_USER_IN_ROLE(mail, roleName).FirstOrDefault();
                    if (user != null)
                    {
                        return true;
                    }
                    else
                    { return false; }
                }
                catch (Exception)
                {

                    throw;
                }

            }
        }

        List<RoleDTO> IRoleEngine.List()
        {
            using (CarRentalEntities context = new CarRentalEntities())
            {
                try
                {
                    return roleMapping.MapToListRoleDTO(context.usp_Role_List().ToList());

                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        void IRoleEngine.Update(RoleDTO role)
        {
            throw new NotImplementedException();
        }
    }
}
