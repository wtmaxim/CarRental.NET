using CarRental.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.DAL.Interface
{
    public interface IActionEngine
    {
        /// <summary>
        /// Retourne les Actions d'un utilisateur à partir de son email.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        List<ActionDTO> Get_User_Actions(string email);
        /// <summary>
        /// Retourne la liste des action selon l'id du role.
        /// </summary>
        /// <param name="idRole"></param>
        /// <returns></returns>
        List<ActionDTO> Get_Role_Actions(int idRole);
        /// <summary>
        /// Retourne la liste des actions de l'application.
        /// </summary>
        /// <returns></returns>
        List<ActionDTO> List();
    }
}
