using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarRental.BLL;
using CarRental.Model;
using CarRental.UI.ViewsModels.User;

namespace CarRental.UI.Controllers
{
    public class UtilisateurController : Controller
    {
        private readonly UserLogic userLogic;
        private readonly CompanyLogic companyLogic;
        private readonly RoleLogic roleLogic;

        public UtilisateurController()
        {
            userLogic = new UserLogic();
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
            List<CompanyDTO> companies = companyLogic.List();
            List<RoleDTO> roles = roleLogic.List();

            UserIndexViewsModel vm = new UserIndexViewsModel
            {
                Users = UserDTOToTuple(users),
                Companies = companies,
                Roles = roles
            };

            if (TempData["error"] != null)
            {
                ViewBag.Error = TempData["error"].ToString();
            }
            if (TempData["globalError"] != null)
            {
                ViewBag.GlobalError = TempData["globalError"].ToString();
            }
            if (TempData["userToEdit"] != null)
            {
                // ViewBag.UserToEdit = users.Find(u => u.Id == (int)TempData["UserToEdit"]);
            }
            return View(vm);    
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
                var company = companyLogic.List().Find(c => c.Id == user.Id_Company);
                var role = roleLogic.List().Find(r => r.Id == user.Id_Role);
                var tupleData = new Tuple<UserDTO, CompanyDTO, RoleDTO>(usr, company, role);
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
                UserIndexViewsModel vm = new UserIndexViewsModel
                {
                    Users = UserDTOToTuple(users)
                };
                return View("Index", vm);
            }
            else
            {
                return RedirectToAction("Index");
            }
            
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

            if (addUser) userLogic.AddUser(user);
            else TempData["error"] = errorMessage;
            return RedirectToAction("Index");
        }

        /**
         * GET : DeleteUser
         * Archive l'utilisateur dans la base de donnée et retourne vers l'index
         */
        [HttpGet]
        public ActionResult ArchiveUser(int IdUser)
        {
            if (IdUser != null)
            {
            userLogic.Archive(IdUser);
            }
            else
            {
                TempData["globalError"] = "Erreur lors de la supression de l'utilisateur";
            }
            return RedirectToAction("Index");

        }

        /**
         * GET : UpdateUserForm
         * Récupère l'utilisateur à éditer pour le renvoyer dans un viewbag dans la vue
         */
        [HttpGet]
        public ActionResult UpdateUserForm(int IdUser)
        {
            TempData["userToEdit"] = IdUser;
            return RedirectToAction("Index");
        }
    }
}