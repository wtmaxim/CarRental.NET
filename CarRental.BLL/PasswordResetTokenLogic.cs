using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Model;
using CarRental.DAL;

namespace CarRental.BLL
{
   public class PasswordResetTokenLogic
    {
        private readonly PasswordResetTokenEngine passwordResetTokenEngine;
        public PasswordResetTokenLogic()
        {
            passwordResetTokenEngine = new PasswordResetTokenEngine();
        }
        public PasswordResetTokenDTO Get(string token)
        {
            return passwordResetTokenEngine.Get(token);
        }

        public void insert(PasswordResetTokenDTO passwordResetTokenDTO)
        {
            passwordResetTokenEngine.Insert(passwordResetTokenDTO);
        }
    }
}
