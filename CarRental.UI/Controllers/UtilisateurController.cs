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

        public UtilisateurController()
        {
            userLogic = new UtilisateurLogic();
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
                Companies = new List<CompanyDTO>(),
                Roles = new List<RoleDTO>()
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
                var usr = user;
                var company = new CompanyDTO();
                var role = new RoleDTO();
                var tupleData = new Tuple<UserDTO, CompanyDTO, RoleDTO>(usr, company, role);
                tupleList.Add(tupleData);
            }
            return tupleList;
        }
    }
}