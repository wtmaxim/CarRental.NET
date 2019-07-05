using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.DAL
{
    public class UserEngine : IUserEngine
    {
        private UserMapping userMapping;

        public UserEngine()
        {
            userMapping = new UserMapping();
        }

        public UserDTO Get(string email, string password)
        {
            using (CarRentalEntities context = new CarRentalEntities())
            {
                context.usp_User_Get_Email_Password(email, password);
            }
        }
    }
}
