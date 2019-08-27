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

        public void Insert(PasswordResetTokenDTO passwordResetTokenDTO)
        {
            passwordResetTokenEngine.Insert(passwordResetTokenDTO);
        }
        public void Delete(PasswordResetTokenDTO passwordResetTokenDTO)
        {
            if (passwordResetTokenDTO.Id == 0)
            {
                throw new NullReferenceException();

            }
            else
            {
                passwordResetTokenEngine.Delete(passwordResetTokenDTO.Id);
            }



        }
    }
}
