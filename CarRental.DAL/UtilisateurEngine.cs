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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        UserDTO IUtilisateurEngine.Get(int id)
        {
            using (CarRentalEntities contexte = new CarRentalEntities())
            {
                return UserMapping.MapToUserDto(contexte.usp_User_GET(id).FirstOrDefault());
            }
            throw new NotImplementedException();

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<UserDTO> IUtilisateurEngine.ListAll()
        {
            using (CarRentalEntities contexte = new CarRentalEntities())
            {
                return UserMapping.MapToListUserDTO(contexte.usp_User_List_All().ToList<User>());
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<UserDTO> IUtilisateurEngine.ListActive()
        {
            using (CarRentalEntities contexte = new CarRentalEntities())
            {
                return UserMapping.MapToListUserDTO(contexte.usp_User_List_Active().ToList<User>());
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<UserDTO> IUtilisateurEngine.ListUnactive()
        {
            using (CarRentalEntities contexte = new CarRentalEntities())
            {
                return UserMapping.MapToListUserDTO(contexte.usp_User_List_Unactive().ToList<User>());
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="password"></param>
        /// <param name="mail"></param>
        void IUtilisateurEngine.UpdatePasswordByMail(string password, string mail)
        {
            using (CarRentalEntities contexte = new CarRentalEntities())
            {
                contexte.usp_User_Update_Password(password, mail);
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public List<UserDTO> Search(string value)
        {
            using (CarRentalEntities context = new CarRentalEntities())
            {
                var users = context.usp_User_Get_Fistname_Lastname_Email(value).ToList();
                return UserMapping.MapToListUserDTO(users);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        public void Insert(UserDTO user)
        {
            
            using (CarRentalEntities context = new CarRentalEntities())
            {
                context.usp_User_Insert(user.Firstname, user.Lastname, user.Email, user.Password,
                    user.Is_Active, user.Job, user.Note, user.Phone_Number, user.Is_Address_Private, user.Id_Company);
            }
           
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        public void InsertOrUpdate(UserDTO user)
        {
            
            using (CarRentalEntities context = new CarRentalEntities())
            {
                context.usp_User_Insert_Or_Update(user.Firstname, user.Lastname, user.Email, user.Password,
                    user.Is_Active, user.Job, user.Note, user.Phone_Number, user.Is_Address_Private, user.Id_Company);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void Archive(int id)
        {
            using (CarRentalEntities context = new CarRentalEntities())
            {
                context.usp_User_Archive(id);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void Unarchive(int id)
        {
            using (CarRentalEntities context = new CarRentalEntities())
            {
                context.usp_User_Unarchive(id);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
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

        public List<UserDTO> ListDrivers(int idBooking)
        {
            using (CarRentalEntities context = new CarRentalEntities())
            {
                List<User> users = context.usp_User_ListDrivers(idBooking).ToList();
                return UserMapping.MapToListUserDTO(users);
            }
        }

        public List<UserDTO> ListPassagers(int idBooking)
        {
            using (CarRentalEntities context = new CarRentalEntities())
            {
                List<User> users = context.usp_User_ListPassagers(idBooking).ToList();
                return UserMapping.MapToListUserDTO(users);
            }
        }

        public UserDTO GetDriverByBooking(int idBooking, byte isGoing)
        {
            using (CarRentalEntities context = new CarRentalEntities())
            {
                User user = context.usp_User_GetDriver(idBooking, isGoing).FirstOrDefault();
                return UserMapping.MapToUserDto(user);
            }
        }
    }
}
