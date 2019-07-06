using CarRental.BLL;
using CarRental.Model;
using CarRental.UI.ViewsModels.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarRental.UI.Controllers
{
    public class CarController : Controller
    {
        private readonly CarLogic carLogic;

        public CarController()
        {
            carLogic = new CarLogic();
        }

        // GET: Voiture
        public ActionResult Index()
        {
            List<CarDTO> cars = carLogic.List();

            CarIndexViewsModel vm = new CarIndexViewsModel
            {
                cars = cars
            };

            return View(vm);
        }

        [HttpPost]
        public ActionResult AddCar(CarDTO car)
        {
            car.Energy_Value = 1;
            car.is_Available = 1;
            car.is_Active = 1;
            car.id_Car_Model = 1;
            car.Id_Company = 2;
            car.Id_User = 1;
            carLogic.AddCar(car);

            string message = "SUCCESS";

            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }

        public JsonResult ListCars()
        {
            List<CarDTO> cars = new List<CarDTO>();

            cars = carLogic.List();

            return Json(cars, JsonRequestBehavior.AllowGet);
        }
    }
}