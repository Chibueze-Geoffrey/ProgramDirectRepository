using ProgramDirect.Domain.Entities;

namespace ProgramDirect.Application.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepository<T> Repository<T>() where T : BaseEntity;
        Task SaveChangesAsync();
    }
}
