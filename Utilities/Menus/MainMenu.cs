using HotelEC.Data;
using HotelEC.Models;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelEC.Utilities.Menus
{
    public class MainMenu
    {
        public static void RunMenu(ApplicationDbContext db)
        {
            Visuals.DisplayTitle();
            Thread.Sleep(2000);
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Visuals.DisplayShorttitle();
                var option = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Huvudmeny")
                .WrapAround()
                .AddChoices("Bokningar", "Rum", "Kunder", "Avsluta"));

                AnsiConsole.MarkupLine($"[blue]{option}[/]");

                switch (option)
                {
                    case "Bokningar":
                        BookingMenu.RunBookingMenu(db);
                        break;
                    case "Rum":
                        RoomMenu.RunRoomMenu(db);
                        break;
                    case "Kunder":
                        CustomerMenu.RunCustomerMenu(db);
                        break;
                    case "Avsluta":
                        Console.Clear();
                        isRunning = false;
                        Console.WriteLine("Tack för dagens arbete!");
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}