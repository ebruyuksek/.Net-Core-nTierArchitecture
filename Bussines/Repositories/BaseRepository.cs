using DAL.Contexts;
using Microsoft.EntityFrameworkCore;
using StudyCaseWebApp.DAL.Models;
using System.Linq;
using System.Linq.Expressions;

namespace Bussines.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private DbSet<T> _dbSet;
        private MainDbContext _context;
        public BaseRepository(MainDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void Add(T entity)
        {
            var entityModel = _context.Entry<T>(entity);
            entityModel.State = EntityState.Added;

            _context.SaveChanges();
        }

        public T Get(object id)
        {
            return _dbSet.Find(id);
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.AsNoTracking().SingleOrDefault(predicate);
        }

        public void Update(T entity)
        {
            var entityModel = _context.Entry<T>(entity);
            _dbSet.Attach(entity);
            entityModel.State = EntityState.Modified;

            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Delete(object id)
        {
            var entityModel = _dbSet.Find(id);
            _dbSet.Remove(entityModel);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public List<T> GetAll()
        {
            return _dbSet.AsNoTracking().ToList();
        }
    }
}
