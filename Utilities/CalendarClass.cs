using Spectre.Console;

namespace HotelEC.Utilities
{
    public class CalendarClass
    {
        public DateTime DisplayCalendar()
        {
            //Richards Kod + modifierat
            DateTime selectedDate = DateTime.Now;

            while (true)
            {
                Console.Clear();
                RenderCalendar(selectedDate);

                // Läsa användarens tangent
                var key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.RightArrow:
                        selectedDate = selectedDate.AddDays(1);
                        break;
                    case ConsoleKey.LeftArrow:
                        if (selectedDate.AddDays(-1) >= DateTime.Today)
                            selectedDate = selectedDate.AddDays(-1);
                        break;
                    case ConsoleKey.UpArrow:
                        if (selectedDate.AddDays(-7) >= DateTime.Today)
                            selectedDate = selectedDate.AddDays(-7);
                        break;
                    case ConsoleKey.DownArrow:
                        selectedDate = selectedDate.AddDays(7);
                        break;
                    case ConsoleKey.Enter:
                        AnsiConsole.MarkupLine($"\nDu valde: [green]{selectedDate:yyyy-MM-dd}[/]");
                        return selectedDate;
                }
            }
        }
        static void RenderCalendar(DateTime selectedDate)
        {
            var calendarContent = new StringWriter();

            // Kalenderhuvud
            calendarContent.WriteLine($"[purple]{selectedDate:MMMM}[/]".ToUpper());
            calendarContent.WriteLine("Mån  Tis  Ons  Tor  Fre  Lör  Sön");
            calendarContent.WriteLine("─────────────────────────────────");

            DateTime firstDayOfMonth = new DateTime(selectedDate.Year, selectedDate.Month, 1);
            int daysInMonth = DateTime.DaysInMonth(selectedDate.Year, selectedDate.Month);
            int startDay = (int)firstDayOfMonth.DayOfWeek;
            startDay = (startDay == 0) ? 6 : startDay - 1; // Justera för måndag som veckostart

            // Fyll med tomma platser innan första dagen i månaden
            for (int i = 0; i < startDay; i++)
            {
                calendarContent.Write("     ");
            }

            // Skriv ut dagarna
            for (int day = 1; day <= daysInMonth; day++)
            {
                if (day == selectedDate.Day)
                {
                    // Siffran 2 sätter minimum bredd (även om 1 siffra)
                    calendarContent.Write($"[green]{day,2}[/]   ");
                }
                else
                {
                    calendarContent.Write($"{day,2}   ");
                }

                // Gå till nästa rad efter söndag
                if ((startDay + day) % 7 == 0)
                {
                    calendarContent.WriteLine();
                }
            }

            //Skapa en panel med dubbla kanter
            var panel = new Panel(calendarContent.ToString())
            {
                Border = BoxBorder.Square,
                Header = new PanelHeader(($"[purple]{selectedDate:yyyy}[/]"), Justify.Center),
            };

            AnsiConsole.Write(panel);

            AnsiConsole.MarkupLine("\nAnvänd piltangenter [purple]\u25C4 \u25B2 \u25BA \u25BC[/] för att \nnavigera och [green]Enter[/] för att välja.");
        }

    }
}

