using CarRental.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarRental.BLL;
using System.Net.Mail;
using System.Net;

namespace CarRental.UI.Controllers
{
    
    public class AccountController : Controller
    {
        private readonly UtilisateurLogic utilisateurLogic;
        private readonly PasswordResetTokenLogic passwordResetTokenLogic;
       
        public AccountController()
        {
            utilisateurLogic = new UtilisateurLogic();
            passwordResetTokenLogic = new PasswordResetTokenLogic();
        }

        public ActionResult Login()
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
            return RedirectToAction("Login", "Account");
        }

       public ActionResult PasswordReset()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PasswordReset(UserDTO userDTO)
        {
            //TODO Verifier que l'email existe dans base de données
            UserDTO userDetails = utilisateurLogic.GetUserByMail(userDTO.Email);
            if (userDetails == null)
            {
                //TODO Afficher un message d'erreur si l'email n'existe pas
                userDTO.LoginErrorMessage = "Aucun compte avec cet email n'a été trouvé";
                return View("PasswordReset", userDTO);
            }
            else
            {
                PasswordResetTokenDTO passwordResetTokenDTO = new PasswordResetTokenDTO(userDetails.Id);
                passwordResetTokenLogic.insert(passwordResetTokenDTO);
               // SendPasswordResetLinkEmail(userDTO.Email, passwordResetTokenDTO);
                //TODO Générer le lien pour changer le mot de passe
                //TODO Envoyer un mail à l'utilisateur si l'email existe
            }

            return View();
        }

        [NonAction]
        public void SendPasswordResetLinkEmail(string emailID, PasswordResetTokenDTO passwordResetTokenDTO)
        {
            var verifyUrl = "/Account/ChangePassword/" + passwordResetTokenDTO.Token;
            var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);
            var fromEmail = new MailAddress("mywebprocarental@gmail.com", "CarRental");
            var toEmail = new MailAddress(emailID);
            var fromEmailPassword = "@DminMsii";
            string subject = "Demande de changement de mot de passe";
            string body = "Bonjour, veuillez cliquez sur ce <a href='"+link+"'>lien</a> pour changer votre mot de passe.";

            var smtp = new SmtpClient
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
                smtp.Send(message);
        }
        
    }
}
