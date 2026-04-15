using HotelEC.Data;
using Spectre.Console;

namespace HotelEC.Utilities
{
    public class SpectreTables
    {
        public ApplicationDbContext dbContext { get; set; }


        public SpectreTables(ApplicationDbContext db)
        {
            dbContext = db;
        }

        public void DisplayCustomerTable()
        {
            var CustTable = new Table();
            CustTable.AddColumn("Förnamn");
            CustTable.AddColumn("Efternamn");
            CustTable.AddColumn("Telefonnummer");
            CustTable.AddColumn("E-postadress");
            foreach (var customer in dbContext.Customers)
            {
                CustTable.AddRow(customer.FirstName, customer.LastName, customer.PhoneNumber, customer.EmailAddress);
            }
            AnsiConsole.Write(CustTable);
            Console.ReadKey();
        }
        public void DisplayRoomTable()
        {
            var roomTable = new Table();
            roomTable.AddColumns("Rumsnummer", "Våning", "Status");
            foreach (var room in dbContext.Rooms)
            {
                roomTable.AddRow(room.RoomNumber.ToString(), room.Floor.ToString(), room.IsBooked.ToString());
            }
            AnsiConsole.Write(roomTable);
            Console.ReadKey();
        }
        public void DisplayBookingTable()
        {
            var bookingTable = new Table();
            bookingTable.AddColumns("Incheckningsdatum", "Utcheckningsdatum", "Antal vuxna", "Antal barn");
            foreach (var booking in dbContext.Bookings)
            {
                bookingTable.AddRow(booking.CheckInDate, booking.CheckOutDate, booking.NumAdults.ToString(), booking.NumChildren.ToString());
            }
            AnsiConsole.Write(bookingTable);
            AnsiConsole.MarkupLine("[green]Bokningstabell visad![/]");
            AnsiConsole.MarkupLine("[yellow]Tryck på valfri tangent för att fortsätta...[/]");
            Console.ReadKey();

        }
    }
}
