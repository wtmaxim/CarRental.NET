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
        /// <summary>
        /// Permet d'obtenir la liste de tout les rôles en base de données.
        /// </summary>
        /// <returns>Retourne la liste de tout les rôles</returns>
        List<RoleDTO> List();
        /// <summary>
        /// Permet d'obtenir un role selon son nom.
        /// </summary>
        /// <param name="roleName"></param>
        /// <returns></returns>
        RoleDTO Get(string roleName);
        /// <summary>
        /// Permet d'obtenir tout les rôles d'un utilisateur.
        /// </summary>
        /// <param name="mail"></param>
        /// <returns></returns>
        List<RoleDTO> Get_User_Roles(string mail);
        /// <summary>
        /// Permet de mettre à jour un role.
        /// </summary>
        /// <param name="role"></param>
        void Update(RoleDTO role);
        /// <summary>
        /// Permet d'obtenir tout les utilisateurs pour disposant du role selon son nom.
        /// </summary>
        /// <param name="roleName"></param>
        /// <returns></returns>
        List<UserDTO> Ger_Users_With_Role(string roleName);
        /// <summary>
        /// Permet de vérifier si un utilisateur dispose d'un rôle.
        /// </summary>
        /// <param name="mail"></param>
        /// <param name="roleName"></param>
        /// <returns></returns>
        bool Is_User_In_Role(string mail, string roleName);
        /// <summary>
        /// Permet d'ajouter un role à un utilsateur.
        /// </summary>
        /// <param name="roleID"></param>
        /// <param name="userId"></param>
        void Add_User_Role(int roleID, int userId);
        /// <summary>
        /// Permet d'ajouter un role.
        /// </summary>
        /// <param name="roleName"></param>
        void Add(string roleName);

    }
}
