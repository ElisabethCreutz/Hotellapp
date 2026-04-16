using System;
using System.Collections.Generic;
using System.Text;

namespace HotelEC.Models.BookingModels
{
    public class Booking
    {
        public int Id { get; set; }
        public int GuestId { get; set; }
        public string CheckInDate { get; set; }
        public string CheckOutDate { get; set; }
        public int NumAdults { get; set; }
        public int NumChildren { get; set; }
        public decimal BookingAmount { get; set; }


    }
}
