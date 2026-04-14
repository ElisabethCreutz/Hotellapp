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
            Console.Clear();
            bool isRunning = true;
            while (isRunning)
            {
                var option = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Menyval")
                .WrapAround()
                .AddChoices("Bokningar", "Rum", "Kunder", "Betalningar", "Avsluta"));

                AnsiConsole.MarkupLine($"Du har valt [blue]{option}[/]");

                switch (option)
                {
                    case "Bokningar":
                        //booking menu
                        break;
                    case "Rum":
                        //Room menu
                        break;
                    case "Kunder":
                        CustomerMenu.RunCustomerMenu(db);
                        break;
                    case "Betalningar":
                        //payment menu
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