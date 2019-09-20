using CarRental.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRental.UI.ViewsModels.Profile
{
    public class ProfileIndexViewModel
    {
        public Tuple<UserDTO, CompanyDTO, RoleDTO> CurrentUser { get; set; }
    }
}