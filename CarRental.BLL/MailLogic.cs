using CarRental.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.BLL
{
   public class MailLogic
    {
        private readonly PasswordResetTokenLogic passwordResetTokenLogic;
        public MailLogic()
        {
            passwordResetTokenLogic = new PasswordResetTokenLogic();
          }



        /// <summary>
        /// Methode permettant l'envoie d'un mail.
        /// </summary>
        /// <param name="emailTarget"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
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

        public void SendPasswordResetLinkEmail(string emailTarget, PasswordResetTokenDTO passwordResetTokenDTO, string uri, string pathAndQuery)
        {
            var verifyUrl = "/Account/ChangePassword/" + passwordResetTokenDTO.Token;
            var link = uri.Replace(pathAndQuery, verifyUrl);
            string subject = "Demande de changement de mot de passe";
            string body = "Bonjour,<br> Veuillez cliquer sur ce <a href='" + link + "'>lien</a> pour changer votre mot de passe.<br/>" +
                "Ce lien a une durée de validité de 2 heures, passé ce délai vous devrez réitérer votre demande. <br> <br> Bonne journée, <br> CarRental";
            SendEMail(emailTarget, subject, body);
        }

        public void SendNewAccountLinkEmail(string emailTarget, PasswordResetTokenDTO passwordResetTokenDTO, string uri, string pathAndQuery)
        {
            var verifyUrl = "/Account/ChangePassword/" + passwordResetTokenDTO.Token;
            var link = uri.Replace(pathAndQuery, verifyUrl);
            string subject = "Bienvenue sur CarRental";
            string body = "Bonjour,<br><br> Vous venez d'obtenir l'accès à l'application CarRental, veuillez cliquez sur ce <a href='" + link + "'>lien</a> afin de définir votre mot de passe.<br/>" +
                "Ce lien a une durée de validité de 2 heures, passé ce délai vous devrez effectuer une demande manuelle de changement de mot passe <br> <br> Bonne journée, <br> CarRental";
            SendEMail(emailTarget, subject, body);
        }
        /// <summary>
        /// Methode permettant l'envoie d'un mail de changement de mot de passe
        /// </summary>
        /// <param name="emailTarget"></param>
        public void SendPasswordChangedMail(string emailTarget)
        {
            string subject = "Votre mot de passe à été modifié";
            string body = "Bonjour,<br> Nous vous confirmons le changement de votre mot de passe. <br> <br> Bonne journée, <br> CarRental";
            SendEMail(emailTarget, subject, body);
        }

        /// <summary>
        /// Methode qui génère un token de changement de mot de passe et qui l'insère en base de données.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public PasswordResetTokenDTO GeneratePasswordResetToken(UserDTO user)
        {
            //Générer le token
            PasswordResetTokenDTO passwordResetTokenDTO = new PasswordResetTokenDTO(user.Id);
            // Sauvegarder le token en base
            passwordResetTokenLogic.Insert(passwordResetTokenDTO);
            return passwordResetTokenDTO;
        }
    }
}
