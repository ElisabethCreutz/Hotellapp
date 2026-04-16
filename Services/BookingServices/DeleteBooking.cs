using HotelEC.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelEC.Services.BookingServices
{
    public class DeleteBooking
    {
        public ApplicationDbContext dbContext { get; set; }
        public DeleteBooking(ApplicationDbContext db)
        {
            dbContext = db;
        }
        public void Run()
        {

        }
    }
}
