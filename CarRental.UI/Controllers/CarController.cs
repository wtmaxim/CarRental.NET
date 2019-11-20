using CarRental.BLL;
using CarRental.Model;
using CarRental.UI.ViewsModels.Car;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
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
        private readonly AdressLogic addressLogic;
        private readonly UtilisateurLogic utilisateurLogic;
        private readonly StatusLogic statusLogic;
        private readonly StopOverLogic stopOverLogic;
        private readonly StopOverAddressLogic stopOverAddressLogic;
        private readonly CompanyLogic companyLogic;

        public CarController()
        {
            companyLogic = new CompanyLogic();
            carLogic = new CarLogic();
            carModelLogic = new CarModelLogic();
            carMakeLogic = new CarMakeLogic();
            bookingLogic = new BookingLogic();
            requestBookingLogic = new RequestBookingLogic();
            eventLogic = new EventLogic();
            addressLogic = new AdressLogic();
            utilisateurLogic = new UtilisateurLogic();
            statusLogic = new StatusLogic();
            stopOverLogic = new StopOverLogic();
            stopOverAddressLogic = new StopOverAddressLogic();
        }

        // GET: Voiture
        public ActionResult Index()
        {
            CarIndexViewsModel vm = new CarIndexViewsModel
            {
                CarsMakes = GetCarsMakes(),
                Companys = GetCompanys()
            };

            return View(vm);
        }

        public ActionResult SearchCar(string searchWord)
        {

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

        private IEnumerable<SelectListItem> GetAddresses()
        {
            List<AddressDTO> addresses = addressLogic.List();

            var addressesList = addresses.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            });

            return new SelectList(addressesList, "Value", "Text");
        }
        private IEnumerable<SelectListItem> GetCompanys()
        {
            List<CompanyDTO> companys = companyLogic.List();

            var companyList = companys.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            });

            return new SelectList(companyList, "Value", "Text");
        }

        [HttpGet]
        public ActionResult RendreCar(int idBooking)
        {
            CarRendreCarViewsModel vm = new CarRendreCarViewsModel();

            BookingDTO booking = bookingLogic.Get(idBooking);
            RequestBookingDTO requestBooking = requestBookingLogic.GetByRequestBooking(booking.id_Request_Booking);
            StopOverDTO stopOver = stopOverLogic.GetByBooking(booking.Id);
            List<UserDTO> passagers = utilisateurLogic.ListPassagers(booking.Id);
            StatusDTO status = statusLogic.GetStatus(requestBooking.Id_Status);
            StopOverAddressDTO stopOverAddress = stopOverAddressLogic.GetStopOverAddress(stopOver.Id);
            UserDTO driverAller = utilisateurLogic.GetDriver(booking.Id, 1);
            UserDTO driverRetour = utilisateurLogic.GetDriver(booking.Id, 0);
            AddressDTO addressAller = addressLogic.GetAddress(booking.Id);
            AddressDTO addressRetour = addressLogic.GetAddress(booking.Id);
            UserDTO createdBy = utilisateurLogic.Get(requestBooking.CreateBy);

            Booking _booking = new Booking
            {
                booking = booking,
                requestBooking = requestBooking,
                stopOver = stopOver,
                passagers = passagers,
                status = status,
                stopOverAddress = stopOverAddress,
                driverAller = driverAller,
                driverRetour = driverRetour,
                addressRetour = addressRetour,
                addressAller = addressAller,
                createdBy = createdBy
            };

            vm.Booking = _booking;

            return View(vm);
        }

        [HttpPost]
        public ActionResult RendreCar(int kilometrage, int idBooking, string LicencePlate)
        {
            BookingDTO booking = bookingLogic.Get(idBooking);
            RequestBookingDTO requestBooking = requestBookingLogic.GetByRequestBooking(booking.id_Request_Booking);
            requestBookingLogic.Update(requestBooking.id, 2002);

            carLogic.Update(LicencePlate, kilometrage);

            return RedirectToAction("Index", "Booking");
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

            if(events is null)
            {

            } else
            {
                foreach (EventDTO @event in events)
                {
                    fullCalendars.Add(new FullCalendarDTO { Id = @event.Id, Libelle = @event.Libelle, Start = @event.Start_Date.ToString("yyyy-MM-dd"), End = @event.End_Date.ToString("yyyy-MM-dd") });
                }

                foreach (BookingDTO booking in bookings)
                {
                    RequestBookingDTO requestBooking = requestBookingLogic.Get(booking.Id);

                    fullCalendars.Add(new FullCalendarDTO { Id = booking.Id, Libelle = requestBooking.Reason });
                }
            }

          
            return Json(fullCalendars.Select(e => new { id = e.Id, title = e.Libelle, start = e.Start, end = e.End }), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddCar(HttpPostedFileBase CarImage, CarIndexViewsModel vm, int dropdownlistCarsModels, int CompanyId, string Licence_Plate, int Mileage, string Energy)
        {
            CarDTO car = new CarDTO
            {
                Energy_Value = Energy,
                id_Car_Model = dropdownlistCarsModels,
                is_Active = 1,
                is_Available = 1,
                Licence_Plate = Licence_Plate,
                Mileage = Mileage,
                Id_User = (int)Session["userId"],
                Id_Company = CompanyId
            };

            if (CarImage != null && CarImage.ContentLength > 0)
                try
                {
                    string extension = Path.GetExtension(CarImage.FileName);
                    string filename = Licence_Plate;

                    string newFile = filename + extension;

                    string path = Path.Combine(Server.MapPath("~/Images/Cars"), newFile);
                    CarImage.SaveAs(path);
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
            else
            {
                ViewBag.Message = "You have not specified a file.";
            }


            carLogic.AddCar(car);

            return RedirectToAction("Index");
        }

        public JsonResult ListCars()
        {
            List<CarDTO> cars = new List<CarDTO>();

            cars = carLogic.List();

            return Json(cars, JsonRequestBehavior.AllowGet);
        }
    }
}