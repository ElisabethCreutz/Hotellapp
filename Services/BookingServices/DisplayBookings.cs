using HotelEC.Data;
using HotelEC.Services;
using Spectre.Console;

namespace HotelEC.Services.BookingServices
{
    public class DisplayBookings:ICrud
    {
        public ApplicationDbContext dbContext { get; set; }


        public DisplayBookings(ApplicationDbContext db)
        {
            dbContext = db;
        }
              
    
        public void Run()
        {
            var bookingTable = new Table();
            bookingTable.AddColumns("Incheckningsdatum", "Utcheckningsdatum", "Antal vuxna", "Antal barn");
            foreach (var booking in dbContext.Bookings)
            {
                bookingTable.AddRow(booking.CheckInDate.ToString(), booking.CheckOutDate.ToString(), booking.NumAdults.ToString(), booking.NumChildren.ToString());
            }
            AnsiConsole.Write(bookingTable);
            AnsiConsole.MarkupLine("[green]Bokningstabell visad![/]");
            AnsiConsole.MarkupLine("[yellow]Tryck på valfri tangent för att fortsätta...[/]");
            Console.ReadKey();

        }
    }
}
