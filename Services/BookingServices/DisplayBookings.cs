using HotelEC.Data;
using Microsoft.EntityFrameworkCore;
using Spectre.Console;

namespace HotelEC.Services.BookingServices
{
    public class DisplayBookings : ICrud
    {
        public ApplicationDbContext dbContext { get; set; }


        public DisplayBookings(ApplicationDbContext db)
        {
            dbContext = db;
        }


        public void Run()
        {
            var bookingTable = new Table();
            bookingTable.AddColumns("Id", "Förnamn","Efternamn","Rum", "Från", "Till", "Kostnad","Vuxna", "Barn");
            foreach (var booking in dbContext.Bookings.Include(b => b.Guest).Include(b => b.Room)) 
            {
                bookingTable.AddRow(booking.Id.ToString(), booking.Guest.FirstName,booking.Guest.LastName,
                    booking.Room.RoomNumber.ToString(), booking.CheckInDate.ToShortDateString(), 
                    booking.CheckOutDate.ToShortDateString(), booking.BookingAmount.ToString("C"),
                    booking.NumAdults.ToString(), booking.NumChildren.ToString());
            }
            AnsiConsole.Write(bookingTable);
            AnsiConsole.MarkupLine("[purple]Tryck på valfri tangent för att fortsätta...[/]");
            Console.ReadKey();

        }
    }
}
