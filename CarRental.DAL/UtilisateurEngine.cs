using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.DAL.Interface;
using CarRental.DAL.Mapping;
using CarRental.Model;

namespace CarRental.DAL
{
    public class UtilisateurEngine : IUserEngine
    {
        private UserMapping UserMapping;
       
        public UtilisateurEngine()
        {
            UserMapping = new UserMapping();
           
        }
        UserDTO IUserEngine.Get(string email)
        {
            using (CarRentalEntities contexte = new CarRentalEntities())
            {
                User user = contexte.usp_User_GET(email).FirstOrDefault();
                return UserMapping.MapToUserDto(user);
            }
            throw new NotImplementedException();
        }

        List<UserDTO> IUserEngine.List()
        {
            throw new NotImplementedException();
        }

        void IUserEngine.update(UserDTO user)
        {
            throw new NotImplementedException();
        }
    }
}
