using Bogus;
using HotelEC.Models;
using HotelEC.Models.RoomModels;
using HotelEC.Utilities;
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
                    FloorId = 1,
                    StatusId = 1,
                    RoomNumber = 101
                },
                new Room
                {
                    FloorId = 2,
                    StatusId = 1,
                    RoomNumber = 201
                },
                new Room
                {
                    FloorId = 3,
                    StatusId = 1,
                    RoomNumber = 301
                },
                new Room
                {
                    FloorId = 4,
                    StatusId = 1,
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
