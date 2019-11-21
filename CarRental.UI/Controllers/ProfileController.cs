using CarRental.BLL;
using CarRental.Model;
using CarRental.UI.ViewsModels.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Configuration;
using System.Drawing;
using System.Web.Security;

namespace CarRental.UI.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UtilisateurLogic userLogic;
        private readonly CompanyLogic companyLogic;
        private readonly RoleLogic roleLogic;
        private readonly PasswordResetTokenLogic passwordResetTokenLogic;
        private readonly NotificationLogic notificationLogic;

        // Constantes des images définies dans les formulaires
        public const string DRIVING_LICENCE_RECTO = "UtilisateurImageRecto";
        public const string DRIVING_LICENCE_VERSO = "UtilisateurImageVerso";
        public const string PROFILE_PICTURE = "UtilisateurProfilePicture";

        public ProfileController ()
        {
            userLogic = new UtilisateurLogic();
            companyLogic = new CompanyLogic();
            roleLogic = new RoleLogic();
            passwordResetTokenLogic = new PasswordResetTokenLogic();
            notificationLogic = new NotificationLogic();
        }

        /**
         * GET: Profile
         * Page d'index du profile de l'utilisateur
         */
         [Authorize (Roles="Consulter son profil")]
        public ActionResult Index(int? idUser)
        {
            int idCurrentUser = idUser == null ? (int)Session["userId"] : (int)idUser;
            bool isMyProfile = idUser == null ? true : false;
            UserDTO user = userLogic.Get(idCurrentUser);
            RoleDTO role = new RoleDTO();
            CompanyDTO company = companyLogic.List().Find(c => c.Id == user.Id_Company);

            Session["notifs"] = notificationLogic.ListAllForUser(idCurrentUser).FindAll(n => n.IsRead == 0).Count;

            ProfileIndexViewModel vm = new ProfileIndexViewModel
            {
                CurrentUser = new Tuple<UserDTO, CompanyDTO, RoleDTO>(user, company, role),
                isSessionUserProfile = isMyProfile
            };

            if (TempData["ErrorModal"] != null)
            {
                ViewBag.ErrorModal = TempData["ErrorModal"].ToString();
            }
            if (TempData["EditDrivingLicence"] != null)
            {
                ViewBag.EditDrivingLicence = TempData["EditDrivingLicence"].ToString();
            }
            ViewBag.RenderContactForm = "off";
            if (TempData["RenderContactForm"] != null)
            {
                ViewBag.RenderContactForm = TempData["RenderContactForm"].ToString();
            }
            ViewBag.RenderInformationsForm = "off";
            if (TempData["RenderInformationsForm"] != null)
            {
                ViewBag.RenderInformationsForm = TempData["RenderInformationsForm"].ToString();
            }
            return View(vm);
        }

        /**
         * POST : AddDrivingLicence
         * Enregistre le permis de conduire de l'utilisateur
         */
        [HttpPost]
        [Authorize(Roles = "Ajouter son permis de conduire")]
        public ActionResult AddDrivingLicence(object sender, System.EventArgs e)
        {
            string[] images = { "UtilisateurImageRecto", "UtilisateurImageVerso" };
            foreach (string image in images)
            {
                HttpPostedFileBase postedFile = Request.Files[image];
                if (postedFile != null && postedFile.ContentLength > 0)
                {
                    try
                    {
                        DeletePreviousFile(image);
                        string baseUserImagesUrl = ConfigurationManager.AppSettings["UtilisateurImageURL"];
                        string newFileName = image.Equals("UtilisateurImageRecto") ? Session["userId"] + "-DLRecto" : Session["userId"] + "-DLVerso";
                        string filePath = Server.MapPath(baseUserImagesUrl) + newFileName + Path.GetExtension(postedFile.FileName).ToLower();
                        postedFile.SaveAs(filePath);
                    }
                    catch (Exception ex)
                    {
                        TempData["ErrorModal"] = "Erreur lors de l'ajout de la capture du permis.";
                    }
                    
                }
            }
            return RedirectToAction("Index");
        }

        /**
         * DeletePreviousFile
         * Cherche s'il existe une capture déjà enregistré pour le permis de l'utilisateur (recto ou verso)
         * Puis supprime la capture qu'elle soit en png ou jpg
         */
        private void DeletePreviousFile(string fileType)
        {
            string[] filePossibilities = new string[3];
            switch (fileType)
            {
                case DRIVING_LICENCE_RECTO:
                    filePossibilities[0] = ConfigurationManager.AppSettings["UtilisateurImageURL"] + Session["userId"] + "-DLRecto.jpg";
                    filePossibilities[1] = ConfigurationManager.AppSettings["UtilisateurImageURL"] + Session["userId"] + "-DLRecto.jpeg";
                    filePossibilities[2] = ConfigurationManager.AppSettings["UtilisateurImageURL"] + Session["userId"] + "-DLRecto.png";
                    break;
                case DRIVING_LICENCE_VERSO:
                    filePossibilities[0] = ConfigurationManager.AppSettings["UtilisateurImageURL"] + Session["userId"] + "-DLVerso.jpg";
                    filePossibilities[1] = ConfigurationManager.AppSettings["UtilisateurImageURL"] + Session["userId"] + "-DLVerso.jpeg";
                    filePossibilities[2] = ConfigurationManager.AppSettings["UtilisateurImageURL"] + Session["userId"] + "-DLVerso.png";
                    break;
                case PROFILE_PICTURE:
                    filePossibilities[0] = ConfigurationManager.AppSettings["UtilisateurImageURL"] + Session["userId"] + "-PP.jpg";
                    filePossibilities[1] = ConfigurationManager.AppSettings["UtilisateurImageURL"] + Session["userId"] + "-PP.jpeg";
                    filePossibilities[2] = ConfigurationManager.AppSettings["UtilisateurImageURL"] + Session["userId"] + "-PP.png";
                    break;
            }

            try
            {
                foreach (string filePossibility in filePossibilities)
                {
                    if (System.IO.File.Exists(Server.MapPath(filePossibility)))
                    {
                        System.IO.File.Delete(Server.MapPath(filePossibility));
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /**
         * ToggleDrivingLicenceEditForm
         * param : toggleValue = "on" || "off"
         * Affiche ou non affiche l'édition du permis de conduire
         */
        [HttpGet]
        [Authorize(Roles = "Afficher le formulaire de modification du permis de conduire")]
        public ActionResult ToggleDrivingLicenceEditForm(string toggleVal)
        {
            TempData["EditDrivingLicence"] = toggleVal;
            return RedirectToAction("Index");
        }

        /**
         * POST : UpdateProfilePicture
         * EMet à jour la photo de profil de l'utilisateur
         */
        [HttpPost]
        [Authorize(Roles="Modifier sa photo de profil")]
        public ActionResult UpdateProfilePicture()
        {
            HttpPostedFileBase postedFile = Request.Files["UtilisateurProfilePicture"];
            if (postedFile != null && postedFile.ContentLength > 0)
            {
                try
                {
                    DeletePreviousFile(PROFILE_PICTURE);
                    Bitmap file = MakeSquarePhoto(postedFile);

                    string baseUserImagesUrl = ConfigurationManager.AppSettings["UtilisateurImageURL"];
                    string newFileName = Session["userId"] + "-PP";
                    string filePath = Server.MapPath(baseUserImagesUrl) + newFileName + Path.GetExtension(postedFile.FileName).ToLower();
                    file.Save(filePath);
                }
                catch (Exception ex)
                {
                    TempData["ErrorModal"] = "Erreur lors de l'ajout de la photo de profil.";
                }
            }

            return RedirectToAction("Index");
        }

        /**
         * MakeSquarePhoto
         * Coupe la photo de profile pour qu'elle soit carré
         */
        public Bitmap MakeSquarePhoto(HttpPostedFileBase postedFile)
        {
            try
            {
                Bitmap bmp = new Bitmap(postedFile.InputStream);
                int size = bmp.Height;

                Bitmap res = new Bitmap(size, size);
                Graphics g = Graphics.FromImage(res);
                g.FillRectangle(new SolidBrush(Color.White), 0, 0, size, size);
                int t = 0, l = 0;
                if (bmp.Height > bmp.Width)
                    t = (bmp.Height - bmp.Width) / 2;
                else
                    l = (bmp.Width - bmp.Height) / 2;
                g.DrawImage(bmp, new Rectangle(0, 0, size, size), new Rectangle(l, t, bmp.Width - l * 2, bmp.Height - t * 2), GraphicsUnit.Pixel);
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /**
         * GET : ToggleContactForm
         * Affiche ou non les formulaires dans "Contact"
         */
        [HttpGet]
        [Authorize(Roles = "Afficher le formulaire de contact")]
        public ActionResult ToggleContactForm(string toggleVal)
        {
            TempData["RenderContactForm"] = toggleVal;
            return RedirectToAction("Index");
        }

        /**
         * POST : UpdateContactForm
         *Met à jour le numéro de téléphone du profile
         */
        [HttpPost]
        [Authorize(Roles="Mettre à jour ses coordonées")]
        public ActionResult UpdateContactForm(string cellphone, string email)
        {
            int idCurrentUser = (int)Session["userId"];
            UserDTO user = userLogic.Get(idCurrentUser);

            int resPhone = 0;
            if (cellphone.Trim() != "" && !(Int32.TryParse(cellphone, out resPhone)))
            {
                TempData["ErrorModal"] = "Le numéro de téléphone doit être composé de chiffres.";
            }
            else
            {
                user.Phone_Number = cellphone;
                userLogic.Update(user);
            }

            return RedirectToAction("Index");
        }

        /**
         * GET: ToggleInformationsForm
         * Affiche ou non les formulaires dans "Informations"
         */
        [HttpGet]
        [Authorize (Roles="Afficher le formulaire des informations")]
        public ActionResult ToggleInformationsForm(string toggleVal)
        {
            TempData["RenderInformationsForm"] = toggleVal;
            return RedirectToAction("Index");
        }

        /**
         * POST : UpdateInformationsForm
         * Met à jour la note du profile
         */
        [HttpPost]
        [Authorize(Roles="Mettre à jour le formulaire des informations")]
        public ActionResult UpdateInformationsForm(string note)
        {
            int idCurrentUser = (int)Session["userId"];
            UserDTO user = userLogic.Get(idCurrentUser);
            user.Note = note;
            userLogic.Update(user);
            return RedirectToAction("Index");
        }

        /**
         * GET : EditPassword
         * Crée un PasswordResetTokenDTO, l'enregistre en base et redirige vers la méthode de changement de mot de passe avec token en param
         */
        [HttpGet]
        [Authorize(Roles="Modifier son mot de passe")]
        public ActionResult EditPassword()
        {
            int idCurrentUser = (int)Session["userId"];
            PasswordResetTokenDTO passwordResetTokenDTO = new PasswordResetTokenDTO(idCurrentUser);
            passwordResetTokenLogic.Insert(passwordResetTokenDTO);
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("ChangePassword", "Account", new { id = passwordResetTokenDTO.Token });
        }



    }
}
 