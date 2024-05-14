using System.Linq.Expressions;

namespace ProgramDirect.Application.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        void Add(T entity);
        void AddRange(List<T> entities);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, object>>[] includes = null);
        Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, Expression<Func<T, object>>[] includes = null);
        void Update(T entity);
        void Delete(T entity);
    }
}
