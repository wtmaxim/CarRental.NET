using CarRental.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.DAL.Mapping
{
    class UserMapping
    {
        public UserDTO MapToUserDto(User user)
        {
            return new UserDTO
            {
                Lastname = user.Lastname,
                Password = user.Password,
                Firstname = user.Firstname,
                Is_Active = user.is_Active,
                Job = user.Job,
                Note = user.Note,
                Email = user.Email,
                Id_Company = user.Id_Company,
                Phone_Number = user.Phone_Number,
                Id = user.Id,
                Is_Address_Private = user.is_Address_Private

            };
        }

        public List<UserDTO> MapToListUserDTO(List<User> users)
        {
            List <UserDTO> retour = new List<UserDTO>();

            foreach ( User user in users)
            {
                UserDTO newUser = new UserDTO
                {
                    Lastname = user.Lastname,
                    Password = user.Password,
                    Firstname = user.Firstname,
                    Is_Active = user.is_Active,
                    Job = user.Job,
                    Note = user.Note,
                    Email = user.Email,
                    Id_Company = user.Id_Company,
                    Phone_Number = user.Phone_Number,
                    Id = user.Id,
                    Is_Address_Private = user.is_Address_Private
                };
                retour.Add(newUser);
            }

            return retour;
        }
    }
}
