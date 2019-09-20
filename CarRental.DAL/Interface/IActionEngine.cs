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
        /// <returns>Retourne les Actions d'un utilisateur à partir de son email.</returns>
        List<ActionDTO> Get_User_Actions(string email);
    }
}
