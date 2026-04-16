using HotelEC.Data;
using HotelEC.Models.RoomModels;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelEC.Services.RoomServices
{
    public class DeleteRoom : ICrud
    {
        public ApplicationDbContext dbContext { get; set; }
        public DeleteRoom(ApplicationDbContext db)
        {
            dbContext = db;
        }
        public void Run()
        {
            DisplayRooms displayRooms = new DisplayRooms(dbContext);
            displayRooms.Run();
            var room = AnsiConsole.Prompt(new SelectionPrompt<Room>()
              .Title("Välj rum att ta bort:")
              .PageSize(15)
              .EnableSearch()
              .UseConverter(r => $"Rum {r.RoomNumber}")
              .AddChoices(dbContext.Rooms));
            AnsiConsole.MarkupLine($"Du valde: [blue]{room.RoomNumber}[/]");
            AnsiConsole.MarkupLine($"Är du säker på att du vill ta bort " +
                $"[red]{room.RoomNumber}[/]? Detta går inte att ångra.");
            var confirm = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Bekräfta borttagning:")
                    .AddChoices("Ja", "Nej"));
            if (confirm == "Ja")
            {
                dbContext.Rooms.Remove(room);
                dbContext.SaveChanges();
                AnsiConsole.MarkupLine($"[green]{room.RoomNumber}[/] har tagits bort.");

            }
        }
    }
}
