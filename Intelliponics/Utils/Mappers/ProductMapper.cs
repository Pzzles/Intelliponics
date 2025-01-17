using Intelliponics.Models.Entities;
using Intelliponics.Models.ViewModels;


namespace Intelliponics.Utilities
{
    public static class ProductMapper
    {
        public static ProductViewModel ToViewModel(Product product)
        {
            return new ProductViewModel
            {
                ProductID = product.ProductID,
                Name = product.Name,
                //Category = product.Category.Name,
                UnitInStock = product.UnitInStock,
                ProductAvailable = product.ProductAvailable,
                LastUpdated = product.LastUpdatedDateTime
            };
        }
    }
}
