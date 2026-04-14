using HotelEC.Controllers;
using HotelEC.Data;
using HotelEC.Services;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelEC.Utilities.Menus
{
    public class CustomerMenu
    {

        public static void RunCustomerMenu(ApplicationDbContext db)
        {
            Console.Clear();
            var option = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("Kundmeny")
                .WrapAround()
                .AddChoices("Skapa kund", "Visa kunder", "Uppdatera kund", "Ta bort kund", "Tillbaka"));
            AnsiConsole.MarkupLine($"Du har valt [blue]{option}[/]");
            switch (option)
            {
                case "Skapa kund":
                   var customerService= new CustomerService(db);
                   customerService.CreateCustomer();
                    break;
                case "Visa kunder":
                    var displayTable=new SpectreTables(db);
                    displayTable.DisplayCustomerTable();
                    break;
                case "Uppdatera kund":
                    //update customer
                    break;
                case "Ta bort kund":
                    //delete customer
                    break;
                case "Tillbaka":
                    Console.Clear();
                    MainMenu.RunMenu(db);
                    break;
            }
        }
    }
}