using HotelEC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Text;

namespace HotelEC.Data
{
    public class ApplicationDbContext : DbContext
    {
        // DbSet-skikt för att representera tabellerna i databasen.
        // Varje DbSet skapar en "tabell" i databasen för respektive typ.
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Booking> Booking { get; set; }
        public DbSet<Room> Room { get; set; }
        //public DbSet<Floor> Floor { get; set; }
        //public DbSet<Payment> Payment { get; set; }
        //public DbSet<RoomClass> RoomClass { get; set; }
        //public DbSet<RoomStatus> RoomStatus { get; set; }
        //public DbSet<BedType> BedType { get; set; }
        //public DbSet<RoomClassBedType> RoomClassBedType { get; set; }
        //public DbSet<BookingRoom> BookingRoom { get; set; }
        //public DbSet<Addon> Addon { get; set; }


        /// <summary>
        /// Tom konstruktor: Denna tomma konstruktor behövs om du vill använda migrations
        /// (dvs. skapa databasen stegvis baserat på ändringar i datamodellen).
        /// </summary>
        public ApplicationDbContext()
        {
        }

        /// <summary>
        /// Konstruktor med alternativ (options):
        /// Denna konstruktor tar in inställningar som skickas från appens konfiguration,
        /// t.ex. anslutningssträngen.
        /// </summary>
        /// <param name="options"></param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

    }
}
