using CarRental.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.DAL
{
    public class CompanyMapping
    {
        private AddressMapping addressMapping;

        public CompanyMapping()
        {
            addressMapping = new AddressMapping();
        }

        public CompanyDTO MapToCompanyDTO(Company company)
        {
            return new CompanyDTO
            {
                Id = company.Id,
                Name = company.Name,
                // Address = addressMapping.MapToAddressDTO(company.Address)
            };
        }

        public List<CompanyDTO> MapToListCompanyDTO(List<Company> companies)
        {
            List<CompanyDTO> retour = new List<CompanyDTO>();
            foreach (Company company in companies)
            {
                CompanyDTO newCompany = new CompanyDTO
                {
                    Id = company.Id,
                    Name = company.Name,
                    // Address = addressMapping.MapToAddressDTO(company.Address)
                };

                retour.Add(newCompany);
            }
            return retour;
        }
    }
}
