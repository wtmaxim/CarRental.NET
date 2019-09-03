﻿using CarRental.DAL;
using CarRental.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.BLL
{
    public class BookingLogic
    {
        private readonly IBookingEngine bookingEngine;

        public BookingLogic()
        {
            bookingEngine = new BookingEngine();
        }

        public BookingDTO Get(int id)
        {
            return bookingEngine.Get(id);
        }

        public List<BookingDTO> List(string licence_plate)
        {
            return bookingEngine.List(licence_plate);
        }

        public BookingDTO Insert(object p1, object p2, int idRequestBooking)
        {
            throw new NotImplementedException();
        }
    }
}
