using HotelEC.Data;
using HotelEC.Models.RoomModels;
using Spectre.Console;

namespace HotelEC.Services.RoomServices
{
    internal class UpdateRoom : ICrud
    {
        public ApplicationDbContext dbContext { get; set; }
        public UpdateRoom(ApplicationDbContext db)
        {
            dbContext = db;
        }
        public void Run()
        {
            DisplayRooms displayRooms = new DisplayRooms(dbContext);
            displayRooms.Run();
            var room = AnsiConsole.Prompt(new SelectionPrompt<Room>()
                .Title("Välj rum att ändra:")
                .PageSize(15)
                .EnableSearch()
                .UseConverter(r => $"Rum {r.RoomNumber}")
                .AddChoices(dbContext.Rooms));
            AnsiConsole.MarkupLine($"Du valde: [blue]{room.RoomNumber}[/]");
            var option = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("Vilken information vill du ändra?")
                .PageSize(10)
                .AddChoices("Rumstyp", "Pris"));
            switch (option)
            {
                case "Rumstyp":
                    room.Type = AnsiConsole.Prompt(
                       new SelectionPrompt<RoomType>()
                       .Title("Välj rumstyp:")
                       .PageSize(10)
                       .AddChoices(RoomType.Single, RoomType.Double));
                    AnsiConsole.MarkupLine($"[green]Rum {room.RoomNumber}[/] har uppdaterats till ett {room.Type}.");
                    dbContext.SaveChanges();
                    break;
                case "Pris":
                    var newPrice = AnsiConsole.Ask<decimal>("Ange nytt pris:");

                    room.PricePerNight = newPrice;
                    dbContext.SaveChanges();
                    AnsiConsole.MarkupLine($"[green]Rum {room.RoomNumber}[/] har uppdaterats med nytt pris {room.PricePerNight} kr per natt.");
                    Console.ReadKey();
                    break;
            }
        }
    }
}
