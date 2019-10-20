using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Model;
using CarRental.DAL;
using CarRental.Common;

namespace CarRental.BLL
{
    public class UtilisateurLogic
    {
        private readonly IUtilisateurEngine utilisateurEngine;
        public UtilisateurLogic()
        {
            utilisateurEngine = new UtilisateurEngine();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mail"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public UserDTO GetUserByMailAndPassword(string mail, string password)
        {
            return utilisateurEngine.GetByMailAndPassword(mail, password);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mail"></param>
        /// <returns></returns>
        public UserDTO GetUserByMail(string mail)
        {
            return utilisateurEngine.GetByMail(mail);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UserDTO Get(int id)
        {
            return utilisateurEngine.Get(id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userDTO"></param>
        public void UpdatePasswordByMail(UserDTO userDTO)
        {
            if (userDTO.Password == userDTO.confirmPassword)
            {
                utilisateurEngine.UpdatePasswordByMail(SecurePasswordHasherHelper.Hash(userDTO.Password), userDTO.Email);
            }

        }

        public List<UserDTO> ListDrivers(int idBooking)
        {
            return utilisateurEngine.ListDrivers(idBooking);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<UserDTO> ListAll()
        {
            return utilisateurEngine.ListAll();
        }

        public List<UserDTO> ListPassagers(int idBooking)
        {
            return utilisateurEngine.ListPassagers(idBooking);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<UserDTO> ListActive()
        {
            return utilisateurEngine.ListActive();
        }

        public UserDTO GetDriver(int idBooking, byte isGoing)
        {
            return utilisateurEngine.GetDriverByBooking(idBooking, isGoing);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<UserDTO> ListUnactive()
        {
            return utilisateurEngine.ListUnactive();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public List<UserDTO> Search(string value)
        {
            return utilisateurEngine.Search(value);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        public void AddUser(UserDTO user)
        {
            utilisateurEngine.Insert(user);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        public void InsertOrUpdateUser(UserDTO user)
        {
            utilisateurEngine.InsertOrUpdate(user);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void Archive(int id)
        {
            utilisateurEngine.Archive(id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void Unarchive(int id)
        {
            utilisateurEngine.Archive(id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        public void Update(UserDTO user)
        {
            utilisateurEngine.Update(user);
        }
    }
}
