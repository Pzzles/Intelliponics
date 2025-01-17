using Intelliponics.Data;
using Intelliponics.Models.Entities;
using Intelliponics.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Intelliponics.Repositories.Implementations
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(AppDbContext context, ILogger<OrderRepository> logger) : base(context, logger) { }

        public async Task<IEnumerable<Order>> GetOrdersByCustomerAsync(string customerId)
        {
            return await _dbSet.Where(o => o.CustomerID == int.Parse(customerId)).ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetOrdersByStatusAsync(bool isCompleted)
        {
            return await _dbSet.Where(o => o.IsCompleted == isCompleted).ToListAsync();
        }
    }
}
