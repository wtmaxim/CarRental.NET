using CarRental.Model;
using System.Collections.Generic;
using System.Linq;

namespace CarRental.DAL
{
    public class UserMapping
    {
        private CarMapping carMapping;
        private CompanyMapping companyMapping;
        private AddressMapping addressMapping;
        private RoleMapping roleMapping;

        public UserMapping()
        {
            carMapping = new CarMapping();
            companyMapping = new CompanyMapping();
            addressMapping = new AddressMapping();
            roleMapping = new RoleMapping();
        }

        public UserDTO MapToUserDTO(User user)
        {
            return new UserDTO
            {
                Car = carMapping.MapToListCarDTO(user.Car.ToList()),
                // Company = companyMapping.MapToCompanyDTO(user.Company),
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
                // Role = user.Role,
                Id_Company = user.Id_Company,
                Id_Role = user.Id_Role
                // UserBooking = user.UserBooking,
                // user_address = addressMapping.MapToAddressDTO(user.user_address)
            };
        }

        public List<UserDTO> MapToListUserDTO(List<User> users)
        {
            List<UserDTO> retour = new List<UserDTO>();

            foreach (User user in users)
            {
                UserDTO newUser = new UserDTO
                {
                    // Car = user.Car,
                    // Company = companyMapping.MapToCompanyDTO(user.Company),
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
                    // Role = roleMapping.MapToListRoleDTO(user.Role),
                    Id_Company = user.Id_Company,
                    Id_Role = user.Id_Role
                    // UserBooking = user.UserBooking,
                    // user_address = user.user_address
                };

                retour.Add(newUser);
            }

            return retour;
        }
    }
}