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
            .WrapAround()
            .AddChoices("Skapa bokning", "Visa bokningar", "Uppdatera bokning", "Ta bort bokning", "Tillbaka"));
            AnsiConsole.MarkupLine($"[blue]{option.ToUpper()}[/]");
            switch (option)
            {
                case "Skapa bokning":
                    var action = new CreateBooking(db);
                    action.Run();
                    break;
                case "Visa bokningar":
                    var booking = new DisplayBookings(db);
                    booking.Run();
                    break;
                case "Uppdatera bokning":
                    Console.WriteLine("Kommande funktion...");
                    Console.ReadKey();
                    break;
                case "Ta bort bokning":
                    Console.WriteLine("Kommande funktion...");
                    Console.ReadKey();
                    break;
                case "Tillbaka":
                    break; 
            }
        }
    }
}

