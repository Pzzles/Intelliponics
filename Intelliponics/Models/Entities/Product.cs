using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Intelliponics.Models.Entities 
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string Name { get; set; }
        public int SupplierID { get; set; }
        public int CategoryID { get; set; }
        public int SubCategoryID { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal OldPrice { get; set; }
        public decimal Discount { get; set; }
        public int UnitInStock { get; set; }
        public bool ProductAvailable { get; set; }
        public string ShortDescription { get; set; }
        public string PicturePath { get; set; }
        public string Note { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime LastUpdatedDateTime { get; set; }

        // Navigation Properties
        [ForeignKey("SupplierID")]
        public Supplier Supplier { get; set; }
        [ForeignKey("CategoryID")]
        public Category Category { get; set; }
        [ForeignKey("SubCategoryID")]
        public SubCategory SubCategory { get; set; }
    }
}
