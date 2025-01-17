using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Intelliponics.Models.Entities 
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool isActive { get; set; }

        // Navigation Property
        public ICollection<SubCategory> SubCategories { get; set; }
        public ICollection<Product> Products { get; set; }
    }

}
