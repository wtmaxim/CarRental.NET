using CarRental.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarRental.UI.ViewsModels.Car
{
    public class CarIndexViewsModel
    {
        public CarDTO Car { get; set; }

        public int SelectedCarsMakeId { get; set; }
        public IEnumerable<SelectListItem> CarsMakes { get; set; }

        public int SelectedCarsModelsId { get; set; }
        public IEnumerable<SelectListItem> CarsModels { get; set; }

        public IEnumerable<SelectListItem> Companys { get; set; }
        public int CompanyId { get; set; }

    }
}