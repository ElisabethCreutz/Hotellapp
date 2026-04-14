using HotelEC.Data;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelEC.Utilities.Menus
{
    internal class RoomMenu
    {
        public static void RunRoomMenu(ApplicationDbContext db)
        {
            var options = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("Select an option:")
                .AddChoices(new[] {
                    "Visa alla rum",
                    "Lägg till nytt rum",
                    "Uppdatera rum",
                    "Ta bort rum",
                    "Tillbaka till huvudmenyn"
                }));
            switch (options)
            {
                case "Visa alla rum":
                    var roomTable = new SpectreTables(db);
                    roomTable.DisplayRoomTable();
                    break;
                case "Lägg till nytt rum":

                    break;
                case "Uppdatera rum":
                    break;
                case "Ta bort rum":
                    break;
                case "Tillbaka till huvudmenyn":
                    break;
            }
        }
    }
}
