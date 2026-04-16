using HotelEC.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelEC.Services.BookingServices
{
    internal class UpdateBooking:ICrud
    {
        public ApplicationDbContext dbContext { get; set; }
        public UpdateBooking(ApplicationDbContext db)
        {
            dbContext = db;
        }
        public void Run() 
        {
        
        }
    }
}
