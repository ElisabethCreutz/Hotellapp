using HotelEC.Controllers;
using HotelEC.Data;
using HotelEC.Services;
using HotelEC.Services.BookingServices;
using HotelEC.Services.CustomerServices;
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
                   var action= new CreateCustomer(db);
                    action.Run();
                    break;
                case "Visa kunder":
                    var displayTable=new DisplayCustomers(db);
                    displayTable.Run();
                    break;
                case "Uppdatera kund":
                    var action2 = new UpdateCustomer(db);
                    action2.Run(); break;
                case "Ta bort kund":
                    var action3 = new DeleteCustomer(db);
                    action3.Run(); break;
                case "Tillbaka":
                    Console.Clear();
                    MainMenu.RunMenu(db);
                    break;
            }
        }
    }
}