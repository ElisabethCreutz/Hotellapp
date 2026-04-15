using HotelEC.Data;
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
            var room = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("Välj rum att ta bort:")
                .PageSize(15)
                .EnableSearch()
                .SearchPlaceholderText("Eller skriv för att söka...")
                .AddChoices(dbContext.Rooms.Select(r => "Rum " + r.Id + " - " + r.RoomType).ToList()));
            AnsiConsole.MarkupLine($"Du valde: [blue]{room}[/]");
            AnsiConsole.MarkupLine($"Är du säker på att du vill ta bort [red]{room}[/]? Detta går inte att ångra.");
            var confirm = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Bekräfta borttagning:")
                    .AddChoices("Ja", "Nej"));
            if (confirm == "Ja")
            {
                var roomToDelete = dbContext.Rooms.Where(r => "Rum " + r.Id + " - " + r.RoomType == room).FirstOrDefault();
                if (roomToDelete != null)
                {
                    dbContext.Rooms.Remove(roomToDelete);
                    dbContext.SaveChanges();
                    AnsiConsole.MarkupLine($"[green]{room}[/] har tagits bort.");
                }
            }
        }
    }
}
