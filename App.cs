using HotelEC.Data;
using HotelEC.Utilities.Menus;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelEC
{
    public class App
    {
        public static void Run()
        {

            var factory = new ApplicationContextFactory();
            var dbContext = factory.CreateDbContext(new string[0]);

            
            var dataInitiaizer = new DataInitializer();
            dataInitiaizer.MigrateAndSeed(dbContext);

            MainMenu.RunMenu(dbContext);
            
        }
    }
}
