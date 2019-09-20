using CarRental.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;


namespace CarRental.DAL.Mapping
{
    public class RoleMapping
    {
        public RoleDTO MapToRoleDTO(Role role)
        {
            if (role != null)
            {
                return new RoleDTO
                {
                    Id = role.Id,
                    Libelle = role.Libelle
                };
            }
            else
                return null;
        }


        internal List<RoleDTO> MapToListRoleDTO(ObjectResult<usp_User_GET_List_Roles_Result> objectResult)
        {
            return (from usp_User_GET_List_Roles_Result r in objectResult.ToList()
                    let role = new RoleDTO
                    {
                        Id = r.Id,
                        Libelle = r.Libelle,
                    }
                    select role).ToList();
        }

        internal List<RoleDTO> MapToListRoleDTO(List<Role> list)
        {
            return (from Role r in list
                    let role = new RoleDTO
                    {
                        Id = r.Id,
                        Libelle = r.Libelle
                    }
                    select role).ToList();
        }
    }
}
