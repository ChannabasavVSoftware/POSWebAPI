using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace POSWebAPI.Repo.Models
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }

        public string ProductName { get; set; }

        public string ProductDescription { get; set; } = string.Empty;

        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid TaxId { get; set; }
        public Guid ProductCategoryId { get; set; }

        [JsonIgnore]
        public Tax? Tax { get; set; }    // Navigation property to Tax
        [JsonIgnore]
        public ProductCategory? ProductCategory { get; set; }


        [JsonIgnore]
        public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}
