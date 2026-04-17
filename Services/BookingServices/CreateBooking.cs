using HotelEC.Data;
using HotelEC.Models.BookingModels;
using HotelEC.Models.RoomModels;
using HotelEC.Utilities;
using Spectre.Console;

namespace HotelEC.Services.BookingServices
{
    public class CreateBooking : ICrud
    {
        public ApplicationDbContext dbContext { get; set; }
        public CreateBooking(ApplicationDbContext db)
        {
            dbContext = db;
        }
        public void Run()
        {
            var booking = new Booking();
            var selectCustomerBooking = new SelectCustomerBooking(dbContext);
            booking.Guest = selectCustomerBooking.Select();
            Console.Clear();
            Console.WriteLine($"Välj datum för {booking.Guest.FirstName} {booking.Guest.LastName}");
            var calendar = new CalendarClass();
            booking.CheckInDate = calendar.DisplayCalendar();
            int numNights = AnsiConsole.Prompt(
                new TextPrompt<int>("Hur många nätter?")
                .Validate(n =>
                n > 0 && n < 21
                ? ValidationResult.Success()
                : ValidationResult.Error("[red]Antal nätter måste vara mellan 1 och 20[/]")));
            booking.CheckOutDate = booking.CheckInDate.AddDays(numNights);
            booking.NumAdults = AnsiConsole.Prompt(
                new TextPrompt<int>("Hur många vuxna?")
                .Validate(n =>
                n > 0 && n < 5
                ? ValidationResult.Success()
                : ValidationResult.Error("[red]Antal vuxna måste vara mellan 1 och 4[/]")));
            booking.NumChildren = AnsiConsole.Prompt(
                new TextPrompt<int>("Hur många barn?")
                .Validate(n =>
                n >= 0 && n < 5
                ? ValidationResult.Success()
                : ValidationResult.Error("[red]Antal barn måste vara mellan 0 och 4[/]")));
            booking.Room = DisplayAvailableRooms(booking.CheckInDate, booking.CheckOutDate, booking.NumAdults, booking.NumChildren);
            if (booking.Room.Type == RoomType.Double)
            {
                if (booking.Room.RoomSize > 12)
                {
                    AnsiConsole.Prompt(new SelectionPrompt<int>()
                        .Title("Extrasängar:").AddChoices(0, 1, 2));
                }
                else
                {
                    AnsiConsole.Prompt(new SelectionPrompt<int>()
                        .Title("Extrasängar:").AddChoices(0, 1));
                }
            }
            booking.BookingAmount = booking.Room.PricePerNight * numNights;
            //TODO display a summary of the booking before saving
            dbContext.Bookings.Add(booking);
            dbContext.SaveChanges();
        }
        public Room DisplayAvailableRooms(DateTime checkInDate, DateTime checkOutDate, int numAdults, int numChildren)
        {
            AnsiConsole.MarkupLine($"Tillgängliga rum mellan [green]{checkInDate:yyyy-MM-dd}[/] och [green]{checkOutDate:yyyy-MM-dd}[/] för [green]{numAdults}[/] vuxna och [green]{numChildren}[/] barn:");
            dbContext.Rooms.Where(r => r.RoomSize >= numAdults + numChildren && r.Status == RoomStatus.Available).ToList();
            var unavailable = dbContext.Bookings.Where(b => (b.CheckInDate < checkOutDate && b.CheckOutDate > checkInDate))
                .Select(b => b.Room);
            var availableRooms = dbContext.Rooms.Where(r => r.Status == RoomStatus.Available && !unavailable.Contains(r)).ToList();
            var bookingRoom = AnsiConsole.Prompt(
                new SelectionPrompt<Room>()
                .AddChoices(availableRooms)
                .UseConverter(r => $"Rum {r.RoomNumber} - {r.Type} -  {r.RoomSize}  - {r.PricePerNight:C} per natt"));
            return bookingRoom;
        }
    }
}