using Intelliponics.Models.Entities;
using Intelliponics.Repositories.Implementations;
using Intelliponics.Repositories.Interfaces;
using Intelliponics.Services.Interfaces;

namespace Intelliponics.Services.Implementations
{
    public class ProductService : IProductService, IBaseService<Product>
    {
        private readonly IProductRepository _productRepo;
        private readonly ILogger<ProductService> _logger;

        public ProductService(IProductRepository productRepo, ILogger<ProductService> logger)
        {
            _productRepo = productRepo;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<bool> CreateAsync(Product entity)
        {
            entity.CreatedDateTime = DateTime.UtcNow;
            entity.LastUpdatedDateTime = DateTime.UtcNow;
            return await _productRepo.AddAsync(entity);
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            try 
            {
                return await _productRepo.GetAllAsync();
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public Task<Product> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(int id, Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
