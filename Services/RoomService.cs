using HotelEC.Models.RoomModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelEC.Services
{
    internal class RoomService
    {
        public List<Room> Rooms { get; set; }
        public Room _room;

        //CRUD rooms
        public RoomService() { }
        public void CreateRoom() { 
            var room = new Room();

        }
        public void UpdateRoom() { }
        public void DeleteRoom() { }
        public Room GetRoom(int id) {
            return Rooms.Find(r => r.Id == id);
        }
        public List<Room> GetAllRooms() { return Rooms; }
       
    }
}
