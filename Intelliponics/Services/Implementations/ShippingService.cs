using Intelliponics.Models.Entities;
using Intelliponics.Repositories.Interfaces;
using Intelliponics.Services.Interfaces;

namespace Intelliponics.Services.Implementations
{
    public class ShippingService : IBaseService<ShippingDetail>, IShippingService
    {
        private readonly IShippingRepository _shippingRepo;
        public ShippingService(IShippingRepository shippingRepo)
        {
            _shippingRepo = shippingRepo;
        }
        public async Task<bool> CreateAsync(ShippingDetail entity)
        {
            return await _shippingRepo.AddAsync(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _shippingRepo.DeleteAsync(id);
        }
        public async Task<IEnumerable<ShippingDetail>> GetAllAsync()
        {
            return await _shippingRepo.GetAllAsync();
        }

        public Task<ShippingDetail> GetByIdAsync(int id)
        {
            return _shippingRepo.GetByIdAsync(id);
        }

        public Task<IEnumerable<ShippingDetail>> GetShippingDetailsByCountryAsync(string country)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(int id, ShippingDetail entity)
        {
            return _shippingRepo.UpdateAsync(id, entity);
        }
    }
}
