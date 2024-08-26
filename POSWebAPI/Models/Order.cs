namespace RestaurantManagementSystem.Models
{
    public class Order
    {
        
        public int OrderItems { get; set; }
        public int CustomerId { get; set; }
        
        public string  CustomerName { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } = "Pending";
        public DateTime OrderDate { get; set; }
        public int TableNumber { get; set; } // Optional, if relevant to your app
        public DateTime? ReservationTime { get; set; } // Optional, if applicable
    }

}
