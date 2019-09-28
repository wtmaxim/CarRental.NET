using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Model;

namespace CarRental.DAL
{
    public class PasswordResetTokenEngine : IPasswordResetTokenEngine
    {
        private PasswordResetTokenMapping passwordResetTokenMapping;
        public PasswordResetTokenEngine()
        {
            passwordResetTokenMapping = new PasswordResetTokenMapping();
        }

        public void Delete(int id)
        {
            using (CarRentalEntities contexte = new CarRentalEntities())
            {
                try
                {
                    contexte.usp_PasswordResetToken_DELETE_BY_ID(id);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }

            }
        }

        public PasswordResetTokenDTO Get(string token)
        {
            using (CarRentalEntities contexte = new CarRentalEntities())
            {
                return passwordResetTokenMapping.MapToPasswordResetTokenDTO(contexte.usp_PasswordResetToken_get(token).FirstOrDefault());
            }
        }

        public void Insert(PasswordResetTokenDTO passwordResetTokenDTO)
        {
            using (CarRentalEntities contexte = new CarRentalEntities())
            {
                contexte.usp_PasswordResetToken_Insert(passwordResetTokenDTO.Token, passwordResetTokenDTO.Expiry_date, passwordResetTokenDTO.User_id);
            }
        }
    }
}
