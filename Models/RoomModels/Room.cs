using System;
using System.Collections.Generic;
using System.Text;

namespace HotelEC.Models.RoomModels
{
    public class Room
    {
        public int Id { get; set; }
        public int FloorId { get; set; }
        //public Floor floor { get; set; }
        public int StatusId { get; set; }
        public int RoomNumber { get; set; }
        
    }
}
