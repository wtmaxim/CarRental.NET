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

        public AccountController()
        {
            utilisateurLogic = new UtilisateurLogic();
            passwordResetTokenLogic = new PasswordResetTokenLogic();
            roleLogic = new RoleLogic();
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
                userDetails.Role = roleLogic.GetUserRoles(userDetails.Email);
                Session["userID"] = userDetails.Id;
                Session["firstname"] = userDetails.Firstname;
                Session["lastName"] = userDetails.Lastname;
                Session["userJob"] = userDetails.Job;
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
                //Générer le token
                PasswordResetTokenDTO passwordResetTokenDTO = new PasswordResetTokenDTO(userDetails.Id);
                // Sauvegarder le token en base
                passwordResetTokenLogic.Insert(passwordResetTokenDTO);

                // Générer le lien pour changer le mot de passe
                // Envoyer un mail à l'utilisateur 
                SendPasswordResetLinkEmail(userDTO.Email, passwordResetTokenDTO);
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
                    SendPasswordChangedMail(_user.Email);
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="emailTarget"></param>
        /// <param name="passwordResetTokenDTO"></param>
        [NonAction]
        public void SendPasswordResetLinkEmail(string emailTarget, PasswordResetTokenDTO passwordResetTokenDTO)
        {
            var verifyUrl = "/Account/ChangePassword/" + passwordResetTokenDTO.Token;
            var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);
            string subject = "Demande de changement de mot de passe";
            string body = "Bonjour, veuillez cliquez sur ce <a href='" + link + "'>lien</a> pour changer votre mot de passe.<br/>" +
                "Ce lien a une durée de validité de 2 heures, passé ce délai vous devrez réitérer votre demande";
            SendEMail(emailTarget, subject, body);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="emailTarget"></param>
        [NonAction]
        public void SendPasswordChangedMail(string emailTarget)
        {
            string subject = "Votre mot de passe à été changé";
            string body = "Bonjour, nous vous confirmons le changement de votre mot de passe.";
            SendEMail(emailTarget, subject, body);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="emailTarget"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        [NonAction]
        public void SendEMail(string emailTarget, string subject, string body)
        {
            var fromEmail = new MailAddress("mywebprocarental@gmail.com", "CarRental");
            var toEmail = new MailAddress(emailTarget);
            var fromEmailPassword = "@DminMsii";
            var smtpClient = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)
            };

            using (var message = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })
                smtpClient.Send(message);
            smtpClient.Dispose();
        }
    }

}
