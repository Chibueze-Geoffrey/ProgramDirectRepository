using Microsoft.EntityFrameworkCore;
using ProgramDirect.Application.Interfaces;
using ProgramDirect.Domain.Entities;
using ProgramDirect.Infrastruture.Data;
using System.Linq.Expressions;

namespace ProgramDirect.Infrastruture.Implementations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        public DbSet<T> _entityDbSet { get; set; }

        public GenericRepository(ProgramDirectDbContext dbContext)
        {
            _entityDbSet = dbContext.Set<T>();
        }

        public void Add(T entity)
        {
            _entityDbSet.Add(entity);
        }

        public void AddRange(List<T> entities)
        {
            _entityDbSet.AddRange(entities);
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, object>>[] includes = null)
        {
            IQueryable<T> query = _entityDbSet.AsQueryable();

            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }

            return await query.FirstOrDefaultAsync(predicate);
        }

        public async Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, Expression<Func<T, object>>[] includes = null)
        {
            IQueryable<T> query = _entityDbSet.AsQueryable();

            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return query;
        }

        public void Update(T entity)
        {
            entity.UpdatedDate = DateTime.Now;

            _entityDbSet.Update(entity);
        }

        public void Delete(T entity)
        {
            _entityDbSet.Remove(entity);
        }
    }
}
