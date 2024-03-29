﻿using System;
using System.Collections.Generic;
using CarRental.DAL;
using CarRental.DAL.Interface;
using CarRental.Model;

namespace CarRental.BLL
{
    public class RequestBookingLogic
    {
        private readonly IRequestBookingEngine requestBookingEngine;

        public RequestBookingLogic()
        {
            requestBookingEngine = new RequestBookingEngine();
        }

        public RequestBookingDTO Insert(RequestBookingDTO requestBooking)
        {
            requestBooking.Id_Status = 2;
            return requestBookingEngine.Insert(requestBooking);
        }

        public RequestBookingDTO Get(int idBooking)
        {
            return requestBookingEngine.Get(idBooking);
        }

        public List<RequestBookingDTO> List(int idUser)
        {
            return requestBookingEngine.List(idUser);
        }

        public IEnumerable<RequestBookingDTO> List()
        {
            return requestBookingEngine.List();
        }

        public IEnumerable<RequestBookingDTO> ListbyStatus(int idStatus)
        {
            return requestBookingEngine.ListByStatus(idStatus);
        }

        public RequestBookingDTO GetByRequestBooking(int idRequestBooking)
        {
            return requestBookingEngine.GetByRequestBooking(idRequestBooking);
        }

        public void Update(int idRequestBooking, int idStatus)
        {
            requestBookingEngine.Update(idRequestBooking, idStatus);
        }
    }
}
