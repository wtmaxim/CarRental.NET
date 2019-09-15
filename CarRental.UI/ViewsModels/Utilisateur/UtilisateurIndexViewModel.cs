using CarRental.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRental.UI.ViewsModels.Utilisateur
{
    public class UtilisateurIndexViewModel
    {
        public List<Tuple<UserDTO, CompanyDTO, RoleDTO>> Users { get; set; }
        public List<CompanyDTO> Companies { get; set; }
        public List<RoleDTO> Roles { get; set; }
        public Tuple<UserDTO, CompanyDTO, RoleDTO> UserToEdit { get; set;  }
    }
}