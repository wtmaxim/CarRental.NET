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


namespace CarRental.UI.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UtilisateurLogic userLogic;
        private readonly CompanyLogic companyLogic;
        private readonly RoleLogic roleLogic;

        public ProfileController ()
        {
            userLogic = new UtilisateurLogic();
            companyLogic = new CompanyLogic();
            roleLogic = new RoleLogic();
        }

        /**
         * GET: Profile
         * Page d'index du profile de l'utilisateur
         */
        public ActionResult Index()
        {
            int idCurrentUser = (int)Session["userId"];
            UserDTO user = userLogic.Get(idCurrentUser);
            // RoleDTO role = roleLogic.List().Find(r => r.Id == user.Id_Role);
            RoleDTO role = new RoleDTO();
            CompanyDTO company = companyLogic.List().Find(c => c.Id == user.Id_Company);

            ProfileIndexViewModel vm = new ProfileIndexViewModel
            {
                CurrentUser = new Tuple<UserDTO, CompanyDTO, RoleDTO>(user, company, role)
            };

            if (TempData["ErrorModal"] != null)
            {
                ViewBag.ErrorModal = TempData["ErrorModal"].ToString();
            }
            if (TempData["EditDrivingLicence"] != null)
            {
                ViewBag.EditDrivingLicence = TempData["EditDrivingLicence"].ToString();
            }
            return View(vm);
        }

        /**
         * POST : AddDrivingLicence
         * Enregistre le permis de conduire de l'utilisateur
         */
        [HttpPost]
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
        private void DeletePreviousFile(string rectoOrVerso)
        {
            string[] filePossibilities = new string[3];
            if (rectoOrVerso.Equals("UtilisateurImageRecto"))
            {
                filePossibilities[0] = ConfigurationManager.AppSettings["UtilisateurImageURL"] + Session["userId"] + "-DLRecto.jpg";
                filePossibilities[1] = ConfigurationManager.AppSettings["UtilisateurImageURL"] + Session["userId"] + "-DLRecto.jpeg";
                filePossibilities[2] = ConfigurationManager.AppSettings["UtilisateurImageURL"] + Session["userId"] + "-DLRecto.png";
            }
            else
            {
                filePossibilities[0] = ConfigurationManager.AppSettings["UtilisateurImageURL"] + Session["userId"] + "-DLVerso.jpg";
                filePossibilities[1] = ConfigurationManager.AppSettings["UtilisateurImageURL"] + Session["userId"] + "-DLVerso.jpeg";
                filePossibilities[2] = ConfigurationManager.AppSettings["UtilisateurImageURL"] + Session["userId"] + "-DLVerso.png";
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
            } catch (Exception e)
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
        public ActionResult ToggleDrivingLicenceEditForm(string toggleVal)
        {
            TempData["EditDrivingLicence"] = toggleVal;
            return RedirectToAction("Index");
        }


    }
}
 