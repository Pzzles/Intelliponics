using Intelliponics.Data;
using Intelliponics.Models.Entities;
using Intelliponics.Repositories.Interfaces;

namespace Intelliponics.Repositories.Implementations
{
    public class ShippingRepository : BaseRepository<ShippingDetail>, IShippingRepository
    {
        public ShippingRepository(AppDbContext context, ILogger<ShippingRepository> logger)
            : base(context, logger) { }

    }

}
