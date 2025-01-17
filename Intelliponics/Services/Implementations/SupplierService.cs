using Intelliponics.Models.Entities;
using Intelliponics.Repositories.Interfaces;
using Intelliponics.Services.Interfaces;

namespace Intelliponics.Services.Implementations
{
    public class SupplierService : IBaseService<Supplier>, ISupplierService
    {
        private readonly ISupplierRepository _supplierRepo;
        public Task<bool> CreateAsync(Supplier entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Supplier>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Supplier> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(int id, Supplier entity)
        {
            throw new NotImplementedException();
        }
    }
}
