using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace POSWebAPI.Repo.Models
{
    public class Payment
    {
        [Key]
        public Guid Id { get; set; }

        public string PaymentType { get; set; }

        public DateTime PaymentDate { get; set; }

        public decimal AmountPaid { get; set; }


        [JsonIgnore]
        public ICollection<Order> Orders { get; set; }
    }
}
