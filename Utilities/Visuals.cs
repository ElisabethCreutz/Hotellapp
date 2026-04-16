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
            var figlet = new FigletText("Gamla Bettans BoutiqueHotel")
            {
                Color = Color.Green,
                Justification = Justify.Center
            };

            var panel = new Panel(figlet)
            {
                Border = BoxBorder.Rounded,
                BorderStyle = new Style(Color.Green),
                //Padding = new Padding(1, 1, 1, 1)
            };

            AnsiConsole.Write(panel);
        }
        public static void DisplayShorttitle()
        {
            var figlet = new FigletText("G B B H")
            {
                Color = Color.Green,
                Justification = Justify.Center
            };

            var panel = new Panel(figlet)
            {
                Border = BoxBorder.Rounded,
                BorderStyle = new Style(Color.Green),
                //Padding = new Padding(1, 1, 1, 1)
            };

            AnsiConsole.Write(panel);
        }
        }
}
