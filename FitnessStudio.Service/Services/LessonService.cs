using FitnessProject.Entities;
using FitnessStudio.Core.Interfaces;
using FitnessStudio.Core.Interfaces.servcieInterface;
namespace FitnessProject.Services
{
    public class LessonService : ILessonService
    {
        readonly IRepository<LessonEntity> _lessonService;

        public LessonService(IRepository<LessonEntity> lessonService)
        {
            _lessonService = lessonService;
        }
        public List<LessonEntity>? GetAll()
        {
            return _lessonService.GetAllDB();
        }
        public LessonEntity GetByID(int id)
        {
            var data = _lessonService.GetAllDB();
            if (data == null || data.FindIndex(c => c.Id == id) == -1)
                return null;
            return _lessonService.GetByIdDB(id);
        }
        public bool AddLesson(LessonEntity Lessondb)
        {
            var data = _lessonService.GetAllDB();
            if (data == null)
                return false;
            if (data.Find(c => c.Id == Lessondb.Id) != null)
                return false;
            return _lessonService.AddDB(Lessondb);
        }

        public bool UpdateLesson(int id, LessonEntity lessondb)
        {
            var data = _lessonService.GetAllDB();
            if (data == null || data.Find(c => c.Id == id) == null)
                return false;
            return _lessonService.UpdateDB(id, lessondb);
        }
        public bool DeleteLesson(int id)
        {
            if (id < 0)
                return false;
            var data = _lessonService.GetAllDB();
            if (data == null || data.Find(c => c.Id == id) == null)
                return false;
            return _lessonService.DeleteDB(id);
        }
    }
}
