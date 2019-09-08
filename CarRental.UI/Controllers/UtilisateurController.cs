using CarRental.BLL;
using CarRental.Model;
using CarRental.UI.ViewsModels.Utilisateur;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarRental.UI.Controllers
{
    public class UtilisateurController : Controller
    {
        private readonly UtilisateurLogic userLogic;
        private readonly CompanyLogic companyLogic;
        private readonly RoleLogic roleLogic;

        public UtilisateurController()
        {
            userLogic = new UtilisateurLogic();
            companyLogic = new CompanyLogic();
            roleLogic = new RoleLogic();
        }

        /**
         * GET: Utilisateurs
         * Récupère la liste des utilisateurs et affiche la page d'index
         */
        public ActionResult Index()
        {
            List<UserDTO> users = userLogic.List();

            UtilisateurIndexViewModel vm = new UtilisateurIndexViewModel
            {
                Users = UserDTOToTuple(userLogic.List()),
                Companies = companyLogic.List(),
                Roles = roleLogic.List()
            };
            
            return View("Index", vm);
        }

        /**
         * UserDTOToTuple
         * Transforme une liste de UserDTO en liste de Tuple pour l'affichage
         */
        private List<Tuple<UserDTO, CompanyDTO, RoleDTO>> UserDTOToTuple(List<UserDTO> users)
        {
            var tupleList = new List<Tuple<UserDTO, CompanyDTO, RoleDTO>>();
            foreach (UserDTO user in users)
            {
                var company = companyLogic.List().Find(c => c.Id == user.Id_Company);
                var role = roleLogic.List().Find(r => r.Id == user.Id_Role);
                var tupleData = new Tuple<UserDTO, CompanyDTO, RoleDTO>(user, company, role);
                tupleList.Add(tupleData);
            }
            return tupleList;
        }

        /**
         * POST : SearchUser
         * Recherche des utilisateurs (par nom et prénom) en fonction de la valeur fournie
         */
        [HttpPost]
        public ActionResult SearchUser(string searchVal)
        {
            if (searchVal != null)
            {
                List<UserDTO> users = userLogic.Search(searchVal);
                UtilisateurIndexViewModel vm = new UtilisateurIndexViewModel
                {
                    Users = UserDTOToTuple(users),
                    Companies = companyLogic.List(),
                    Roles = roleLogic.List()
                };
                return View("Index", vm);
            }
            else
            {
                return RedirectToAction("Index");
            }

        }

        /**
         * GEt : FilterUserByCompany
         * Recherche des utilisateurs (par nom et prénom) en fonction de la valeur fournie
         */
        [HttpPost]
        public ActionResult FilterUserByCompany(int idCompany)
        {
            List<UserDTO> users;
            if (idCompany != -1)
            {
                users = userLogic.List().FindAll(u => u.Id_Company == idCompany);
            }
            else
            {
                users = userLogic.List();
            }
            UtilisateurIndexViewModel vm = new UtilisateurIndexViewModel
            {
                Users = UserDTOToTuple(users),
                Companies = companyLogic.List(),
                Roles = roleLogic.List()
            };
            return View("Index", vm);
        }
    }
}