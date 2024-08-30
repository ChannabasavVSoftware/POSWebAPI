using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace POSWebAPI.Repo.Models
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime OrderDate { get; set; }

        public string MobileNumber { get; set; }  // Foreign Key references User
        public string EmployeeId { get; set; }  // To store Employees Id who is created the order
        public decimal TaxableAmount { get; set; }
        public decimal TotalTax { get; set; }
        public decimal TotalAmount { get; set; }

        public string OrderStatus { get; set; }
        public string PaymentStatus { get; set; }

        public Guid PaymentId { get; set; }



        public User User { get; set; }

        public Payment Payment { get; set; }


        [JsonIgnore]
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
