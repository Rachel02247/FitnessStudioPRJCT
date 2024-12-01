using FitnessProject.Entities;
using FitnessStudio.Core.Interfaces.servcieInterface;
using FitnessStudio.Core.Interfaces;

namespace FitnessProject.Services
{
    public class RoomService : IRoomService
    {
        readonly IRepository<RoomEntity> _roomService;

        public RoomService(IRepository<RoomEntity> roomService)
        {
            _roomService = roomService;
        }
        public List<RoomEntity>? GetAll()
        {
            return _roomService.GetAllDB();
        }
        public RoomEntity GetByID(int id)
        {
            var data = _roomService.GetAllDB();
            if (data == null || data.FindIndex(c => c.Id == id) == -1)
                return null;
            return _roomService.GetByIdDB(id);
        }
        public bool AddRoom(RoomEntity Roomdb)
        {
            var data = _roomService.GetAllDB();
            if (data == null)
                return false;
            if (data.Find(c => c.Id == Roomdb.Id) != null)
                return false;
            return _roomService.AddDB(Roomdb);
        }

        public bool UpdateRoom(int id, RoomEntity roomdb)
        {
            var data = _roomService.GetAllDB();
            if (data == null || data.Find(c => c.Id == id) == null)
                return false;
            return _roomService.UpdateDB(id, roomdb);
        }
        public bool DeleteRoom(int id)
        {
            if (id < 0)
                return false;
            var data = _roomService.GetAllDB();
            if (data == null || data.Find(c => c.Id == id) == null)
                return false;
            return _roomService.DeleteDB(id);
        }
    }
}
