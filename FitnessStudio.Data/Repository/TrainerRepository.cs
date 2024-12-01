using FitnessStudio.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessProject.Entities;

namespace FitnessStudio.Data.Repository
{
    public class TrainerRepository : IRepository<TrainerEntity>
    {
        readonly DataContext _dataContext;
        public TrainerRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public List<TrainerEntity> GetAllDB()
        {
            return _dataContext.TrainerList;
        }
        public TrainerEntity GetByIdDB(int id)
        {
            return _dataContext.TrainerList.Where(c => c.Id == id).FirstOrDefault();
        }
        public bool AddDB(TrainerEntity Trainer)
        {
            try
            {
                _dataContext.TrainerList.Add(Trainer);
                _dataContext.SaveChange();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool UpdateDB(int id, TrainerEntity Trainer)
        {
            try
            {
                int index = _dataContext.TrainerList.FindIndex(c => c.Id == id);
                _dataContext.TrainerList[index] = Trainer;
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
                int index = _dataContext.TrainerList.FindIndex(c => c.Id == id);
                _dataContext.TrainerList.Remove(_dataContext.TrainerList[index]);
                return true;
            }

            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
