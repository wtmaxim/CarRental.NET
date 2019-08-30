using CarRental.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRental.UI.ViewsModels.User
{
    public class UserIndexViewsModel
    {
        // public List<UserDTO> Users { get; set; }
        public List<Tuple<UserDTO, CompanyDTO, RoleDTO>> Users { get; set; }
        public List<CompanyDTO> Companies { get; set; }
        public List<RoleDTO> Roles { get; set; }
    }
}