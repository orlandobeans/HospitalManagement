using HMS.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HMS.Service.RoomService
{
    public interface IRoomService
    {
        IEnumerable<Room> GetRooms();
        Room GetRoom(long id);
        void InsertRoom(Room room);
        void UpdateRoom(Room room);
        void DeleteRoom(long id);
        Room Find(params object[] keyValues);
    }
}
