using FluentValidation.Results;
using HotelEC.Controllers;
using HotelEC.Data;
using HotelEC.Models.CustomerModels;

namespace HotelEC.Services.CustomerServices
{
    public class CreateCustomer:ICrud
    {
        public ApplicationDbContext dbContext { get; set; }
        public CreateCustomer(ApplicationDbContext db)
        {
            dbContext = db;
        }
        public void Run()
        {
            var customer = new Customer();
            ValidationResult result;
            do
            {
                var customerService = new CustomerService(dbContext);
                Console.WriteLine("Vad heter du?");
                customer.FirstName = Console.ReadLine();
                Console.WriteLine("Vad är ditt efternamn?");
                customer.LastName = Console.ReadLine();
                Console.WriteLine("Vad är din e-postadress?");
                customer.EmailAddress = Console.ReadLine();
                Console.WriteLine("Vad är ditt telefonnummer?");
                customer.PhoneNumber = Console.ReadLine();

                CustomerValidator validator = new CustomerValidator();
                result = validator.Validate(customer);
                if (!result.IsValid)
                {
                    foreach (var failure in result.Errors)
                    {
                        Console.WriteLine(failure.PropertyName + " blev fel. Felet är: " + failure.ErrorMessage + "Försök igen");
                    }
                }
            }
            while (!result.IsValid);

            dbContext.Customers.Add(customer);
            dbContext.SaveChanges();
        }
    }
}
