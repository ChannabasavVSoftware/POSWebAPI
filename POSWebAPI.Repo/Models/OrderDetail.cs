using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace POSWebAPI.Repo.Models
{
    public class OrderDetail
    {
        [Key]
        public Guid Id { get; set; }

        public Guid OrderId { get; set; }

        public Guid ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public Guid TaxId { get; set; }



        [JsonIgnore]
        public Order? Order { get; set; }
        [JsonIgnore]
        public Product? Product { get; set; }

        public Tax? Tax { get; set; }
    }
}
