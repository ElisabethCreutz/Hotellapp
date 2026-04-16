using FluentValidation.Results;
using HotelEC.Controllers;
using HotelEC.Data;
using HotelEC.Models.RoomModels;
using Microsoft.EntityFrameworkCore;
using Spectre.Console;


namespace HotelEC.Services.RoomServices
{
    public class CreateRoom : ICrud
    {
        public ApplicationDbContext dbContext { get; set; }
        public CreateRoom(ApplicationDbContext db)
        {
            dbContext = db;
        }
        public void Run()
        {
            var room = new Room();

            room.Floor = new Random().Next(1, 10);
            room.RoomNumber = GenerateUniqueRoomNumber(room.Floor);
            room.Type = AnsiConsole.Prompt(new SelectionPrompt<RoomType>()
                    .Title("Välj rumstyp:")
                    .AddChoices(RoomType.Single, RoomType.Double));
            room.RoomSize = AnsiConsole.Prompt(new SelectionPrompt<int>()
                    .Title("Välj rumstorlek i kvadratmeter:")
                    .AddChoices(10, 12, 15, 20, 22));
            if (room.Type == RoomType.Double&& room.RoomSize > 12)
            {
                room.ExtraBeds = AnsiConsole.Prompt(new SelectionPrompt<int>()
                    .Title("Välj antal extrasängar:")
                    .AddChoices(1, 2));
            }
            else if (room.Type== RoomType.Double && room.RoomSize <= 12)
            {
                room.ExtraBeds = 1;
            }
            else
            {
                room.ExtraBeds = 0;
            }
            
            room.Status = RoomStatus.Available;
            room.PricePerNight = AnsiConsole.Prompt(new SelectionPrompt<decimal>()
                    .Title("Ange pris per natt:")
                    .AddChoices(1100, 2200, 1300, 2400, 1500));
            AnsiConsole.MarkupLine($"[green]Rumsnummer {room.RoomNumber} har skapats på våning {room.Floor}.[/]");
            Console.ReadKey();
            dbContext.Rooms.Add(room);
            dbContext.SaveChanges();
        }
        public int GenerateUniqueRoomNumber(int floor)
        {
            int attempts = 0;

            while (attempts < 100)
            {
                int randomNumber = new Random().Next(1, 100);
                int roomNumber = floor * 100 + randomNumber;

                bool exists = dbContext.Rooms
                    .Any(r => r.RoomNumber == roomNumber);

                if (!exists)
                {
                    return roomNumber;
                }

                attempts++;
            }
            throw new Exception("Could not find a free room number."); //kanske se över
        }
    }
}
