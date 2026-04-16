using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelEC.Utilities
{
    internal class Visuals
    {
        public static void DisplayTitle()
        {
            AnsiConsole.MarkupLine("[bold blue]Välkommen till Gamla Bettans knasiga hotell![/]");
        }
    }
}
