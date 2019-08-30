using CarRental.DAL;
using CarRental.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.BLL
{
    public class CompanyLogic
    {
        private readonly ICompanyEngine companyEngine;

        public CompanyLogic()
        {
            companyEngine = new CompanyEngine();
        }

        public List<CompanyDTO> List()
        {
            return companyEngine.List();
        }

    }
}
