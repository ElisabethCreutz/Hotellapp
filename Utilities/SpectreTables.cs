using HotelEC.Data;
using HotelEC.Models.RoomModels;
using Microsoft.EntityFrameworkCore;
using Spectre.Console;

namespace HotelEC.Utilities
{
    public class SpectreTables
    {
        public ApplicationDbContext dbContext { get; set;  }


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
        }
        public void DisplayRoomTable()
        {
            var roomTable = new Table();
            roomTable.AddColumns("Rumsnummer", "Våning", "Status");
            foreach (var room in dbContext.Rooms)
            {
                roomTable.AddRow(room.RoomNumber.ToString(), room.FloorId.ToString(), room.StatusId.ToString());
            }
        }
    }
}
