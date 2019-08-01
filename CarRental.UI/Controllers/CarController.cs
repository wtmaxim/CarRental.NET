using CarRental.BLL;
using CarRental.Model;
using CarRental.UI.ViewsModels.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace CarRental.UI.Controllers
{
    public class CarController : Controller
    {
        private readonly CarLogic carLogic;
        private readonly CarModelLogic carModelLogic;
        private readonly CarMakeLogic carMakeLogic;
        private readonly BookingLogic bookingLogic;

        public CarController()
        {
            carLogic = new CarLogic();
            carModelLogic = new CarModelLogic();
            carMakeLogic = new CarMakeLogic();
            bookingLogic = new BookingLogic();
        }

        // GET: Voiture
        public ActionResult Index()
        {
            CarIndexViewsModel vm = new CarIndexViewsModel
            {
                CarsMakes = GetCarsMakes()
            };

            return View(vm);
        }

        public ActionResult SearchCar(string searchWord)
        {

            var po = 2;
            return null;
        }

        [ChildActionOnly]
        public ActionResult _ListCars()
        {
            List<Tuple<CarDTO, CarModelDTO, CarMakeDTO>> cars = new List<Tuple<CarDTO, CarModelDTO, CarMakeDTO>>();

            List<CarDTO> _cars = carLogic.List();

            foreach (CarDTO car in _cars)
            {
                CarModelDTO carModel = carModelLogic.Get(car.id_Car_Model);
                CarMakeDTO carMake = carMakeLogic.Get(carModel.id_Car_Make);

                cars.Add(new Tuple<CarDTO, CarModelDTO, CarMakeDTO>(car, carModel, carMake));
            }

            CarIndexListCarViewsModel vm = new CarIndexListCarViewsModel
            {
                Cars = cars
            };

            return PartialView(vm);
        }

        public ActionResult GetCarsModels(int idMake)
        {
            List<CarModelDTO> carsModels = carModelLogic.List(idMake);

            if (HttpContext.Request.IsAjaxRequest())
                return Json(new SelectList(carsModels, "Id", "Model"), JsonRequestBehavior.AllowGet);

            return View(carsModels);
        }

        private IEnumerable<SelectListItem> GetCarsMakes()
        {
            List<CarMakeDTO> dbCarsMakes= carMakeLogic.List();

            var carsMakes = dbCarsMakes.Select(x => new SelectListItem
            {
                Value = x.id.ToString(),
                Text = x.Make
            });

            return new SelectList(carsMakes, "Value", "Text");
        }

        public ActionResult Detail(string licencePlate)
        {
            CarDTO car = carLogic.Get(licencePlate);
            CarModelDTO carModel = carModelLogic.Get(car.id_Car_Model);
            CarMakeDTO carMake = carMakeLogic.Get(carModel.id_Car_Make);
            List<BookingDTO> bookings = bookingLogic.List(car.Licence_Plate);
            

            CarDetailViewsModel vm = new CarDetailViewsModel
            {
                car = car,
                carModel = carModel,
                carMake = carMake
            };

            return View(vm);
        }

        
        [HttpPost]
        public ActionResult AddCar(CarDTO car)
        {
            car.Energy_Value = 1;
            car.is_Available = 1;
            car.is_Active = 1;
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