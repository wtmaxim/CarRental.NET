using CarRental.DAL;
using CarRental.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.BLL
{
    public class UserLogic
    {
        private readonly IUtilisateurEngine userEngine;

        public UserLogic()
        {
            userEngine = new UtilisateurEngine();
        }

        public void AddUser(UserDTO user)
        {
            userEngine.Insert(user);
        }

        public List<UserDTO> List()
        {
            return userEngine.List();
        }

        public UserDTO Get(int id)
        {
            return userEngine.Get(id);
        }

        public List<UserDTO> Search(string value)
        {
            return userEngine.Search(value);
        }
        public void Archive(int id)
        {
            userEngine.Archive(id);
        }



    }
}
