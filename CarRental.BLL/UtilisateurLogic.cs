using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Model;
using CarRental.DAL;

namespace CarRental.BLL
{
   public class UtilisateurLogic
    {
        private readonly IUtilisateurEngine utilisateurEngine;
        public UtilisateurLogic()
        {
            utilisateurEngine = new UtilisateurEngine();
        }

        public UserDTO GetUserByMailAndPassword(string mail, string password)
        {
            return utilisateurEngine.GetByMailAndPassword(mail, password);
        }

        public UserDTO GetUserByMail(String mail)
        {
            return utilisateurEngine.GetByMail(mail);
        }
    }
}
