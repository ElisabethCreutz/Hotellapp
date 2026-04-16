using Bogus;
using HotelEC.Models;
using HotelEC.Models.RoomModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelEC.Data
{
    public class DataInitializer
    {
        public void MigrateAndSeed(ApplicationDbContext dbContext)
        {
            dbContext.Database.Migrate();
            SeedRooms(dbContext);
            SeedCustomers(dbContext);//fortsätt jobba på detta
            dbContext.SaveChanges();
        }
        private void SeedRooms(ApplicationDbContext dbContext)
        {
            if (!dbContext.Rooms.Any())
            {
                dbContext.Rooms.AddRange(new Room
                {
                    Floor = 1,
                    
                    RoomNumber = 101
                },
                new Room
                {
                    Floor = 2,
                    
                    RoomNumber = 201
                },
                new Room
                {
                    Floor = 3,
                    
                    RoomNumber = 301
                },
                new Room
                {
                    Floor = 4,
                    
                    RoomNumber = 401
                }
                );
            }
        }
        private void SeedCustomers(ApplicationDbContext dbContext)
        {
            
            if (!dbContext.Customers.Any())
            {
                var customers = BogusCustomers.Create(10);
                dbContext.Customers.AddRange(customers);
            }
        }
       
    }
}
