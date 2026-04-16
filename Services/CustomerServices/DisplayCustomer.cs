using HotelEC.Data;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelEC.Services.CustomerServices
{
    internal class DisplayCustomer:ICrud
    {
        public ApplicationDbContext dbContext { get; set; }


        public DisplayCustomer(ApplicationDbContext db)
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
            Console.ReadKey();
        }
    }
}
