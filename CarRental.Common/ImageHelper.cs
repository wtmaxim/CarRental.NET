using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Web;
using System.IO;

namespace CarRental.Common
{
    public  class ImageHelper
    {
        /*
        * On cherche l'url de la photo de profil (jpg ou png)
        * Si elle n'existe pas, on affiche la default
        */
        public static string GetProfileImagePath(int userId, HttpServerUtilityBase Server)
        {
            var userImagesUrl = ConfigurationManager.AppSettings["UtilisateurImageURL"];
            var profilePath = userImagesUrl + "default.png";

            if (userId != -1)
            {
                string[] profilePathPossibilities = {
                    userImagesUrl + userId + "-PP.jpg",
                    userImagesUrl + userId + "-PP.jpeg",
                    userImagesUrl + userId + "-PP.png",
                };
                foreach (string profilePathPossibility in profilePathPossibilities)
                {
                    if (File.Exists(Server.MapPath(profilePathPossibility)))
                    {
                        profilePath = profilePathPossibility;
                    }
                }
            }
            return profilePath;
        }

        /*
        * On cherche l'url du recto du permis de conduire 
        * (jpg, jpeg ou png)
        */
        public static string GetDriverLicenceRectoPath(int userId, HttpServerUtilityBase Server)
        {
            var userImagesUrl = ConfigurationManager.AppSettings["UtilisateurImageURL"];
            string driverLicenceRectoPath = "";
            string[] rectoPossibilities = {
                userImagesUrl + userId + "-DLRecto.jpg",
                userImagesUrl + userId + "-DLRecto.jpeg",
                userImagesUrl + userId + "-DLRecto.png",
            };
            foreach (string rectoPossibility in rectoPossibilities)
            {
                if (File.Exists(Server.MapPath(rectoPossibility)))
                {
                    driverLicenceRectoPath = rectoPossibility;
                }
            }

            return driverLicenceRectoPath;
        }

        /*
        * On cherche l'url du verso du permis de conduire 
        * (jpg, jpeg ou png)
        */
        public static string GetDriverLicenceVersoPath(int userId, HttpServerUtilityBase Server)
        {
            var userImagesUrl = ConfigurationManager.AppSettings["UtilisateurImageURL"];
            var driverLicenceVersoPath = "";
            string[] versoPossibilities = {
                userImagesUrl + userId + "-DLVerso.jpg",
                userImagesUrl + userId + "-DLVerso.jpeg",
                userImagesUrl + userId + "-DLVerso.png",
            };
            foreach (string versoPossibility in versoPossibilities)
            {
                if (File.Exists(Server.MapPath(versoPossibility)))
                {
                    driverLicenceVersoPath = versoPossibility;
                }
            }
            return driverLicenceVersoPath;
        }
    }
}
