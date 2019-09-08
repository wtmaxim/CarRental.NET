using CarRental.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.DAL
{
    public class CompanyEngine : ICompanyEngine
    {
        private readonly CompanyMapping companyMapping;

        public CompanyEngine()
        {
            companyMapping = new CompanyMapping();
        }
        public List<CompanyDTO> List()
        {
            using (CarRentalEntities context = new CarRentalEntities())
            {
                var companies = context.usp_Company_List().ToList();
                return companyMapping.MapToListCompanyDTO(companies);
            }
        }
    }
}
