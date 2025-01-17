using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Intelliponics.Models.Entities 
{
    public class Supplier
    {
        [Key]
        public int SupplierID { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        // Navigation Property
        public ICollection<Product> Products { get; set; }
    }
}
