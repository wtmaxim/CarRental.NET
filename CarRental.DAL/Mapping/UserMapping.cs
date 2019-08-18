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
            if(user != null)
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
            else
            {
                return null;
            }

        }

        public List<UserDTO> MapToListUserDTO(List<User> users)
        {
            return (from User user in users
                    let newUser = new UserDTO
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
                    }
                    select newUser).ToList();
        }
    }
}
