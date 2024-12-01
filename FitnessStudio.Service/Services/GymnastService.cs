//using FitnessStudio.Data;
using FitnessStudio.Core.Interfaces;
using FitnessProject.Entities;
using System.Linq.Expressions;
using FitnessStudio.Service;
using FitnessStudio.Core.Interfaces.servcieInterface;

namespace FitnessProject.Services
{
    public class GymnastService : IGymnastService
    {
        readonly IRepository<GymnastEntity> _gymnastService;

        public GymnastService(IRepository<GymnastEntity> gymnastService)
        {
            _gymnastService = gymnastService;
        }
        public List<GymnastEntity>? GetAll()
        {
            return _gymnastService.GetAllDB();
        }
        public GymnastEntity GetByID(int id)
        {
            var data = _gymnastService.GetAllDB();
            if (data == null || data.FindIndex(c => c.Id == id) == -1)
                return null;
            return _gymnastService.GetByIdDB(id);
        }
        public bool AddGymnast(GymnastEntity gymnastdb)
        {
            var data = _gymnastService.GetAllDB();
            if(data == null)
               return false;
            if ( data.Find(c => c.Id == gymnastdb.Id) != null || !ValidationCheck.IsValidID(gymnastdb.Id.ToString()) || !ValidationCheck.IsValidEmail(gymnastdb.Email))
                return false;
            return _gymnastService.AddDB(gymnastdb);
        }
       
        public bool UpdateGymnast(int id, GymnastEntity gymnastdb)
        {
            var data = _gymnastService.GetAllDB();
            if (data == null || data.Find(c => c.Id == id) == null)
                return false;
            return _gymnastService.UpdateDB(id, gymnastdb);
        }
        public bool DeleteGymnast(int id)
        {
            if (id < 0) 
                return false;
            var data = _gymnastService.GetAllDB();
            if(data == null || data.Find(c => c.Id == id) == null )
                return false;
            return _gymnastService.DeleteDB(id);
        }

    }
}

