using HotelEC.Data;
using HotelEC.Models.BookingModels;
using Spectre.Console;

namespace HotelEC.Services.CustomerServices
{
    public class UpdateCustomer : ICrud
    {
        public ApplicationDbContext dbContext { get; set; }
        public UpdateCustomer(ApplicationDbContext db)
        {
            dbContext = db;
        }


        public void Run()
        {
            var customer = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Välj kund att ändra:")
                .PageSize(15)
                .EnableSearch()
                .SearchPlaceholderText("Eller skriv för att söka...")
                .AddChoices(dbContext.Customers.Select(c => c.FirstName + " " + c.LastName).ToList()));
            AnsiConsole.MarkupLine($"Du valde: [blue]{customer}[/]");

            var option = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("Vilken information vill du ändra?")
                .PageSize(10)
                .AddChoices("Förnamn", "Efternamn", "E-post", "Telefonnummer"));
            switch (option)
            {
                case "Förnamn":
                    var newFirstName = AnsiConsole.Ask<string>("Ange nytt förnamn:");
                    dbContext.Customers.Where(c => c.FirstName + " " + c.LastName == customer).FirstOrDefault().FirstName = newFirstName;
                    break;
                case "Efternamn":
                    var newLastName = AnsiConsole.Ask<string>("Ange nytt efternamn:");
                    dbContext.Customers.Where(c => c.FirstName + " " + c.LastName == customer).FirstOrDefault().LastName = newLastName;
                    break;
                case "E-post":
                    var newEmail = AnsiConsole.Ask<string>("Ange ny e-postadress:");
                    dbContext.Customers.Where(c => c.FirstName + " " + c.LastName == customer).FirstOrDefault().EmailAddress = newEmail;
                    break;
                case "Telefonnummer":
                    var newPhone = AnsiConsole.Ask<string>("Ange nytt telefonnummer:");
                    dbContext.Customers.Where(c => c.FirstName + " " + c.LastName == customer).FirstOrDefault().PhoneNumber = newPhone;
                    break;
            }

        }
    }

}