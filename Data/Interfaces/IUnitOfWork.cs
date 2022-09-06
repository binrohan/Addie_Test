namespace Addie.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<T> Repository<T>();
        Task<int> Complete();
        int SaveChanges();
    }
}