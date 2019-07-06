using CarRental.Model;
using System.Collections.Generic;
using System.Linq;

namespace CarRental.DAL
{
    public class UserMapping
    {
        private CarMapping carMapping;


        public UserMapping()
        {
            carMapping = new CarMapping();
        }

        public UserDTO MapToUserDTO(User user)
        {
            return new UserDTO
            {
                Car = carMapping.MapToListCarDTO(user.Car.ToList()),
                Company = user.Company,
                Job = user.Job,
                Email = user.Email,
                Firstname = user.Firstname,
                Id = user.Id,
                Is_Active = user.is_Active,
                Is_Address_Private = user.is_Address_Private,
                Lastname = user.Lastname,
                Note = user.Note,
                Password = user.Password,
                Phone_Number = user.Phone_Number,
                Role = user.Role,
                UserBooking = user.UserBooking,
                user_address = user.user_address
            };
        }

        public List<UserDTO> MapToListUserDTO(List<User> users)
        {
            List<UserDTO> retour = new List<UserDTO>();

            foreach (User car in users)
            {
                UserDTO newUser = new UserDTO
                {
                    Car = user.Car,
                    Company = user.Company,
                    Job = user.Job,
                    Email = user.Email,
                    Firstname = user.Firstname,
                    Id = user.Id,
                    Is_Active = user.is_Active,
                    Is_Address_Private = user.is_Address_Private,
                    Lastname = user.Lastname,
                    Note = user.Note,
                    Password = user.Password,
                    Phone_Number = user.Phone_Number,
                    Role = user.Role,
                    UserBooking = user.UserBooking,
                    user_address = user.user_address
                };

                retour.Add(newUser);
            }

            return retour;
        }
    }
}