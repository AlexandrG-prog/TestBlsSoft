using DAL.Abstract;
using DAL.Entities;
using DAL.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq;

namespace DAL.Concrete
{
    public class Repository : IRepository
    {
        private PostgreDataContext _dbContext;

        public Repository(PostgreDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<StarSystem> StarSystems => _dbContext.StarSystems;

        public IQueryable<SpaceObject> SpaceObjects => _dbContext.SpaceObjects;

        public void Save<T>(T entity, bool saveChanges = true) where T : Entity
        {
            _dbContext.Set<T>().Update(entity);

            if (saveChanges)
                SaveChanges();
        }

        public void Delete<T>(T entity, bool saveChanges = true) where T : Entity
        {
            _dbContext.Set<T>().Remove(entity);

            if (saveChanges)
                SaveChanges();
        }

        /// <summary>
        /// Сохранение изменений в БД
        /// </summary>
        private void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public EntityEntry<T> GetEntryEntity<T>(T entity) where T : Entity
        {
            return _dbContext.Entry<T>(entity);
        }
    }
}
