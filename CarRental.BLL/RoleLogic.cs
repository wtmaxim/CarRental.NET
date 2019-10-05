using CarRental.DAL;
using CarRental.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.BLL
{
    public class RoleLogic
    {
        private readonly IRoleEngine roleEngine;
        private readonly UtilisateurLogic utilisateurLogic;
        public RoleLogic()
        {
            roleEngine = new RoleEngine();
            utilisateurLogic = new UtilisateurLogic();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public List<RoleDTO> GetUserRoles(string email)
        {
            try
            {
                return roleEngine.Get_User_Roles(email);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleName"></param>
        public void AddRole(string roleName)
        {
            if (roleName != null && !roleName.Equals(""))
            {
                try
                {
                    roleEngine.Add(roleName);
                }
                catch (Exception)
                {
                    throw;
                }
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="roleName"></param>
        public void Add_User_Role(string email, string roleName)
        {
            try
            {
                RoleDTO role = Get(roleName);
                UserDTO user = utilisateurLogic.GetUserByMail(email);
               Add_User_Role(role.Id, user.Id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Add_User_Role(int userId, int roleId)
        {
            roleEngine.Add_User_Role(roleId, userId);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleName"></param>
        /// <returns></returns>
        public List<UserDTO> Get_Users_With_Role(string roleName)
        {
            try
            {
                return roleEngine.Ger_Users_With_Role(roleName);
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleName"></param>
        /// <returns></returns>
        public RoleDTO Get(string roleName)
        {
            try
            {
                return roleEngine.Get(roleName);
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Obtien un role selon son id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public RoleDTO Get_By_Id(int id)
        {
            try
            {
                return roleEngine.Get_By_ID(id);
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mail"></param>
        /// <param name="roleName"></param>
        /// <returns></returns>
        public bool Is_User_In_Role(string mail, string roleName)
        {
            try
            {
                return roleEngine.Is_User_In_Role(mail, roleName);
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<RoleDTO> List()
        {
            try
            {
                return roleEngine.List();
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleDTOs"></param>
        /// <returns></returns>
        public string[] Convert_List_Roles_To_String_Array(List<RoleDTO> roleDTOs)
        {
            List<string> array = new List<string>();
            foreach (RoleDTO role in roleDTOs)
            {
                array.Add(role.Libelle);
            }
            return array.ToArray();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userDTOs"></param>
        /// <returns></returns>
        public string[] Convert_List_Users_To_String_Array(List<UserDTO> userDTOs)
        {
            List<string> array = new List<string>();
            foreach (UserDTO user in userDTOs)
            {
                array.Add(user.Email);
            }
            return array.ToArray();
        }
                
    }
}
