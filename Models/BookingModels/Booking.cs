using HotelEC.Models.CustomerModels;
using HotelEC.Models.RoomModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelEC.Models.BookingModels
{
    public class Booking
    {
        public int Id { get; set; }
        public Customer Guest { get; set; }
        public Room Room { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int NumAdults { get; set; }
        public int NumChildren { get; set; }
        public decimal BookingAmount { get; set; }


    }
}
