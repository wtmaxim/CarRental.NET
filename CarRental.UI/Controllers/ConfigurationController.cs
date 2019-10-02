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
        /// GET: Configuration
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            List <Tuple<RoleDTO, List<ActionDTO>>> RoleActionTupleList = new List<Tuple<RoleDTO, List<ActionDTO>>>();

            List<RoleDTO> roles = roleLogic.List();

            foreach(RoleDTO role in roles)
            {
                List<ActionDTO> actions = actionLogic.get_Role_Actions(role);

                RoleActionTupleList.Add(new Tuple<RoleDTO, List<ActionDTO>>(role, actions));
            }

            ConfigurationIndexViewModel Civm = new ConfigurationIndexViewModel()
            {
                RoleWithActionTuple = RoleActionTupleList
            };
            
            return View(Civm);
        }
    }
}