using HotelEC.Data;
using HotelEC.Utilities.Menus;

namespace HotelEC
{
    public class App
    {
        public static void Run()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            var factory = new ApplicationContextFactory();
            var dbContext = factory.CreateDbContext(new string[0]);

            var dataInitiaizer = new DataInitializer();
            dataInitiaizer.MigrateAndSeed(dbContext);

            MainMenu.RunMenu(dbContext);
        }
    }
}