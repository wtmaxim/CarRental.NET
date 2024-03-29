﻿using CarRental.BLL;
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
        private readonly NotificationLogic notifLogic;

        public RoleController()
        {
            roleLogic = new RoleLogic();
            actionLogic = new ActionLogic();
            notifLogic = new NotificationLogic();
        }
        /// <summary>
        /// Affiche la page d'édition d'un role
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
           
            RoleDTO roleToEdit = roleLogic.Get_By_Id(id);
            List<ActionDTO> roleToEditActions = actionLogic.get_Role_Actions(roleToEdit);
            RoleEditViewModel REVM = new RoleEditViewModel()
            {
                RoleWithActionTuple = new Tuple<RoleDTO, List<ActionDTO>>(roleToEdit, roleToEditActions),
                allActions = actionLogic.List()
            };

            int idCurrentUser = (int)Session["userId"];
            Session["notifs"] = notifLogic.ListAllForUser(idCurrentUser).FindAll(n => n.IsRead == 0).Count;

            return View(REVM);
                       
        }
        /// <summary>
        /// Met a jour un rôle.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="roles"></param>
        /// <param name="roleName"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(int id, string[] actions,string roleName)
        {
            RoleDTO roleToEdit = roleLogic.Get_By_Id(id);
            

            if (roleName == null || roleName.Trim() == "")
            {
                ViewBag.Status = true;
                ViewBag.message = "Veuillez saisir un nom";
                List<ActionDTO> roleToEditActions = actionLogic.get_Role_Actions(roleToEdit);
                RoleEditViewModel REVM = new RoleEditViewModel()
                {
                    RoleWithActionTuple = new Tuple<RoleDTO, List<ActionDTO>>(roleToEdit, roleToEditActions),
                    allActions = actionLogic.List()
                };
                return View(REVM);
            }
            else
            {            
                // Si aucune role avec ce nom n'existe, je l'ajoute en base.
                if (roleLogic.List().Find(u => u.Libelle == roleName && u.Id!=id) == null)
                {
                    roleLogic.update(id, roleName);
                    roleLogic.Set_Role_Actions(roleLogic.Get_Role_And_Actions_By_Ids(id, actions));
                    return RedirectToAction("Index", "Configuration");
                }
                else
                {
                    roleLogic.Set_Role_Actions(roleLogic.Get_Role_And_Actions_By_Ids(id, actions));
                    ViewBag.Status = true;
                ViewBag.message = "Il existe déjà un role disposant de son libellé.";
                    List<ActionDTO> roleToEditActions = actionLogic.get_Role_Actions(roleToEdit);
                    RoleEditViewModel REVM = new RoleEditViewModel()
                    {
                        RoleWithActionTuple = new Tuple<RoleDTO, List<ActionDTO>>(roleToEdit, roleToEditActions),
                        allActions = actionLogic.List()
                    };
                    return View(REVM);
                }
            }

                
           
           
        }

        [HttpGet]
        public ActionResult Add()
        {
            RoleDTO role = new RoleDTO();
            List <ActionDTO> actions = new List<ActionDTO>();
            RoleEditViewModel REVM = new RoleEditViewModel()
            {
                RoleWithActionTuple = new Tuple<RoleDTO, List<ActionDTO>>(role, actions),
                allActions = actionLogic.List()
            };

            return View(REVM);
        }

        [HttpPost]
        public ActionResult Add (string[] actions, string roleName)
        {    
             // Si aucune role avec ce nom n'existe, je l'ajoute en base.
            if(roleLogic.List().Find(u => u.Libelle == roleName) == null)
            {
                roleLogic.AddRole(roleName);
                roleLogic.Set_Role_Actions(roleLogic.Get_Role_And_Actions_By_Ids(roleLogic.Get(roleName).Id, actions));
                return RedirectToAction("Index", "Configuration");
            }
            else
            {
                ViewBag.message = "Il existe déjà un role disposant de son libellé.";
                ViewBag.status = true;
                RoleDTO role = new RoleDTO();
                List<ActionDTO> listActions = new List<ActionDTO>();
                RoleEditViewModel REVM = new RoleEditViewModel()
                {
                    RoleWithActionTuple = new Tuple<RoleDTO, List<ActionDTO>>(role, listActions),
                    allActions = actionLogic.List()
                };
                return View(REVM);

            }
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