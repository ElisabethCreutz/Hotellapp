using HotelEC.Data;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelEC.Services.RoomServices
{
    internal class DisplayRooms:ICrud
    {
        public ApplicationDbContext dbContext { get; set; }


        public DisplayRooms(ApplicationDbContext db)
        {
            dbContext = db;
        }


        public void Run()
        {
            var roomTable = new Table();
            roomTable.AddColumns("Rumsnummer", "Våning", "Rumstyp","Pris","Möjliga extrasängar", "Status");
            foreach (var room in dbContext.Rooms)
            {
                roomTable.AddRow(room.RoomNumber.ToString(), room.Floor.ToString(), room.Type.ToString(), room.PricePerNight.ToString(), room.ExtraBeds.ToString(), room.Status.ToString());
            }
            AnsiConsole.Write(roomTable);
            AnsiConsole.MarkupLine("[purple]Tryck på valfri tangent för att fortsätta...[/]");
            Console.ReadKey();
        }
    }
}
