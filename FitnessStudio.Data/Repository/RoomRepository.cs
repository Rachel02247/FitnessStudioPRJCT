using FitnessProject.Entities;
using FitnessStudio.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessStudio.Data.Repository
{
    public class RoomRepository : IRepository<RoomEntity>
    {
        readonly DataContext _dataContext;
        public RoomRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public List<RoomEntity> GetAllDB()
        {
            return _dataContext.RoomList;
        }
        public RoomEntity GetByIdDB(int id)
        {
            return _dataContext.RoomList.Where(c => c.Id == id).FirstOrDefault();
        }
        public bool AddDB(RoomEntity Room)
        {
            try
            {
                _dataContext.RoomList.Add(Room);
                _dataContext.SaveChange();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool UpdateDB(int id, RoomEntity Room)
        {
            try
            {
                int index = _dataContext.RoomList.FindIndex(c => c.Id == id);
                _dataContext.RoomList[index] = Room;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool DeleteDB(int id)
        {
            try
            {
                int index = _dataContext.RoomList.FindIndex(c => c.Id == id);
                _dataContext.RoomList.Remove(_dataContext.RoomList[index]);
                return true;
            }

            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
