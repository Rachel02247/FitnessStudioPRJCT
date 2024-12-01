using FitnessProject.Entities;
using FitnessStudio.Core.Interfaces;
using FitnessStudio.Service;
using FitnessStudio.Core.Interfaces.servcieInterface;
namespace FitnessProject.Services
{
    public class TrainerService : ITrainerService
    {
        readonly IRepository<TrainerEntity> _trainerService;

        public TrainerService(IRepository<TrainerEntity> trainerService)
        {
            _trainerService = trainerService;
        }
        public List<TrainerEntity>? GetAll()
        {
            return _trainerService.GetAllDB();
        }
        public TrainerEntity GetByID(int id)
        {
            var data = _trainerService.GetAllDB();
            if (data == null || data.FindIndex(c => c.Id == id) == -1)
                return null;
            return _trainerService.GetByIdDB(id);
        }
        public bool AddTrainer(TrainerEntity Trainerdb)
        {
            var data = _trainerService.GetAllDB();
            if (data == null)
                return false;
            if (data.Find(c => c.Id == Trainerdb.Id) != null || !ValidationCheck.IsValidID(Trainerdb.Id.ToString()) || !ValidationCheck.IsValidEmail(Trainerdb.Email))
                return false;
            return _trainerService.AddDB(Trainerdb);
        }

        public bool UpdateTrainer(int id, TrainerEntity trainerdb)
        {
            var data = _trainerService.GetAllDB();
            if (data == null || data.Find(c => c.Id == id) == null)
                return false;
            return _trainerService.UpdateDB(id, trainerdb);
        }
        public bool DeleteTrainer(int id)
        {
            if (id < 0)
                return false;
            var data = _trainerService.GetAllDB();
            if (data == null || data.Find(c => c.Id == id) == null)
                return false;
            return _trainerService.DeleteDB(id);
        }

    }
}
