using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Model;

namespace CarRental.DAL
{
    public class UtilisateurEngine : IUtilisateurEngine
    {
        private readonly UserMapping userMapping;

        public UtilisateurEngine()
        {
            userMapping = new UserMapping();
        }
        
        public UserDTO Get(int id)
        {
            using (CarRentalEntities context = new CarRentalEntities())
            {
                User user = context.usp_User_Get_Id(id).FirstOrDefault();
                return userMapping.MapToUserDTO(user);
            }
        }

        public void Insert(UserDTO user)
        {
            using (CarRentalEntities context = new CarRentalEntities())
            {
                context.usp_User_Insert(user.Firstname, user.Lastname, user.Email, user.Password,
                    user.Is_Active, user.Job, user.Note, user.Phone_Number, user.Is_Address_Private, user.Id_Company, user.Id_Company);
            }
        }

        public List<UserDTO> List()
        {
            using (CarRentalEntities context = new CarRentalEntities())
            {
                var users = context.usp_User_List().ToList();
                return userMapping.MapToListUserDTO(users);
            }
        }

        public List<UserDTO> Search(string value)
        {
            using (CarRentalEntities context = new CarRentalEntities())
            {
                var users = context.usp_User_Get_Fistname_Lastname_Email(value).ToList();
                return userMapping.MapToListUserDTO(users);
            }
        }

        public void Archive(int id)
        {
            using (CarRentalEntities context = new CarRentalEntities())
            {
                context.usp_User_Archive(id);
            }
        }

        UserDTO IUtilisateurEngine.GetByMail(string email)
        {
            using (CarRentalEntities contexte = new CarRentalEntities())
            {
                try
                {
                    return UserMapping.MapToUserDto(contexte.usp_User_GET_By_EMail(email).FirstOrDefault());
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
    }
}
