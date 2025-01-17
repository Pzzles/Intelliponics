using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Intelliponics.Models.Entities 
{
    public class SubCategory
    {
        [Key]
        public int SubCategoryID { get; set; }
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool isActive { get; set; }

        // Navigation Property
        [ForeignKey("CategoryID")]
        public Category Category { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
