using HotelEC.Data;
using HotelEC.Services.BookingServices;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelEC.Utilities.Menus
{
    internal class BookingMenu
    {
        public static void RunBookingMenu(ApplicationDbContext db)
        {

            var option = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
            .Title("Bokningsmeny")
            .WrapAround()
            .AddChoices("Skapa bokning", "Visa bokningar", "Uppdatera bokning", "Ta bort bokning", "Tillbaka"));
            AnsiConsole.MarkupLine($"Du har valt [blue]{option}[/]");
            switch (option)
            {
                case "Skapa bokning":
                    var action = new CreateBooking(db);
                    action.Run();
                    break;
                case "Visa bokningar":
                    //show bookings
                    break;
                case "Uppdatera bokning":
                    //update booking
                    break;
                case "Ta bort bokning":
                    //delete booking
                    break;
                case "Tillbaka":
                    Console.Clear();
                    MainMenu.RunMenu(db);
                    break;
            }
        }
    }
}

