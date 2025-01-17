using System.Text.Json.Serialization;

namespace Intelliponics.Models.ViewModels
{
    public class ProductViewModel
    {
        [JsonPropertyName("ProductID")]
        public int ProductID { get; set; }

        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("Category")]
        public string Category { get; set; }

        [JsonPropertyName("UnitInStock")]
        public int UnitInStock { get; set; }

        [JsonPropertyName("ProductAvailable")]
        public bool ProductAvailable { get; set; }

        [JsonPropertyName("LastUpdated")]
        public DateTime LastUpdated { get; set; }
    }
}
