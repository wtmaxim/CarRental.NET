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

        /// <summary>
        /// Constructeur
        /// </summary>
        public RoleEngine()
        {
            roleMapping = new RoleMapping();
            userMapping = new UserMapping();
        }

        public void Add_Role_Action(int roleId, int actionId)
        {
            try
            {
                using (CarRentalEntities context = new CarRentalEntities())
                {
                    context.usp_Role_Action_Insert(roleId, actionId);

                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Supprime un role.
        /// </summary>
        /// <param name="roleId"></param>
        public void Delete(int roleId)
        {
            try
            {
                using (CarRentalEntities context = new CarRentalEntities())
                {
                    context.usp_Role_Delete(roleId);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Obtiens un role selon son id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public RoleDTO Get_By_ID(int id)
        {
            try
            {
                using (CarRentalEntities context = new CarRentalEntities())
                {
                   return roleMapping.MapToRoleDTO(context.usp_Role_Get_By_ID(id).FirstOrDefault());
                }                
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Supprime toute les actions d'un role.
        /// </summary>
        /// <param name="roleId"></param>
        public void Remove_All_Actions(int roleId)
        {
            try
            {
                using (CarRentalEntities context = new CarRentalEntities())
                {
                    context.usp_Role_Action_Delete_By_Role(roleId);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Met a jour le libelle d'un role selon son id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="libelle"></param>
        public void update(int id, string libelle)
        {
            try
            {
                using (CarRentalEntities context = new CarRentalEntities())
                {
                    context.usp_Role_Update(id, libelle);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Ajoute un role.
        /// </summary>
        /// <param name="roleName"></param>
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

        /// <summary>
        /// Affecte un role a un utilisateur.
        /// </summary>
        /// <param name="roleID"></param>
        /// <param name="userId"></param>
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

        /// <summary>
        /// Récupère une liste d'utilisateur selon un role.
        /// </summary>
        /// <param name="roleName"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Récupère un role selon son nom.
        /// </summary>
        /// <param name="roleName"></param>
        /// <returns></returns>
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
 
        /// <summary>
        /// Récupère la liste des roles d'un utilisateur.
        /// </summary>
        /// <param name="mail"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Vérifie qu'un utilisateur possède bien un role selon le nom du rôle.
        /// </summary>
        /// <param name="mail"></param>
        /// <param name="roleName"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Liste de tout les roles.
        /// </summary>
        /// <returns></returns>
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

    }
}
