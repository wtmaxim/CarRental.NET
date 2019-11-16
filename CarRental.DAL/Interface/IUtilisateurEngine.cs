using System.Collections.Generic;
using CarRental.Model;

namespace CarRental.DAL
{
    public interface IUtilisateurEngine
    {
        /// <summary>
        /// Récupère un utilisateur selon son addresse email.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        UserDTO GetByMail(string email);
        /// <summary>
        /// Récupère la liste de tout les utilisateurs.
        /// </summary>
        /// <returns></returns>
        List<UserDTO> ListAll();
        /// <summary>
        /// Récupère la liste des utilisateurs actifs.
        /// </summary>
        /// <returns></returns>
        List<UserDTO> ListActive();
        /// <summary>
        /// Récupère la liste des utilisateurs inactifs.
        /// </summary>
        /// <returns></returns>
        List<UserDTO> ListUnactive();
        /// <summary>
        /// Met à jour le mot de passe de l'utilisateur dont le mail est spécifié
        /// </summary>
        /// <param name="password"></param>
        /// <param name="mail"></param>
        void UpdatePasswordByMail(string password, string mail);
        /// <summary>
        /// Récupère un utilisateur selon son mail et son mot de passe.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="passowrd"></param>
        /// <returns></returns>
        UserDTO GetByMailAndPassword(string email, string passowrd);
        /// <summary>
        /// Récupère un utilisateur selon son id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        UserDTO Get(int id);
        List<UserDTO> ListDrivers(int idBooking);

        /// <summary>
        /// Recherche un utilisateur.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        List<UserDTO> Search(string value);
        /// <summary>
        /// Ajoute un nouvel utilisateur.
        /// </summary>
        /// <param name="user"></param>
        void Insert(UserDTO user);
        List<UserDTO> ListPassagers(int idBooking);

        /// <summary>
        /// Ajout ou met à jour un utilisateur
        /// </summary>
        /// <param name="user"></param>
        void InsertOrUpdate(UserDTO user);
        /// <summary>
        /// Désactive le compte d'un utilisateur
        /// </summary>
        /// <param name="userId"></param>
        void Archive(int userId);
        UserDTO GetDriverByBooking(int idBooking, byte isGoing);

        /// <summary>
        /// Réactive le compte d'un utilisateur
        /// </summary>
        /// <param name="id"></param>
        void Unarchive(int id);
        /// <summary>
        /// Met a jour un utilisateur.
        /// </summary>
        /// <param name="user"></param>
        void Update(UserDTO user);
        /// <summary>
        /// Supprimes tout les roles d'un utilisateur selon son id;
        /// </summary>
        /// <param name="id"></param>
        void RemoveAllRoles(int id);
    }
}
