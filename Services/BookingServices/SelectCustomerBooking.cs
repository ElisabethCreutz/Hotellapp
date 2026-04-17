using HotelEC.Data;
using HotelEC.Models.CustomerModels;
using HotelEC.Services.CustomerServices;
using Spectre.Console;

namespace HotelEC.Services.BookingServices
{
    public class SelectCustomerBooking
    {
        public ApplicationDbContext dbContext { get; set; }
        public SelectCustomerBooking(ApplicationDbContext db)
        {
            dbContext = db;
        }
        public Customer Select()
        {
            var selection = AnsiConsole.Prompt(
               new SelectionPrompt<string>()
               .Title("Välj ny eller befintlig kund")
               .AddChoices("Ny kund", "Befintlig kund"));
            AnsiConsole.MarkupLine($"Du var valt {selection}");
            if (selection == "Ny kund")
            {
                var createNew = new CreateCustomer(dbContext);
                createNew.Run();
                var newCustomer = dbContext.Customers.Select(c => c).OrderBy(c => c.Id).LastOrDefault();
                return newCustomer;
            }
            else
            {
                var select = new DisplayCustomers(dbContext);
                select.Run();
                var existingCustomer = AnsiConsole.Prompt(new SelectionPrompt<Customer>()
                    .Title("Välj en kund")
                    .EnableSearch()
                    .PageSize(10)
                    .UseConverter(c => $"{c.Id}: {c.FirstName} {c.LastName}")
                    .AddChoices(dbContext.Customers));
                return existingCustomer;
            }
        }
    }
}
