using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Model;
using CarRental.DAL;
using CarRental.Common;

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

        public UserDTO GetUserByMail(string mail)
        {
            return utilisateurEngine.GetByMail(mail);
        }
        public UserDTO Get(int id)
        {
            return utilisateurEngine.Get(id);
        }

        public void UpdatePasswordByMail(UserDTO userDTO)
        {
            if (userDTO.Password == userDTO.confirmPassword)
            {
                utilisateurEngine.UpdatePasswordByMail(SecurePasswordHasherHelper.Hash(userDTO.Password),userDTO.Email);
            }
            
        }
    }
}
