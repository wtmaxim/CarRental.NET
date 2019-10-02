using CarRental.BLL;
using CarRental.Model;
using CarRental.UI.ViewsModels.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarRental.UI.Controllers
{
    public class ConfigurationController : Controller
    {
        private readonly RoleLogic roleLogic;
        private readonly ActionLogic actionLogic;

        public ConfigurationController()
        {
            roleLogic = new RoleLogic();
            actionLogic = new ActionLogic();
        }

        /// <summary>
        /// Affiche la page de configuration
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            
            ConfigurationIndexViewModel Civm = new ConfigurationIndexViewModel()
            {
                RoleWithActionTuple = GetListTupleRoleAction(roleLogic.List())
            };
            
            return View(Civm);
        }
        /// <summary>
        /// Crée un Tuple contenant le role et sa liste d'action.
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        [NonAction]        
        public Tuple <RoleDTO, List<ActionDTO>> GetTupleRoleAction(RoleDTO role)
        {
            List<ActionDTO> actions = actionLogic.get_Role_Actions(role);
            return new Tuple<RoleDTO, List<ActionDTO>>(role, actions);
        }
        /// <summary>
        /// Crée une liste de tuple contenant les roles et leurs actions.
        /// </summary>
        /// <param name="roles"></param>
        /// <returns></returns>
        [NonAction]
        public List<Tuple<RoleDTO, List<ActionDTO>>> GetListTupleRoleAction(List<RoleDTO> roles)
        {
            List<Tuple<RoleDTO, List<ActionDTO>>> RoleActionTupleList = new List<Tuple<RoleDTO, List<ActionDTO>>>();
            foreach(RoleDTO role in roles)
            {
              RoleActionTupleList.Add(  GetTupleRoleAction(role));
            }

            return RoleActionTupleList;
        }
    }
}