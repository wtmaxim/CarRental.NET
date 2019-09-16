using System.Collections.Generic;
using CarRental.Model;

namespace CarRental.DAL
{
    public interface IUtilisateurEngine
    {
        UserDTO GetByMail(string email);
        List<UserDTO> ListAll();
        List<UserDTO> ListActive();
        List<UserDTO> ListUnactive();
        void UpdatePasswordByMail(string password, string mail);
        UserDTO GetByMailAndPassword(string email, string passowrd);
        UserDTO Get(int id);
        List<UserDTO> Search(string value);
        void Insert(UserDTO user);
        void InsertOrUpdate(UserDTO user);
        void Archive(int userId);
        void Unarchive(int id);
        void Update(UserDTO user);
    }
}
