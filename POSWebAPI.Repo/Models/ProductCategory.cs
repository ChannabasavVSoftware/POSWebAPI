using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace POSWebAPI.Repo.Models
{
    public class ProductCategory
    {
        [Key]
        public Guid Id { get; set; }

        public string CategoryName { get; set; }

        public string CategoryDescription { get; set; } = string.Empty;

        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;


        [JsonIgnore]
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
