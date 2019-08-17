using CarRental.BLL;
using CarRental.Model;
using CarRental.UI.ViewsModels.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CarRental.UI.Controllers
{
    public class CarController : Controller
    {
        private readonly CarLogic carLogic;
        private readonly CarModelLogic carModelLogic;
        private readonly CarMakeLogic carMakeLogic;
        private readonly BookingLogic bookingLogic;
        private readonly RequestBookingLogic requestBookingLogic;
        private readonly EventLogic eventLogic;

        public CarController()
        {
            carLogic = new CarLogic();
            carModelLogic = new CarModelLogic();
            carMakeLogic = new CarMakeLogic();
            bookingLogic = new BookingLogic();
            requestBookingLogic = new RequestBookingLogic();
            eventLogic = new EventLogic();
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

        public ActionResult _ListCars(string licencePlate)
        {
            List<CarDTO> _cars = new List<CarDTO>();

            if (string.IsNullOrWhiteSpace(licencePlate))
            {
                _cars = carLogic.List();
            }
            else
            {
                _cars = carLogic.List(licencePlate);
            }

            List<Tuple<CarDTO, CarModelDTO, CarMakeDTO>> cars = new List<Tuple<CarDTO, CarModelDTO, CarMakeDTO>>();


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
            List<EventDTO> events = eventLogic.List(licencePlate);


            CarDetailViewsModel vm = new CarDetailViewsModel
            {
                car = car,
                carModel = carModel,
                carMake = carMake,
                events = events
            };

            return View(vm);
        }

        

        public ActionResult GetCalendarData(string start, string end, string licencePlate)
        {
            List<EventDTO> events = eventLogic.List(licencePlate);
            List<BookingDTO> bookings = bookingLogic.List(licencePlate);

            List<FullCalendarDTO> fullCalendars = new List<FullCalendarDTO>();

            foreach (EventDTO @event in events)
            {
                fullCalendars.Add(new FullCalendarDTO { Id = @event.Id, Libelle = @event.Libelle, Start = @event.Start_Date.ToString("yyyy-MM-dd"), End = @event.End_Date.ToString("yyyy-MM-dd") });
            }

            foreach (BookingDTO booking in bookings)
            {
                RequestBookingDTO requestBooking = requestBookingLogic.Get(booking.Id);

                fullCalendars.Add(new FullCalendarDTO { Id = booking.Id, Libelle = requestBooking.Reason });
            }

            return Json(fullCalendars.Select(e => new { id = e.Id, title = e.Libelle, start = e.Start, end = e.End }), JsonRequestBehavior.AllowGet);
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