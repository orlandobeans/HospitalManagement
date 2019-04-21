using HMS.Core.Domain;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HMS.Service.RoomService
{
    public class RoomService : IRoomService
    {
        private IRepository<Room> _roomRepository;

        public RoomService(IRepository<Room> roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public void DeleteRoom(long id)
        {
            _roomRepository.Delete(id);
        }

        public Room Find(params object[] keyValues)
        {
            return _roomRepository.Find(keyValues);
        }

        public Room GetRoom(long id)
        {
            return _roomRepository.GetById(id);
        }

        public IEnumerable<Room> GetRooms()
        {
            return _roomRepository.GetAll;
        }

        public void InsertRoom(Room room)
        {
            _roomRepository.Insert(room);
        }

        public void UpdateRoom(Room room)
        {
            _roomRepository.Update(room);
        }
    }
}
