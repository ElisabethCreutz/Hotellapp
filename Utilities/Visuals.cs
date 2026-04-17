using Spectre.Console;

namespace HotelEC.Utilities
{
    public class Visuals
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
            };
            AnsiConsole.Write(panel);
        }
    }
}
