using HotelEC.Data;
using HotelEC.Models.BookingModels;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Runtime.Intrinsics.X86;
using System.Text;

namespace HotelEC.Services.BookingServices
{

    public class BookingService
    {
        public ApplicationDbContext dbContext { get; set; }
        public BookingService(ApplicationDbContext db)
        {
            dbContext = db;
        }
        public void CreateBooking()
        {
            dbContext.Bookings.Add(new Booking
                {
                CheckInDate = DateTime.Now.ToShortDateString(),
                //CheckOutDate=**,
                //GuestId=**,
                //NumAdults=**
            });
        }
        public void UpdateBooking(Booking booking)
        {
        }
        public void DeleteBooking() { }
        public void GetBooking(int id) { }
        public void GetAllBookings() { }

        public void SearchBookings()
        {
            //            Enabling Search
            //Use EnableSearch() to let users type and filter the list instantly - essential for long lists.

            var bookings = new[]
            {
        "Booking1", "booking2"
};

            var booking = AnsiConsole.Prompt(
    new SelectionPrompt<string>()
        .Title("Välj bokning:")
        .PageSize(10)
        .EnableSearch()
        .SearchPlaceholderText("Skriv för att söka...")
        .AddChoices(bookings));

            AnsiConsole.MarkupLine($"Du valde: [blue]{booking}[/]");
        }
    }
}
