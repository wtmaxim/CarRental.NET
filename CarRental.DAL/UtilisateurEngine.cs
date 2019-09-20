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

        UserDTO IUtilisateurEngine.Get(int id)
        {
            using (CarRentalEntities contexte = new CarRentalEntities())
            {
                return UserMapping.MapToUserDto(contexte.usp_User_GET(id).FirstOrDefault());
            }
            throw new NotImplementedException();

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

        UserDTO IUtilisateurEngine.GetByMailAndPassword(string email, string password)
        {
            using (CarRentalEntities contexte = new CarRentalEntities())
            {
                try
                {
                    return UserMapping.MapToUserDto(contexte.usp_User_Get_By_Email_And_Password(email, password).FirstOrDefault());
                }
                catch (Exception e)
                {

                    throw e;
                }

            }

        }

        List<UserDTO> IUtilisateurEngine.ListAll()
        {
            using (CarRentalEntities contexte = new CarRentalEntities())
            {
                return UserMapping.MapToListUserDTO(contexte.usp_User_List_All().ToList<User>());
            }

        }

        List<UserDTO> IUtilisateurEngine.ListActive()
        {
            using (CarRentalEntities contexte = new CarRentalEntities())
            {
                return UserMapping.MapToListUserDTO(contexte.usp_User_List_Active().ToList<User>());
            }

        }

        List<UserDTO> IUtilisateurEngine.ListUnactive()
        {
            using (CarRentalEntities contexte = new CarRentalEntities())
            {
                return UserMapping.MapToListUserDTO(contexte.usp_User_List_Unactive().ToList<User>());
            }

        }

        void IUtilisateurEngine.UpdatePasswordByMail(string password, string mail)
        {
            using (CarRentalEntities contexte = new CarRentalEntities())
            {
                contexte.usp_User_Update_Password(password, mail);
            }

        }

        public List<UserDTO> Search(string value)
        {
            using (CarRentalEntities context = new CarRentalEntities())
            {
                var users = context.usp_User_Get_Fistname_Lastname_Email(value).ToList();
                return UserMapping.MapToListUserDTO(users);
            }
        }

        public void Insert(UserDTO user)
        {
            /**
            using (CarRentalEntities context = new CarRentalEntities())
            {
                context.usp_User_Insert(user.Firstname, user.Lastname, user.Email, user.Password,
                    user.Is_Active, user.Job, user.Note, user.Phone_Number, user.Is_Address_Private, user.Id_Company, user.Id_Company);
            }
            */
        }

        public void InsertOrUpdate(UserDTO user)
        {
            /**
            using (CarRentalEntities context = new CarRentalEntities())
            {
                context.usp_User_Insert_Or_Update(user.Firstname, user.Lastname, user.Email, user.Password,
                    user.Is_Active, user.Job, user.Note, user.Phone_Number, user.Is_Address_Private, user.Id_Company, user.Id_Company);
            }*/
        }

        public void Archive(int id)
        {
            using (CarRentalEntities context = new CarRentalEntities())
            {
                context.usp_User_Archive(id);
            }
        }

        public void Unarchive(int id)
        {
            using (CarRentalEntities context = new CarRentalEntities())
            {
                context.usp_User_Unarchive(id);
            }
        }

        public void Update(UserDTO user)
        {
            /**
            using (CarRentalEntities context = new CarRentalEntities())
            {
                context.usp_User_Update(user.Id, user.Firstname, user.Lastname, user.Email, user.Password, user.Is_Active, 
                    user.Job, user.Note, user.Phone_Number, user.Is_Address_Private, user.Id_Company);
            }
            */
        }
    }
}
