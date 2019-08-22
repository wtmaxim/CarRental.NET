using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Model;

namespace CarRental.DAL
{
    public interface IPasswordResetTokenEngine
    {
        PasswordResetTokenDTO Get(String token);
        void Insert(PasswordResetTokenDTO passwordResetTokenDTO);
        void Delete(int id);
    }
}
