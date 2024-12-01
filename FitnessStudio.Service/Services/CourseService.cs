using FitnessProject.Entities;
using System.Linq.Expressions;
using FitnessStudio.Service;
using FitnessStudio.Core.Interfaces;
using FitnessStudio.Core.Interfaces.servcieInterface;


namespace FitnessProject.Services
{
    public class CourseService : ICourseService
    {
        readonly IRepository<CourseEntity> _courseService;

        public CourseService(IRepository<CourseEntity> courseService)
        {
            _courseService = courseService;
        }
        public List<CourseEntity>? GetAll()
        {
            return _courseService.GetAllDB();
        }
        public CourseEntity GetByID(int id)
        {
            var data = _courseService.GetAllDB();
            if (data == null || data.FindIndex(c => c.Id == id) == -1)
                return null;
            return _courseService.GetByIdDB(id);
        }
        public bool AddCourse(CourseEntity Coursedb)
        {
            var data = _courseService.GetAllDB();
            if (data == null)
                return false;
            if (data.Find(c => c.Id == Coursedb.Id) != null)
                return false;
            return _courseService.AddDB(Coursedb);
        }

        public bool UpdateCourse(int id, CourseEntity coursedb)
        {
            var data = _courseService.GetAllDB();
            if (data == null || data.Find(c => c.Id == id) == null)
                return false;
            return _courseService.UpdateDB(id, coursedb);
        }
        public bool DeleteCourse(int id)
        {
            if (id < 0)
                return false;
            var data = _courseService.GetAllDB();
            if (data == null || data.Find(c => c.Id == id) == null)
                return false;
            return _courseService.DeleteDB(id);
        }

    }
}
