using System;
using System.Collections.Generic;
using System.Text;

namespace HotelEC.Models.RoomModels
{
    public class Room
    {
        public int Id { get; set; }
        public int Floor { get; set; }
        public bool IsBooked { get; set; }
        public int RoomNumber { get; set; }
        public string RoomType { get; set; }
    }
}
