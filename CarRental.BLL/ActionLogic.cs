using CarRental.DAL;
using CarRental.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.BLL
{
    public class ActionLogic
    {
        private readonly ActionEngine actionEngine;
        public ActionLogic()
        {
            actionEngine = new ActionEngine();
        }
        public List<ActionDTO> get_User_Actions(string email)
        {
            try
            {
                return actionEngine.Get_User_Actions(email);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string[] Convert_List_Action_To_String_Array(List<ActionDTO> actions)
        {
            List<string> array = new List<string>();
            foreach (ActionDTO action in actions)
            {
                array.Add(action.Libelle);
            }
            return array.ToArray();
        }
    }
}
