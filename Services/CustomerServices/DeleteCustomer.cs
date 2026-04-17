using HotelEC.Data;
using Spectre.Console;

namespace HotelEC.Services.CustomerServices
{
    public class DeleteCustomer : ICrud
    {
        public ApplicationDbContext dbContext { get; set; }
        public DeleteCustomer(ApplicationDbContext db)
        {
            dbContext = db;
        }
        public void Run()
        {
            var customer = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Välj kund att ta bort:")
                    .PageSize(15)
                    .EnableSearch()
                    .SearchPlaceholderText("Eller skriv för att söka...")
                    .AddChoices(dbContext.Customers.Select(c => c.FirstName + " " + c.LastName).ToList()));
            AnsiConsole.MarkupLine($"Du valde: [blue]{customer}[/]");
            AnsiConsole.MarkupLine($"Är du säker på att du vill ta bort [red]{customer}[/]? Detta går inte att ångra.");
            var confirm = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Bekräfta borttagning:")
                    .AddChoices("Ja", "Nej"));

            if (confirm == "Ja")
            {
                var customerToDelete = dbContext.Customers.FirstOrDefault(c => c.FirstName + " " + c.LastName == customer);
                if (customerToDelete != null)
                {
                    dbContext.Customers.Remove(customerToDelete);
                    dbContext.SaveChanges();
                    AnsiConsole.MarkupLine($"Kunden [red]{customer}[/] har tagits bort.");
                }
            }
        }
    }
}