using ProgramDirect.Application.Interfaces;
using ProgramDirect.Domain.Entities;
using ProgramDirect.Infrastruture.Data;

namespace ProgramDirect.Infrastruture.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProgramDirectDbContext _dbContext;
        private Dictionary<string, object> Repositories { get; set; } = new Dictionary<string, object>();

        public UnitOfWork(ProgramDirectDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IGenericRepository<T> Repository<T>() where T : BaseEntity
        {
            if (Repositories.ContainsKey(typeof(T).Name)) return (GenericRepository<T>)Repositories[typeof(T).Name];

            Repositories.Add(typeof(T).Name, new GenericRepository<T>(_dbContext));
            return (GenericRepository<T>)Repositories[typeof(T).Name];
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
