using Eternity.DataProvider.Data;
using Eternity.DataProvider.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Eternity.DataProvider.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _dbContext;
        private readonly DbSet<T> _entitySet;
        public BaseRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _entitySet = dbContext.Set<T>();
        }
        public void Create(T entity) => _dbContext.Add(entity);

        public void Delete(T entity) => _dbContext.Remove(entity);

        public IQueryable<T> GetAll() => _entitySet.AsQueryable();

        public void Update(T entity) => _dbContext.Update(entity);
    }
}
