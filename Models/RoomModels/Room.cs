using System;
using System.Collections.Generic;
using System.Text;
using HotelEC.Repositories;

namespace HotelEC.Models.RoomModels
{
    public class Room
    {
        public int Id { get; set; }
        public int Floor { get; set; }
        public int RoomNumber { get; set; }
        public RoomType Type { get; set; }
        public RoomStatus Status { get; set; }
        public int RoomSize { get; set; } = 12;
        public int ExtraBeds { get; set; } = 0;
        public decimal PricePerNight { get; set; }
        public Room() { }


    }
}
