using FitnessProject.Entities;
using FitnessStudio.Core.Interfaces;
using FitnessStudio.Core.Interfaces.servcieInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessStudio.Data.Repository
{
    public class CourseRepository:IRepository<CourseEntity>
    {
        readonly DataContext _dataContext;
        public CourseRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public List<CourseEntity> GetAllDB()
        {
            return _dataContext.CourseList;
        }
        public CourseEntity GetByIdDB(int id)
        {
            return _dataContext.CourseList.Where(c => c.Id == id).FirstOrDefault();
        }
        public bool AddDB(CourseEntity course)
        {
            try
            {
                _dataContext.CourseList.Add(course);
                _dataContext.SaveChange();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool UpdateDB(int id, CourseEntity course)
        {
            try
            {
                int index = _dataContext.CourseList.FindIndex(c => c.Id == id);
                _dataContext.CourseList[index] = course;
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
                int index = _dataContext.CourseList.FindIndex(c => c.Id == id);
                _dataContext.CourseList.Remove(_dataContext.CourseList[index]);
                return true;
            }

            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
