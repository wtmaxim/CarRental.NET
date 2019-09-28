using CarRental.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRental.UI.ViewsModels.Utilisateur
{
    public class UtilisateurIndexViewModel
    {
        public List<Tuple<UserDTO, CompanyDTO, List<RoleDTO>>> Users { get; set; }
        public List<CompanyDTO> Companies { get; set; }
        public List<RoleDTO> Roles { get; set; }
        public Tuple<UserDTO, CompanyDTO, List<RoleDTO>> UserToEdit { get; set; }
        public int? FilterUserByCompanyId { get; set; }
        public int? FilterUserByActiveVal { get; set; } // 0 non actif, 1 actif, 2 tous

        public UtilisateurIndexViewModel()
        {
            UserToEdit = null;
            FilterUserByCompanyId = null;
            FilterUserByActiveVal = 1;

        }
    }
}