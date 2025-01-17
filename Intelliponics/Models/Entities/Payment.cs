using System.ComponentModel.DataAnnotations;

namespace Intelliponics.Models.Entities
{
    public class Payment
    {
        [Key]
        public int PaymentID { get; set; }
        public int CustomerID { get; set; }
        public string PaymentType { get; set; }
        public string Status { get; set; }
        public DateTime PaymentDate { get; set; }
        public string Notes { get; set; }

        // Navigation Property
        public ICollection<Order> Orders { get; set; }
    }

}
