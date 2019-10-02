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
                ListRoleWithActionTuple = actionLogic.GetListTupleRoleAction(roleLogic.List())
            };
            
            return View(Civm);
        }
        
    }
}