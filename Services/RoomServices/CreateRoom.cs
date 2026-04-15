using FluentValidation.Results;
using HotelEC.Controllers;
using HotelEC.Data;
using HotelEC.Models.RoomModels;


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
            ValidationResult result;
            do
            {
                Console.WriteLine("Vilken våning?");
                room.Floor = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enkel eller dubbel?");
                room.RoomType = Console.ReadLine();

                RoomValidator validator = new RoomValidator();
                result = validator.Validate(room);
                if (!result.IsValid)
                {
                    foreach (var failure in result.Errors)
                    {
                        Console.WriteLine(failure.PropertyName + " blev fel. Felet är: " + failure.ErrorMessage + "Försök igen");
                    }
                }
            }
            while (!result.IsValid);
            dbContext.Rooms.Add(room);
            dbContext.SaveChanges();
        }
    }
}
