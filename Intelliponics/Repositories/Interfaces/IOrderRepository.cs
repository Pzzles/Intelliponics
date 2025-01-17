using Intelliponics.Models.Entities;
using Intelliponics.Repositories.Interfaces;

namespace Intelliponics.Repositories.Interfaces
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        Task<IEnumerable<Order>> GetOrdersByCustomerAsync(string customerId);
        Task<IEnumerable<Order>> GetOrdersByStatusAsync(bool isCompleted);
    }

}
