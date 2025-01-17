using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Intelliponics.Models.Entities
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        public int? CustomerID { get; set; }
        public int? PaymentID { get; set; }
        public int? ShippingID { get; set; }
        public decimal Discount { get; set; }
        public decimal Taxes { get; set; }
        public decimal TotalAmount { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime OrderDate { get; set; }
        public bool Dispatched { get; set; }
        public DateTime? DispatchedDate { get; set; }
        public bool Shipped { get; set; }
        public DateTime? ShippingDate { get; set; }
        public bool Deliver { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string? Notes { get; set; }
        public bool CancelOrder { get; set; }

        // Navigation Properties
        [ForeignKey("CustomerID")]
        public Customer? Customer { get; set; }

        [ForeignKey("PaymentID")]
        public Payment? Payment { get; set; }

        [ForeignKey("ShippingID")]
        public ShippingDetail? ShippingDetails { get; set; }
    }

}
