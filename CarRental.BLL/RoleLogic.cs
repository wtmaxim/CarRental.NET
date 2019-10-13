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
        private readonly ActionLogic actionLogic;
        public RoleLogic()
        {
            roleEngine = new RoleEngine();
            utilisateurLogic = new UtilisateurLogic();
            actionLogic = new ActionLogic();
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

        public void update(int id, string roleName)
        {
            RoleDTO role = Get_By_Id(id);            
            roleEngine.update(role.Id,roleName);
        }

        /// <summary>
        /// Récupère un role et une liste d'action selon leurs id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="roles"></param>
        public Tuple<RoleDTO,List<ActionDTO>> Get_Role_And_Actions_By_Ids(int id, string[] actions)
        {
            RoleDTO role = roleEngine.Get_By_ID(id);
            if (actions!= null)
            {           
                try
                {
                   
                    List<ActionDTO> roleActions = new List<ActionDTO>();
                
                        foreach (string stringIdAction in actions)
                        {
                            int idAction;
                            if (int.TryParse(stringIdAction, out idAction))
                            {
                                ActionDTO action = actionLogic.Get_By_Id(idAction);
                                roleActions.Add(action);
                            }
                        }
                        return new Tuple<RoleDTO, List<ActionDTO>>(role, roleActions);
                                
                }
                catch (Exception)
                {

                    throw;
                }
            }else
            {
                return new Tuple<RoleDTO, List<ActionDTO>>(role, null);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tuple"></param>
        public void Set_Role_Actions(Tuple<RoleDTO, List<ActionDTO>> tuple)
        {
            roleEngine.Remove_All_Actions(tuple.Item1.Id);
            if (tuple.Item2 != null)
            {  
                foreach(ActionDTO action in tuple.Item2)
                {
                    roleEngine.Add_Role_Action(tuple.Item1.Id, action.Id);
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
        /// Récupère un role selon son nom.
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
        /// <summary>
        /// Vérifie l'existence d'un role en base de donnés puis le supprime.
        /// </summary>
        /// <param name="roleId"></param>
        public void DeleteRole(int roleId)
        {
            try
            {
                RoleDTO roleToDelete = Get_By_Id(roleId);
                if (roleToDelete != null)
                {
                    roleEngine.Delete(roleToDelete.Id);
                }

            }
            catch (Exception)
            {

                throw;
            }
            
            

        }
                
    }
}
