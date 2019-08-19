using CarRental.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarRental.BLL;

namespace CarRental.UI.Controllers
{
    
    public class LoginController : Controller
    {
        private readonly UtilisateurLogic utilisateurLogic;
       
        public LoginController()
        {
            utilisateurLogic = new UtilisateurLogic();
        }

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Autherize(UserDTO userDTO)
        {
            UserDTO userDetails = utilisateurLogic.GetUserByMailAndPassword(userDTO.Email, userDTO.Password);
            if (userDetails == null)
            {
                userDTO.LoginErrorMessage = "Mauvais identifiants";
                return View("Index",userDTO);
            }
            else
            {

                Session["userID"] = userDetails.Id;
                Session["firstname"] = userDetails.Firstname;
                Session["lastName"] = userDetails.Lastname;
                Session["userJob"] = userDetails.Job;
                return RedirectToAction("Index", "Home");
            }

            
        }
        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }

       public ActionResult PasswordReset()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PasswordReset(UserDTO userDTO)
        {
            //TODO Verifier que l'email existe dans base de données
            //TODO Générer le lien pour changer le mot de passe
            //TODO Envoyer un mail à l'utilisateur si l'email existe
            //TODO Afficher un message d'erreur si l'email n'existe pas
            return View();
        }
        

        }
    }
}