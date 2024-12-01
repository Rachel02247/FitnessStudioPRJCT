using FitnessProject.Entities;
using FitnessStudio.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessStudio.Data.Repository
{
    public class GymnsatRepository: IRepository<GymnastEntity>
    {
        readonly DataContext _dataContext;
        public GymnsatRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public List<GymnastEntity> GetAllDB()
        {
            return _dataContext.GymnastList;
        }
        public GymnastEntity GetByIdDB(int id)
        {
            return _dataContext.GymnastList.Where(c => c.Id == id).FirstOrDefault();
        }

        public bool AddDB(GymnastEntity gymnast)
        {
            try
            {
                _dataContext.GymnastList.Add(gymnast);
                _dataContext.SaveChange();
                return true;
            }
            catch (Exception ex){
                return false;
            }
        }
        public bool UpdateDB(int id,  GymnastEntity gymnast)
        {
            try{
                int index = _dataContext.GymnastList.FindIndex(c => c.Id == id);
                _dataContext.GymnastList[index] = gymnast;
                return true;
            }
            catch(Exception ex){
                return false; 
            }
        }
        public bool DeleteDB(int id)
        {
            try{
                int index = _dataContext.GymnastList.FindIndex(c => c.Id == id);
                _dataContext.GymnastList.Remove(_dataContext.GymnastList[index]);
                return true;
            }

            catch(Exception ex){
                return false;
            }
        }

    }
}
