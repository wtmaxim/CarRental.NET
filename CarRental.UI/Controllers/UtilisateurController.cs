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
            List<UserDTO> users = userLogic.ListActive();
            List<CompanyDTO> companies = companyLogic.List();
            List<RoleDTO> roles = roleLogic.List();

            Tuple<UserDTO, CompanyDTO, RoleDTO> userToEdit = null;
            if (TempData["userToEdit"] != null)
            {
                int userId = (int)TempData["UserToEdit"];
                UserDTO usr = users.Find(u => u.Id == userId);
                RoleDTO rle = roles.Find(r => r.Id == usr.Id_Role);
                CompanyDTO cmp = companies.Find(c => c.Id == usr.Id_Company);
                userToEdit = new Tuple<UserDTO, CompanyDTO, RoleDTO>(usr, cmp, rle);
            }

            UtilisateurIndexViewModel vm = new UtilisateurIndexViewModel
            {
                Users = UserDTOToTuple(users),
                Companies = companies,
                Roles = roles,
                UserToEdit = userToEdit
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
                    Roles = roleLogic.List(),
                    UserToEdit = null
                };
                return View("Index", vm);
            }
            else
            {
                return RedirectToAction("Index");
            }

        }

        /**
         * Post : FilterUsers
         * Filtre les utilisateurs :
         *  - par entreprise
         *  - ou par leur status : actif, non actifs, tous
         */
        [HttpPost]
        public ActionResult FilterUsers(int? idCompany, int? activeFilterVal)
        {
            List<UserDTO> users;

            switch (activeFilterVal)
            {
                case 0:
                    users = userLogic.ListUnactive();
                    break;
                case 2:
                    users = userLogic.ListAll();
                    break;
                default:
                    users = userLogic.ListActive();
                    break;
            }

            if (idCompany != null)
            {
                users = users.FindAll(u => u.Id_Company == idCompany);
            }

            UtilisateurIndexViewModel vm = new UtilisateurIndexViewModel
            {
                Users = UserDTOToTuple(users),
                Companies = companyLogic.List(),
                Roles = roleLogic.List(),
                FilterUserByActiveVal = activeFilterVal,
                FilterUserByCompanyId = idCompany ?? null
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
            
            UserDTO user = new UserDTO();
            user.Lastname = lastname;
             user.Firstname = firstname;
            int resCompany = 0;
            Int32.TryParse(idCompany, out resCompany);
            user.Id_Company = resCompany;
            user.Email = mail;
            int resRole = 0;
            Int32.TryParse(idRole, out resRole);
            user.Id_Role = resRole;
            user.Job = job;
            user.Password = "Motdepasse1";
            user.Is_Active = 1;
            user.Note = "";
            user.Is_Address_Private = 1;
            user.Phone_Number = phone;

            Tuple<Boolean, String> res = this.isFormValid(lastname, firstname, idCompany, mail, phone, idRole, job);

            if (res.Item1)
            {
                userLogic.InsertOrUpdateUser(user);
                TempData["SuccessModal"] = "Utilisateur " + user.Lastname + " " + user.Firstname + " ajouté avec succès";
            }
            else
            {
                TempData["FormError"] = res.Item2;
            }
            return RedirectToAction("Index");
        }

        /**
         * isFormValid
         * Validation du formulaire d'un utilisateur (création et édition)
         */
        public Tuple<Boolean, String> isFormValid(
                string lastname, string firstname, string idCompany,
                string mail, string cellphone, string idRole, string job
            )
        {
            bool isFormValid = true;
            string errorMessage = "";

            if (lastname.Trim() == "")
            {
                isFormValid = false;
                errorMessage = errorMessage + "Nom de famille non défini. ";
            }

            if (firstname.Trim() == "")
            {
                isFormValid = false;
                errorMessage = errorMessage + "Prénom non défini. ";
            }

            int resCompany = 0;
            if (!Int32.TryParse(idCompany, out resCompany))
            {
                isFormValid = false;
                errorMessage = errorMessage + "Etablissement non choisi. ";
            }

            if (mail.Trim() == "")
            {
                isFormValid = false;
                errorMessage = errorMessage + "Email non défini. ";
            }

            int resRole = 0;
            if (!Int32.TryParse(idRole, out resRole))
            {
                isFormValid = false;
                errorMessage = errorMessage + "Role non défini. ";
            }

            if (job.Trim() == "")
            {
                isFormValid = false;
                errorMessage = errorMessage + "Poste non défini. ";
            }

            if (cellphone.Trim() != "" && !(cellphone is int))
            {
                isFormValid = false;
                errorMessage = errorMessage + "Le numéro de téléphone doit être composé de chiffres.";
            }

            return new Tuple<Boolean, String>(isFormValid, errorMessage);
        }

        /**
        * GET : ArchiveUnarchiveUser
        * Archive ou désarchive l'utilisateur dans la bdd
        */
        [HttpGet]
        public ActionResult ArchiveUnarchiveUser(int IdUser)
        {
            if (IdUser != null)
            {
                
                UserDTO user = userLogic.Get(IdUser);
                if (user.Is_Active == 0)
                {
                    userLogic.Unarchive(IdUser);
                    TempData["SuccessModal"] = "Utilisateur " + user.Lastname + " " + user.Firstname + " activé avec succès";
                }
                else
                {
                    userLogic.Archive(IdUser);
                    TempData["SuccessModal"] = "Utilisateur " + user.Lastname + " " + user.Firstname + " désactivé avec succès";
                }
                
            }
            else
            {
                TempData["ErrorModal"] = "Erreur lors de la supression de l'utilisateur";
            }
            return RedirectToAction("Index");

        }

        /**
         * GET : UpdateUserForm
         * Récupère l'utilisateur à éditer pour le renvoyer dans le formulaire d'édition
         */
        [HttpGet]
        public ActionResult UpdateUserForm(int IdUser)
        {
            TempData["userToEdit"] = IdUser;
            return RedirectToAction("Index");
        }

        /**
         * POST : UpdateUser
         * Met à jour l'utilisateur dans la base
         */
        [HttpPost]
        public ActionResult UpdateUser(
            int id, string lastname, string firstname, string idCompany,
                string mail, string phone, string idRole, string job
            )
        {
            if (id != -1)
            {
                UserDTO user = new UserDTO();
                user.Id = id;
                user.Lastname = lastname;
                user.Firstname = firstname;
                int resCompany = 0;
                Int32.TryParse(idCompany, out resCompany);
                user.Id_Company = resCompany;
                user.Email = mail;
                int resRole = 0;
                Int32.TryParse(idRole, out resRole);
                user.Phone_Number = phone;
                user.Id_Role = resRole;
                user.Job = job;
                user.Password = "Motdepasse1";
                user.Is_Active = 1;
                user.Note = "";
                user.Is_Address_Private = 1;

                Tuple<Boolean, String> res = this.isFormValid(lastname, firstname, idCompany, mail, phone, idRole, job);

                if (res.Item1)
                {
                    userLogic.Update(user);
                    TempData["SuccessModal"] = "Utilisateur " + user.Lastname + " " + user.Firstname + " modifié avec succès";
                }
                else
                {
                    TempData["userToEdit"] = id;
                    TempData["FormError"] = res.Item2;
                }
            }
            
            return RedirectToAction("Index");
        }


    }
}