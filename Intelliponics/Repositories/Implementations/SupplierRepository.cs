using Intelliponics.Data;
using Intelliponics.Models.Entities;
using Intelliponics.Repositories.Interfaces;

namespace Intelliponics.Repositories.Implementations
{
    public class SupplierRepository : BaseRepository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(AppDbContext context, ILogger<SupplierRepository> logger) : base(context, logger) { }

        public Task<bool> AddAsync(Customer entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(int id, Customer entity)
        {
            throw new NotImplementedException();
        }
    }

}
