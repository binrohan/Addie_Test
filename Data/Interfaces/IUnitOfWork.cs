using Addie.Models;

namespace Addie.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<T> Repository<T>() where T : BaseEntity;
        Task<int> Complete();
        int SaveChanges();
    }
}