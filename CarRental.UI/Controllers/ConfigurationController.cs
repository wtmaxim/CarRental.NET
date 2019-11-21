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
        private readonly NotificationLogic notificationLogic;

        public ConfigurationController()
        {
            roleLogic = new RoleLogic();
            actionLogic = new ActionLogic();
            notificationLogic = new NotificationLogic();
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

            int idCurrentUser = (int)Session["userId"];
            Session["notifs"] = notificationLogic.ListAllForUser(idCurrentUser).FindAll(n => n.IsRead == 0).Count;

            return View(Civm);
        }
        
    }
}