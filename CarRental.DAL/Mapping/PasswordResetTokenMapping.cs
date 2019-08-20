using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Model;

namespace CarRental.DAL
{
   public class PasswordResetTokenMapping
    {
        public PasswordResetTokenDTO MapToPasswordResetTokenDTO(PasswordResetToken passwordResetToken)
        {
            if (passwordResetToken != null)
                {
                    return new PasswordResetTokenDTO()
                    {
                        Id = passwordResetToken.Id,
                        Expiry_date = passwordResetToken.expiry_date,
                        Token = passwordResetToken.token,
                        User_id = passwordResetToken.user_id
                    };
                }
            else
                {
                    //TODO
                    return null;
                }            
        }

        public List<PasswordResetTokenDTO> MapToListPasswordResetTokenDTO(List<PasswordResetToken> passwordResetTokens)
        {
            if (passwordResetTokens != null)
                {
                    return (from PasswordResetToken passwordResetToken in passwordResetTokens
                            let newPasswordResetToken = new PasswordResetTokenDTO
                            {
                                Id = passwordResetToken.Id,
                                Expiry_date = passwordResetToken.expiry_date,
                                Token = passwordResetToken.token,
                                User_id = passwordResetToken.user_id
                            }
                            select newPasswordResetToken).ToList();
                }
            else
                {
                    //TODO
                    return null;
                }
        }
    }
}
