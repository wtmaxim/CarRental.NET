using CarRental.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRental.UI.ViewsModels.Role
{
    public class RoleEditViewModel
    {
        public Tuple<RoleDTO, List<ActionDTO>> RoleWithActionTuple { get; set; }
        public List<ActionDTO> allActions { get; set; }
    }
}