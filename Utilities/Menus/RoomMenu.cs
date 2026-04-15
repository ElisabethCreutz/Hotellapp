using HotelEC.Data;
using HotelEC.Services.RoomServices;
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
                    var createRoom = new CreateRoom(db);
                    createRoom.Run();
                    break;
                case "Uppdatera rum":
                    var updateRoom = new UpdateRoom(db);
                    updateRoom.Run();
                    break;
                case "Ta bort rum":
                    var deleteRoom = new DeleteRoom(db);
                    deleteRoom.Run();
                    break;
                case "Tillbaka till huvudmenyn":
                    break;
            }
        }
    }
}
