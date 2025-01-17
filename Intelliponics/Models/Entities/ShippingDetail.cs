using System.ComponentModel.DataAnnotations;

namespace Intelliponics.Models.Entities
{
    public class ShippingDetail
    {
        [Key]
        public int ShippingID { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime ShippingDate { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }

        // Navigation Property
        public ICollection<Order> Orders { get; set; }
    }

}
