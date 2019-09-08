using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Model;

namespace CarRental.DAL
{
    public class RoleEngine : IRoleEngine
    {
        private readonly RoleMapping roleMapping;

        public RoleEngine()
        {
            roleMapping = new RoleMapping();
        }

        List<RoleDTO> IRoleEngine.List()
        {
            using (CarRentalEntities context = new CarRentalEntities())
            {
                var roles = context.usp_Role_List().ToList();
                return roleMapping.MapToListRoleDTO(roles);
            }
        }
    }
}
