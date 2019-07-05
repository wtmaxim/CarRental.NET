using CarRental.BLL;
using CarRental.Model;
using CarRental.UI.ViewsModels.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarRental.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly AdressLogic adressLogic; 
        public HomeController()
        {
            adressLogic = new AdressLogic();
        }

        public ActionResult Index()
        {
            List<AddressDTO> adresses = new List<AddressDTO>();

            adresses = adressLogic.List();

            return View();
        }

        [HttpGet]
        public ActionResult PasswordForbidden()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel loginViewModel)
        {


            return View();
        }
    }
}