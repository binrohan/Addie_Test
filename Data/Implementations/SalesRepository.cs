using Addie.Data.Interfaces;
using Addie.Models;
using Microsoft.EntityFrameworkCore;

namespace Addie.Data.Implementations
{
    public class SalesRepository : ISalesRepository
    {
        private readonly DataContext _context;
        public SalesRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Sales> GetSaleDetailsAsync(int id)
        {
            var sales = await _context.Sales
                                     .Include(s => s.SalesDetails)
                                     .FirstOrDefaultAsync(s => s.Id == id);

            return sales;
        }
    }
}