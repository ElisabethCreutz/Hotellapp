using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelEC.Utilities
{
    internal class SpectreTables
    {

        public void DisplayCustomerTable()
        {
            // Här kan du implementera logiken för att visa en tabell med Spectre.Console
            // Exempel:
            var CustTable = new Table();
            CustTable.AddColumn("Name");
            CustTable.AddColumn("Address");
            CustTable.AddRow("Row 1, Cell 1", "Row 1, Cell 2");
            CustTable.AddRow("Row 2, Cell 1", "Row 2, Cell 2");
            AnsiConsole.Write(CustTable);
        }
        public void DisplayRoomTable() 
        { 
            var RoomTable = new Table();
            RoomTable.AddColumn("Name");
            RoomTable.AddColumn("Floor");
            RoomTable.AddRow("db.name1", "db.floor1");
        }

    }
}
