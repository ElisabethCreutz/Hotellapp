using HotelEC.Data;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

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
            var room = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("Välj rum att ändra:")
                .PageSize(15)
                .EnableSearch()
                .SearchPlaceholderText("Eller skriv för att söka...")
                .AddChoices(dbContext.Rooms.Select(r => "Rum " + r.Id + " - " + r.RoomType).ToList()));
            AnsiConsole.MarkupLine($"Du valde: [blue]{room}[/]");
             var option = AnsiConsole.Prompt(
                 new SelectionPrompt<string>()
                 .Title("Vilken information vill du ändra?")
                 .PageSize(10)
                 .AddChoices("Våning", "Rumstyp"));
             switch (option)
             {
                 case "Våning":
                     var newFloor = AnsiConsole.Ask<int>("Ange ny våning:");
                     dbContext.Rooms.Where(r => "Rum " + r.Id + " - " + r.RoomType == room).FirstOrDefault().Floor = newFloor;
                     break;
                 case "Rumstyp":
                     var newRoomType = AnsiConsole.Ask<string>("Ange ny rumstyp:");
                     dbContext.Rooms.Where(r => "Rum " + r.Id + " - " + r.RoomType == room).FirstOrDefault().RoomType = newRoomType;
                     break;
            }
        }
    }
}
