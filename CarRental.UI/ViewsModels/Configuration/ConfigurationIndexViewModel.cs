using CarRental.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRental.UI.ViewsModels.Configuration
{
    public class ConfigurationIndexViewModel
    {
       
       public List<Tuple<RoleDTO, List<ActionDTO>>> ListRoleWithActionTuple {get; set;}

    }
}