using Intelliponics.Data;
using Intelliponics.Models.Entities;
using Intelliponics.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Intelliponics.Repositories.Implementations
{
    public class PaymentRepository : BaseRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(AppDbContext context, ILogger<PaymentRepository> logger)
            : base(context, logger) { }


        public async Task<Payment> GetPaymentByCustomerIdAsync(int id)
        {
            try
            {
                return await _dbSet.FirstOrDefaultAsync(p => p.CustomerID == id);
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, $"Error in {nameof(GetByIdAsync)} while fetching entity with ID: {id}");
                throw;
            }
        }


        public async Task<IEnumerable<Payment>> GetPaymentsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _dbSet
                .Where(p => p.PaymentDate >= startDate && p.PaymentDate <= endDate)
                .ToListAsync();
        }
    }
}
