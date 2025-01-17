using Intelliponics.Data;
using Intelliponics.Models.Entities;
using Intelliponics.Repositories.Interfaces;

namespace Intelliponics.Repositories.Implementations
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context, ILogger<ProductRepository> logger)
            : base(context, logger) { }

    }
}
