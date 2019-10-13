using CarRental.BLL;
using CarRental.Model;
using CarRental.UI.ViewsModels.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarRental.UI.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleLogic roleLogic;
        private readonly ActionLogic actionLogic;
        public RoleController()
        {
            roleLogic = new RoleLogic();
            actionLogic = new ActionLogic();
        }
        /// <summary>
        /// Affiche la page d'édition d'un role
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            if (id != 0)
            {
                RoleDTO roleToEdit = roleLogic.Get_By_Id(id);
                List<ActionDTO> roleToEditActions = actionLogic.get_Role_Actions(roleToEdit);
                RoleEditViewModel REVM = new RoleEditViewModel()
                {
                    RoleWithActionTuple = new Tuple<RoleDTO, List<ActionDTO>>(roleToEdit, roleToEditActions),
                    allActions = actionLogic.List()
                };

                return View(REVM);
            }
            
            return View();
        }

        /// <summary>
        /// Supprime un role
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            roleLogic.DeleteRole(id);

            return RedirectToAction("Index","Configuration");
        }

        
    }
}