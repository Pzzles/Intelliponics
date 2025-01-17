using Intelliponics.Models.Entities;
using Intelliponics.Repositories.Interfaces;
using Intelliponics.Services.Interfaces;

namespace Intelliponics.Services.Implementations
{
    public class OrderService : IOrderService, IBaseService<Order>
    {
        private readonly IOrderRepository _orderRepo;

        public OrderService(IOrderRepository orderRepo)
        {
            _orderRepo = orderRepo;
        }
        public async Task<bool> CreateAsync(Order entity)
        {
            return await _orderRepo.AddAsync(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _orderRepo.DeleteAsync(id);
        }

        public Task<IEnumerable<Order>> GetAllAsync()
        {
            return _orderRepo.GetAllAsync();
        }

        public Task<Order> GetByIdAsync(int id)
        {
            return _orderRepo.GetByIdAsync(id);
        }

        public Task<bool> UpdateAsync(int id, Order entity)
        {
            return _orderRepo.UpdateAsync(id, entity);
        }
    }
}
