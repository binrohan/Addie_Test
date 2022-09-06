using Addie.Models;

namespace Addie.Data.Interfaces
{
    public interface ISalesRepository
    {
        Task<Sales> GetSaleDetailsAsync(int id);
    }
}