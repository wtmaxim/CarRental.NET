using CarRental.DAL;
using CarRental.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.BLL
{
    public class RoleLogic
    {
        private readonly IRoleEngine roleEngine;

        public RoleLogic()
        {
            roleEngine = new RoleEngine();
        }

        public List<RoleDTO> List()
        {
            return roleEngine.List();
        }

    }
}
