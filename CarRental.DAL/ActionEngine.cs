using CarRental.DAL.Interface;
using CarRental.DAL.Mapping;
using CarRental.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.DAL
{
    public class ActionEngine : IActionEngine
    {
        private readonly ActionMapping actionMapping;
        public ActionEngine()
        {
            actionMapping = new ActionMapping();
        }
        /// <summary>
        /// Retourne les Actions d'un utilisateur à partir de son email.
        /// </summary>
        /// <param name="email"></param>
        /// <returns>Retourne les Actions d'un utilisateur à partir de son email.</returns>
        public List<ActionDTO> Get_User_Actions(string email)
        {
            using (CarRentalEntities context = new CarRentalEntities())
            {
                try
                {
                    return actionMapping.MapToListActionDTO(context.usp_Action_List_By_User(email).ToList());
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}
