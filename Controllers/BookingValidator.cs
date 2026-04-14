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
        { RuleFor(Booking => Booking.CheckInDate).NotEmpty().WithMessage("Incheckningsdatum är obligatoriskt.")
                                    .Must(BeAValidDate).WithMessage("Ogiltigt datumformat. Använd formatet YYYY-MM-DD.");
          RuleFor(Booking => Booking.CheckOutDate).NotEmpty().WithMessage("Utcheckningsdatum är obligatoriskt.")
                                    .Must(BeAValidDate).WithMessage("Ogiltigt datumformat. Använd formatet YYYY-MM-DD.")
                                    .GreaterThan(Booking => Booking.CheckInDate).WithMessage("Utcheckningsdatum måste vara senare än incheckningsdatum.");
          RuleFor(Booking => Booking.GuestId).NotEmpty().WithMessage("Gäst-ID är obligatoriskt.")
                                            .GreaterThan(0).WithMessage("Gäst-ID måste vara ett positivt heltal.");
          RuleFor(Booking => Booking.NumAdults).NotEmpty().WithMessage("Antal vuxna är obligatoriskt.")
                                            .GreaterThan(0).WithMessage("Antal vuxna måste vara minst 1.");
        }

        private bool BeAValidDate(string arg)
        {
            throw new NotImplementedException();
        }
    }
}
