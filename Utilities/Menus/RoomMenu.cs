using HotelEC.Data;
using HotelEC.Services.RoomServices;
using Spectre.Console;

namespace HotelEC.Utilities.Menus
{
    public class RoomMenu
    {
        public static void RunRoomMenu(ApplicationDbContext db)
        {
            var options = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .AddChoices(new[] {
                    "Skapa rum",
                    "Visa rum",
                    "Uppdatera rum",
                    "Ta bort rum",
                    "Tillbaka"
                }));
            AnsiConsole.MarkupLine($"[blue]{options.ToUpper()}[/]");
            switch (options)
            {
                case "Skapa rum":
                    var createRoom = new CreateRoom(db);
                    createRoom.Run();
                    break;
                case "Visa rum":
                    var roomTable = new DisplayRooms(db);
                    roomTable.Run();
                    break;
                case "Uppdatera rum":
                    var updateRoom = new UpdateRoom(db);
                    updateRoom.Run();
                    break;
                case "Ta bort rum":
                    var deleteRoom = new DeleteRoom(db);
                    deleteRoom.Run();
                    break;
                case "Tillbaka":
                    break;
            }
        }
    }
}
