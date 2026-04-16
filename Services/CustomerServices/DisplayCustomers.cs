using HotelEC.Data;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelEC.Services.CustomerServices
{
    internal class DisplayCustomers:ICrud
    {
        public ApplicationDbContext dbContext { get; set; }


        public DisplayCustomers(ApplicationDbContext db)
        {
            dbContext = db;
        }

        public void Run()
        {
            var CustTable = new Table();
            CustTable.AddColumn("Förnamn");
            CustTable.AddColumn("Efternamn");
            CustTable.AddColumn("Telefonnummer");
            CustTable.AddColumn("E-postadress");
            foreach (var customer in dbContext.Customers)
            {
                CustTable.AddRow(customer.FirstName, customer.LastName, customer.PhoneNumber, customer.EmailAddress);
            }
            AnsiConsole.Write(CustTable);
            AnsiConsole.MarkupLine("[purple]Tryck på valfri tangent för att fortsätta...[/]");
            Console.ReadKey();
        }
    }
}
