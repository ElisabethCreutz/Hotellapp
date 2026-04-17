using FluentValidation;
using HotelEC.Models.CustomerModels;

namespace HotelEC.Controllers
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(customer => customer.FirstName).NotEmpty().WithMessage("Förnamn är obligatoriskt.");
            RuleFor(customer => customer.LastName).NotEmpty().WithMessage("Efternamn är obligatoriskt.");
            RuleFor(customer => customer.EmailAddress).NotEmpty().WithMessage("E-postadress är obligatoriskt.")
                                                      .EmailAddress(mode: FluentValidation.Validators.EmailValidationMode.Net4xRegex).WithMessage("Ogiltig e-postadress.");
            //Ja, dåligt att använda Obsolete metod men det fungerar och validerar både @ och . i e-postadressen.
            RuleFor(customer => customer.PhoneNumber).NotEmpty().WithMessage("Telefonnummer är obligatoriskt.");
        }
    }
}