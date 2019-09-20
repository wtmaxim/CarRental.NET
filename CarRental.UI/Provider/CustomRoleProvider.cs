using CarRental.BLL;
using CarRental.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace CarRental.UI.Provider
{
    public class CustomRoleProvider : RoleProvider
    {
        private readonly RoleLogic roleLogic;
        private readonly ActionLogic actionLogic;
        public CustomRoleProvider()
        {
            roleLogic = new RoleLogic();
            actionLogic = new ActionLogic();
        }
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            foreach (string username in usernames)
            {
                foreach (string role in roleNames)
                {
                    roleLogic.Add_User_Role(username, role);
                }
            }
        }

        public override void CreateRole(string roleName)
        {
            roleLogic.AddRole(roleName);
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            return roleLogic.Convert_List_Roles_To_String_Array(roleLogic.List());
        }

        public override string[] GetRolesForUser(string email)
        {
            return actionLogic.Convert_List_Action_To_String_Array(actionLogic.Get_User_Actions(email));
        }

        public override string[] GetUsersInRole(string roleName)
        {
            return roleLogic.Convert_List_Users_To_String_Array(roleLogic.Get_Users_With_Role(roleName));
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            return roleLogic.Is_User_In_Role(username, roleName);
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            try
            {
                if (roleLogic.Get(roleName) == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}