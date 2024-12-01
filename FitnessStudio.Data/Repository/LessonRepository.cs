using FitnessProject.Entities;
using FitnessStudio.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessStudio.Data.Repository
{
    public class LessonRepository :IRepository<LessonEntity>
    {
        readonly DataContext _dataContext;
        public LessonRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public List<LessonEntity> GetAllDB()
        {
            return _dataContext.LessontList;
        }
        public LessonEntity GetByIdDB(int id)
        {
            return _dataContext.LessontList.Where(c => c.Id == id).FirstOrDefault();
        }
        public bool AddDB(LessonEntity lesson)
        {
            try
            {
                _dataContext.LessontList.Add(lesson);
                _dataContext.SaveChange();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool UpdateDB(int id, LessonEntity lesson)
        {
            try
            {
                int index = _dataContext.LessontList.FindIndex(c => c.Id == id);
                _dataContext.LessontList[index] = lesson;
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
                int index = _dataContext.LessontList.FindIndex(c => c.Id == id);
                _dataContext.LessontList.Remove(_dataContext.LessontList[index]);
                return true;
            }

            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
