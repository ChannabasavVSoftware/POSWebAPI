using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace POSWebAPI.Repo.Models
{
    public class Tax
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public string TaxName { get; set; }

        public decimal TaxRate { get; set; }



        [JsonIgnore]
        public ICollection<Product> Products { get; set; } = new List<Product>(); // Navigation property
        [JsonIgnore]
        public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}
