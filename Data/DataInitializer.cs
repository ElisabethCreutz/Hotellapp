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
            SeedCustomers(dbContext);
            dbContext.SaveChanges();
        }
        private void SeedRooms(ApplicationDbContext dbContext)
        {
            if (!dbContext.Rooms.Any())
            {
                dbContext.Rooms.AddRange(new Room
                {
                    Floor = 1,
                    RoomNumber = 101,
                    Type = RoomType.Single,
                    Status = RoomStatus.Available,
                    PricePerNight = 1000m
                },
                new Room
                {
                    Floor = 2,
                    RoomNumber = 201,
                    Type = RoomType.Single,
                    Status = RoomStatus.Available,
                    PricePerNight = 1000m
                },
                new Room
                {
                    Floor = 3,
                    RoomNumber = 301,
                    Type = RoomType.Double,
                    RoomSize = 12,
                    ExtraBeds = 1,
                    Status = RoomStatus.Available, 
                    PricePerNight = 1200m
                },
                new Room
                {
                    Floor = 4,
                    RoomNumber = 401,
                    Type = RoomType.Double,
                    RoomSize = 18,
                    ExtraBeds = 2,
                    Status = RoomStatus.Available,
                    PricePerNight = 1800m
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
