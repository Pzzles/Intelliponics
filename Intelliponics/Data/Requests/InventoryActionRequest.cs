using Intelliponics.Models.Entities;

namespace Intelliponics.Data.Request
{
    public class InventoryActionRequest
    {
        public string Action { get; set; }
        public int Page { get; set; }
        public int ItemsPerPage { get; set; }
        public Product Product { get; set; }
    }
}