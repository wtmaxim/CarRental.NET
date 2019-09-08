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

            if (TempData["FormError"] != null)
            {
                ViewBag.FormError = TempData["FormError"].ToString();
            }

            if (TempData["SuccessModal"] != null)
            {
                ViewBag.SuccessModal = TempData["SuccessModal"].ToString();
            }

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
         * Post : FilterUserByCompany
         * Filtre les utilisateurs par emplacement
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

        /**
         * POST: AddUser
         * Ajoute un utilisateur après validation des champs
         */
        [HttpPost]
        public ActionResult AddUser(
            string lastname, string firstname, string idCompany,
            string mail, string phone, string idRole, string job
            )
        {
            bool addUser = true;
            UserDTO user = new UserDTO();
            string errorMessage = "";

            if (lastname.Trim() != "") user.Lastname = lastname;
            else
            {
                addUser = false;
                errorMessage = errorMessage + "Nom de famille non défini. ";
            }

            if (firstname.Trim() != "") user.Firstname = firstname;
            else
            {
                addUser = false;
                errorMessage = errorMessage + "Prénom non défini. ";
            }

            int resCompany = 0;
            if (Int32.TryParse(idCompany, out resCompany))
            {
                user.Id_Company = resCompany;
            }
            else
            {
                addUser = false;
                errorMessage = errorMessage + "Etablissement non choisi. ";
            }

            if (mail.Trim() != "") user.Email = mail;
            else
            {
                addUser = false;
                errorMessage = errorMessage + "Email non défini. ";
            }

            int resRole = 0;
            if (Int32.TryParse(idRole, out resRole))
            {
                user.Id_Role = resRole;
            }
            else
            {
                addUser = false;
                errorMessage = errorMessage + "Role non défini. ";
            }

            if (job.Trim() != "") user.Job = job;
            else
            {
                addUser = false;
                errorMessage = errorMessage + "Poste non défini. ";
            }

            user.Password = "Motdepasse1";
            user.Is_Active = 1;
            user.Note = "";
            user.Is_Address_Private = 1;

            if (addUser)
            {
                userLogic.InsertOrUpdateUser(user);
                TempData["SuccessModal"] = "Utilisateur " + user.Lastname + " " + user.Firstname + " ajouté avec succès";
            }
            else
            {
                TempData["FormError"] = errorMessage;
            }
            return RedirectToAction("Index");
        }
    }
}