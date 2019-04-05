using EntityFramework_CodeFirst.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.RoomService
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
