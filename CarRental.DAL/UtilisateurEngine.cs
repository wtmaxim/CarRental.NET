using System;
using System.Collections.Generic;
using System.Linq;
using CarRental.DAL.Mapping;
using CarRental.Model;

namespace CarRental.DAL
{
    public class UtilisateurEngine : IUtilisateurEngine
    {
        private readonly UserMapping UserMapping;
       
        public UtilisateurEngine()
        {
            UserMapping = new UserMapping();
           
        }
        UserDTO IUtilisateurEngine.GetByMail(string email)
        {
            using (CarRentalEntities contexte = new CarRentalEntities())
            {
               return UserMapping.MapToUserDto(contexte.usp_User_GET(email).FirstOrDefault());
            }
        }

        UserDTO IUtilisateurEngine.GetByMailAndPassword(string email, string password)
        {
            using (CarRentalEntities contexte = new CarRentalEntities())
            {
              return UserMapping.MapToUserDto(contexte.usp_User_Get_By_Email_And_Password(email, password).FirstOrDefault());
            }
            
        }

        List<UserDTO> IUtilisateurEngine.List()
        {
            using (CarRentalEntities contexte = new CarRentalEntities())
            {
                return UserMapping.MapToListUserDTO(contexte.Usp_User_List().ToList<User>());
            }
               
        }

        void IUtilisateurEngine.Update(UserDTO user)
        {
            // TODO Créer la procédure pour terminer la méthode
            throw new NotImplementedException();
        }
    }
}
