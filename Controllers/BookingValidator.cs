using FluentValidation;
using HotelEC.Models.BookingModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelEC.Controllers
{
    internal class BookingValidator:AbstractValidator<Booking>
    {
        public BookingValidator()
        { }

        private bool BeAValidDate(string arg)
        {
            throw new NotImplementedException();
        }
    }
}
