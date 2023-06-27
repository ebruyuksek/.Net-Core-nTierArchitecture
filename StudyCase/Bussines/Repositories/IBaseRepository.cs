using Microsoft.EntityFrameworkCore;
using StudyCaseWebApp.DAL.Models;
using System.Linq.Expressions;

namespace Bussines.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        T Get(object id);
        T Get(Expression<Func<T, bool>> predicate);
        List<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(object id);
        void Dispose();
    }
}
