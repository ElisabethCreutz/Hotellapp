using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using HotelEC.Models.CustomerModels;

namespace HotelEC.Controllers
{
    internal class CustomerValidator:AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(customer => customer.FirstName).NotEmpty().WithMessage("Förnamn är obligatoriskt.");
            RuleFor(customer => customer.LastName).NotEmpty().WithMessage("Efternamn är obligatoriskt.");
            RuleFor(customer => customer.EmailAddress).NotEmpty().WithMessage("E-postadress är obligatoriskt.")
                                                      .EmailAddress().WithMessage("Ogiltig e-postadress.");
            RuleFor(customer => customer.PhoneNumber).NotEmpty().WithMessage("Telefonnummer är obligatoriskt.");
        }
    }
}