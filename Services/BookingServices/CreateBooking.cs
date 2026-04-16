using HotelEC.Data;
using System.Globalization;
using HotelEC.Utilities;
using HotelEC.Models.BookingModels;

namespace HotelEC.Services.BookingServices
{
    internal class CreateBooking : ICrud
    {
        public ApplicationDbContext dbContext { get; set; }
        public CreateBooking(ApplicationDbContext db)
        {
            dbContext = db;
        }
        public void Run()
        {
            CalendarClass.DisplayCalendar();
            var booking= new Booking();

        }
    }
}
