﻿using CarRental.BLL;
using CarRental.Model;
using CarRental.UI.ViewsModels.Booking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarRental.UI.Controllers
{
    public class BookingController : Controller
    {
        private readonly BookingLogic bookingLogic;
        private readonly RequestBookingLogic requestBookingLogic;
        private readonly StopOverAddressLogic stopOverAddressLogic;
        private readonly UserBookingLogic userBookingLogic;
        private readonly CarLogic carLogic;
        private readonly CarModelLogic carModelLogic;
        private readonly CarMakeLogic carMakeLogic;
        private readonly StopOverLogic stopOverLogic;
        private readonly AdressLogic addressLogic;
        private readonly UtilisateurLogic utilisateurLogic;
        private readonly StatusLogic statusLogic;
        private readonly NotificationLogic notificationLogic;

        public BookingController()
        {
            bookingLogic = new BookingLogic();
            requestBookingLogic = new RequestBookingLogic();
            stopOverAddressLogic = new StopOverAddressLogic();
            userBookingLogic = new UserBookingLogic();
            carLogic = new CarLogic();
            carModelLogic = new CarModelLogic();
            carMakeLogic = new CarMakeLogic();
            stopOverLogic = new StopOverLogic();
            addressLogic = new AdressLogic();
            utilisateurLogic = new UtilisateurLogic();
            statusLogic = new StatusLogic();
            notificationLogic = new NotificationLogic();
        }

        /// <summary>
        /// - Récupérer STOPOverAddress
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult Index()
        {
            BookingIndexViewsModel vm = new BookingIndexViewsModel();

            vm.Addresses = PopulateAddress();
            vm.Users = PopulateUsers();

            int idCurrentUser = (int)Session["userId"];
            Session["notifs"] = notificationLogic.ListAllForUser(idCurrentUser).FindAll(n => n.IsRead == 0).Count;

            return View(vm);
        }

        [Authorize]
        public ActionResult Validations()
        {
            BookingValidationsViewsModel vm = new BookingValidationsViewsModel();
            List<Booking> bookings = new List<Booking>();

            foreach (RequestBookingDTO requestBooking in requestBookingLogic.ListbyStatus(2))
            {
                BookingDTO booking = bookingLogic.GetByRequestBooking(requestBooking.id);
                StopOverDTO stopOver = stopOverLogic.GetByBooking(booking.Id);
                List<UserDTO> passagersAller = utilisateurLogic.ListPassagers(booking.Id, 1);
                List<UserDTO> passagersRetour = utilisateurLogic.ListPassagers(booking.Id, 0);
                StatusDTO status = statusLogic.GetStatus(requestBooking.Id_Status);
                StopOverAddressDTO stopOverAddress = stopOverAddressLogic.GetStopOverAddress(stopOver.Id);
                UserDTO driverAller = utilisateurLogic.GetDriver(booking.Id, 1);
                UserDTO driverRetour = utilisateurLogic.GetDriver(booking.Id, 0);
                AddressDTO addressAller = addressLogic.GetAddress(booking.Id);
                AddressDTO addressRetour = addressLogic.GetAddress(booking.Id);
                UserDTO createdBy = utilisateurLogic.Get(requestBooking.CreateBy);


                bookings.Add(new Booking
                {
                    booking = booking,
                    requestBooking = requestBooking,
                    stopOver = stopOver,
                    passagersAller = passagersAller,
                    passagerRetour = passagersRetour,
                    status = status,
                    stopOverAddress = stopOverAddress,
                    driverAller = driverAller,
                    driverRetour = driverRetour,
                    addressRetour = addressRetour,
                    addressAller = addressAller,
                    createdBy = createdBy
                });
            }

            vm.Bookings = bookings;

            return View(vm);
        }

        public ActionResult Validation(int id)
        {
            BookingValidationViewsModel vm = new BookingValidationViewsModel();
            
            RequestBookingDTO requestBooking = requestBookingLogic.GetByRequestBooking(id);

            BookingDTO booking = bookingLogic.GetByRequestBooking(requestBooking.id);
            StopOverDTO stopOver = stopOverLogic.GetByBooking(booking.Id);
            List<UserDTO> passagersAller = utilisateurLogic.ListPassagers(booking.Id, 1);
            List<UserDTO> passagersRetour = utilisateurLogic.ListPassagers(booking.Id, 0);
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
                passagerRetour = passagersRetour,
                passagersAller = passagersRetour,
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

        [HttpGet]
        public ActionResult AssignationCar(int id)
        {
            BookingAssignationViewsModel vm = new BookingAssignationViewsModel();
            List<CarDTO> _cars = carLogic.List();
            List<Tuple<CarDTO, CarModelDTO, CarMakeDTO>> cars = new List<Tuple<CarDTO, CarModelDTO, CarMakeDTO>>();
            BookingDTO booking = bookingLogic.GetByRequestBooking(id);

            foreach (CarDTO car in _cars)
            {
                CarModelDTO carModel = carModelLogic.Get(car.id_Car_Model);
                CarMakeDTO carMake = carMakeLogic.Get(carModel.id_Car_Make);

                cars.Add(new Tuple<CarDTO, CarModelDTO, CarMakeDTO>(car, carModel, carMake));
            }

            vm.Cars = cars;
            vm.Booking = booking;

            return View(vm);
        }

        public ActionResult RefuserBooking(int id)
        {
            RequestBookingDTO requestBooking = requestBookingLogic.GetByRequestBooking(id);
            requestBookingLogic.Update(id, 3);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult AssignationCar(string CarValue, int idBooking)
        {
            var licencePlate = CarValue;

            bookingLogic.Update(idBooking, licencePlate);
            BookingDTO booking = bookingLogic.Get(idBooking);
            RequestBookingDTO requestBooking = requestBookingLogic.GetByRequestBooking(booking.id_Request_Booking);
            requestBookingLogic.Update(requestBooking.id, 1);

            return RedirectToAction("Index");
        }

        private List<SelectListItem> PopulateAddress()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            List<AddressDTO> addresses = addressLogic.List();

            foreach (AddressDTO address in addresses)
            {
                items.Add(new SelectListItem
                {
                    Text = address.Name,
                    Value = address.Id.ToString()
                });
            }

            return items;
        }

        private List<SelectListItem> PopulateUsers()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            List<UserDTO> users = utilisateurLogic.ListAll();

            foreach (UserDTO user in users)
            {
                string fullName = user.Firstname + ' ' + user.Lastname;
                items.Add(new SelectListItem
                {
                    Text = fullName,
                    Value = user.Id.ToString()
                }) ;
            }

            return items;
        }

        [ChildActionOnly]
        public ActionResult PartialListBooking()
        {
            int id = (int)Session["userID"];
            BookingIndexViewsModel vm = new BookingIndexViewsModel();
            List<Booking> bookings = new List<Booking>();

            var requestBookings = requestBookingLogic.List(id);

            if (requestBookings.Count > 0)
            {
                foreach (RequestBookingDTO requestBooking in requestBookingLogic.List(id))
                {
                    BookingDTO booking = bookingLogic.GetByRequestBooking(requestBooking.id);
                    StopOverDTO stopOver = stopOverLogic.GetByBooking(booking.Id);
                    List<UserDTO> passagersAller = utilisateurLogic.ListPassagers(booking.Id, 1);
                    List<UserDTO> passagersRetour = utilisateurLogic.ListPassagers(booking.Id, 0);
                    StatusDTO status = statusLogic.GetStatus(requestBooking.Id_Status);
                    StopOverAddressDTO stopOverAddress = stopOverAddressLogic.GetStopOverAddress(stopOver.Id);
                    UserDTO driverAller = utilisateurLogic.GetDriver(booking.Id, 1);
                    UserDTO driverRetour = utilisateurLogic.GetDriver(booking.Id, 0);
                    AddressDTO addressAller = addressLogic.GetAddress(booking.Id, 1);
                    AddressDTO addressRetour = addressLogic.GetAddress(booking.Id, 0);
                    UserDTO createdBy = utilisateurLogic.Get(requestBooking.CreateBy);


                    bookings.Add(new Booking
                    {
                        booking = booking,
                        requestBooking = requestBooking,
                        stopOver = stopOver,
                        passagersAller = passagersAller,
                        passagerRetour = passagersRetour,
                        status = status,
                        stopOverAddress = stopOverAddress,
                        driverAller = driverAller,
                        driverRetour = driverRetour,
                        addressRetour = addressRetour,
                        addressAller = addressAller,
                        createdBy = createdBy
                    });
                }
            }           

            vm.Bookings = bookings;

            return PartialView("_ListBookingPartial", vm);
        }
    }
}