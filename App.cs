using HotelEC.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelEC
{
    public class App
    {
        public void Run() {

            // Hämta en ny dbContext från vår nya klass ApplicationContextFactory!
            var factory = new ApplicationContextFactory();
            var dbContext = factory.CreateDbContext(new string[0]);

            // Anpassad!
            // Migrate & Seed databasen!
            var dataInitiaizer = new DataInitializer();
            dataInitiaizer.MigrateAndSeed(dbContext);

            //var menu=MainMenu.GetMenu();

        }
    }
}
