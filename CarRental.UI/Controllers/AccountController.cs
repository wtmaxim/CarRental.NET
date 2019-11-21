using CarRental.Model;
using System;
using System.Web.Mvc;
using CarRental.BLL;
using System.Net.Mail;
using System.Net;
using CarRental.Common;
using System.Web.Security;

namespace CarRental.UI.Controllers
{

    public class AccountController : Controller
    {
        private readonly UtilisateurLogic utilisateurLogic;
        private readonly RoleLogic roleLogic;
        private readonly PasswordResetTokenLogic passwordResetTokenLogic;
        private readonly NotificationLogic notifLogic;
        private readonly MailLogic mailLogic;

        public AccountController()
        {
            utilisateurLogic = new UtilisateurLogic();
            passwordResetTokenLogic = new PasswordResetTokenLogic();
            roleLogic = new RoleLogic();
            notifLogic = new NotificationLogic();
            mailLogic = new MailLogic();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userDTO"></param>
        /// <param name="ReturnUrl"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Login(UserDTO userDTO, string ReturnUrl)
        {
            UserDTO userDetails = utilisateurLogic.GetUserByMail(userDTO.Email);

            if (userDetails == null)
            {
                userDTO.LoginErrorMessage = "Aucun compte n'a été trouvé avec cette addresse";
                return View("Login", userDTO);
            }
            else if (SecurePasswordHasherHelper.Verify(userDTO.Password, userDetails.Password) == false)
            {
                userDTO.LoginErrorMessage = "Vérifiez vos identifiants";
                return View("Login", userDTO);
            }
            else
            {
                Session["userID"] = userDetails.Id;
                Session["firstname"] = userDetails.Firstname;
                Session["lastName"] = userDetails.Lastname;
                Session["userJob"] = userDetails.Job;

                Session["notifs"] = notifLogic.ListAllForUser(userDetails.Id).FindAll(n => n.IsRead == 0).Count;

                FormsAuthentication.SetAuthCookie(userDetails.Email, false);
                return Redirect("/");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Login", "Account");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult PasswordReset()
        {
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult PasswordReset(UserDTO userDTO)
        {
            bool status = false;
            string message;
            //TODO Verifier que l'email existe dans base de données
            UserDTO userDetails = utilisateurLogic.GetUserByMail(userDTO.Email);
            if (userDetails == null)
            {
                //TODO Afficher un message d'erreur si l'email n'existe pas
                message = "Aucun compte avec cet email n'a été trouvé.";

            }
            else
            {               

                // Générer le lien pour changer le mot de passe
                // Envoyer un mail à l'utilisateur 
                mailLogic.SendPasswordResetLinkEmail(userDTO.Email, mailLogic.GeneratePasswordResetToken(userDetails), Request.Url.AbsoluteUri, Request.Url.PathAndQuery);
                message = "Un email contenant un lien vers la page d'édition de votre mot de passe vous à été envoyé.";
                status = true;
            }
            ViewBag.Message = message;
            ViewBag.Status = status;
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ChangePassword(string id)
        {
            // Variable qui me permet de déterminer si je dois afficher une erreur true = erreur
            bool status = true;
            // Variable qui me permet d'afficher le message de mon erreur
            string message;
            if (id != null && id != "")
            {
                PasswordResetTokenDTO passwordResetTokenDTO = passwordResetTokenLogic.Get(id);
                if (passwordResetTokenDTO == null)
                {
                    // Si le token n'existe pas
                    message = "Lien invalide";
                }
                else if (passwordResetTokenDTO.Expiry_date.HasValue && DateTime.Compare(passwordResetTokenDTO.Expiry_date.Value, DateTime.Now) < 0)
                {
                    message = " Ce lien est expiré";
                }
                else
                {
                    // Si le code token existe et qu'il est encore valide
                    status = false;
                    UserDTO userDTO = utilisateurLogic.Get(passwordResetTokenDTO.User_id);
                    ViewBag.UserNow = userDTO;
                    ViewBag.Status = status;
                    return View("ChangePassword", userDTO);
                }
            }
            else
            {
                // Si il n'y a pas de token
                message = "Lien invalide";
            }
            ViewBag.Message = message;
            ViewBag.Status = status;
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="guid"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ChangePassword(UserDTO user, string guid)
        {
            if (guid != null && guid != "")
            {
                PasswordResetTokenDTO prt = passwordResetTokenLogic.Get(guid);
                UserDTO _user = utilisateurLogic.Get(prt.User_id);
                if (user.Password == user.confirmPassword)
                {
                    _user.Password = user.Password;
                    _user.confirmPassword = user.confirmPassword;
                    UpdatePassword(_user);
                    passwordResetTokenLogic.Delete(prt);
                    mailLogic.SendPasswordChangedMail(_user.Email);
                    ViewBag.Message = "Votre mot de passe à correctement été modifié, veuillez vous identifier pour accéder à l'application.";
                    ViewBag.Status = true;
                }
            }
            else
            {
                ViewBag.Message = "Il y a eu une erreur";
                ViewBag.Status = false;
            }

            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userDTO"></param>
        [NonAction]
        public void UpdatePassword(UserDTO userDTO)
        {
            if (userDTO.Password == userDTO.confirmPassword)
            {
                utilisateurLogic.UpdatePasswordByMail(userDTO);
            }
        }
        
       
       
    }

}
