using CarRental.DAL;
using CarRental.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.BLL
{
    public class ActionLogic
    {
        private readonly ActionEngine actionEngine;
        public ActionLogic()
        {
            actionEngine = new ActionEngine();
        }
        /// <summary>
        /// Permet d'obtenir toutes les actions d'un utilisateur.
        /// </summary>
        /// <param name="email"></param>
        /// <returns>liste d'action</returns>
        public List<ActionDTO> Get_User_Actions(string email)
        {
            try
            {
                return actionEngine.Get_User_Actions(email);
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Retourne la liste de toute les actions
        /// </summary>
        /// <returns></returns>
        public List<ActionDTO> List()
        {
            try
            {
                return actionEngine.List();

            }
            catch (Exception)
            {

                throw;
            }

        }
        /// <summary>
        /// Convertit une liste d'action en tableau de chaine de caractères contenant les libellé de chaque action.
        /// </summary>
        /// <param name="actions"></param>
        /// <returns>tableau de libelle d'action.</returns>
        public string[] Convert_List_Action_To_String_Array(List<ActionDTO> actions)
        {
            List<string> array = new List<string>();
            foreach (ActionDTO action in actions)
            {
                array.Add(action.Libelle);
            }
            return array.ToArray();
        }
        /// <summary>
        /// Retourne la liste des action d'un role.
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public List<ActionDTO> get_Role_Actions(RoleDTO role)
        {
            try
            {
                return actionEngine.Get_Role_Actions(role.Id);
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Obtien une action selon son id.
        /// </summary>
        /// <returns></returns>
        internal ActionDTO Get_By_Id(int id)
        {
            try
            {
                return actionEngine.Get_By_iD(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Crée un Tuple contenant le role et sa liste d'action.
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>        
        public Tuple<RoleDTO, List<ActionDTO>> GetTupleRoleAction(RoleDTO role)
        {
            List<ActionDTO> actions = get_Role_Actions(role);
            return new Tuple<RoleDTO, List<ActionDTO>>(role, actions);
        }
        /// <summary>
        /// Crée une liste de tuple contenant les roles et leurs actions.
        /// </summary>
        /// <param name="roles"></param>
        /// <returns></returns>        
        public List<Tuple<RoleDTO, List<ActionDTO>>> GetListTupleRoleAction(List<RoleDTO> roles)
        {
            List<Tuple<RoleDTO, List<ActionDTO>>> RoleActionTupleList = new List<Tuple<RoleDTO, List<ActionDTO>>>();
            foreach (RoleDTO role in roles)
            {
                RoleActionTupleList.Add(GetTupleRoleAction(role));
            }

            return RoleActionTupleList;
        }
    }
}
