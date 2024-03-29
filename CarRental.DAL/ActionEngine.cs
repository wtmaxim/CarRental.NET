﻿using CarRental.DAL.Interface;
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

        public ActionDTO Get_By_iD(int id)
        {
            try
            {
                using (CarRentalEntities context = new CarRentalEntities())
                {
                    return actionMapping.MapToActionDTO(context.usp_Action_Get_By_Id(id).FirstOrDefault());
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Retourne la liste d'actions d'un role
        /// </summary>
        /// <param name="idRole"></param>
        /// <returns></returns>
        public List<ActionDTO> Get_Role_Actions(int idRole)
        {
            try
            {
                using(CarRentalEntities context = new CarRentalEntities())
                {
                    return actionMapping.MapToListActionDTO(context.usp_Action_List_By_Role(idRole).ToList());
                }
            }
            catch (Exception)
            {

                throw;
            }
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

        public List<ActionDTO> List()
        {
            try
            {
                using (CarRentalEntities context = new CarRentalEntities())
                {
                    return actionMapping.MapToListActionDTO(context.usp_Action_List().ToList());
                }
                

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
