namespace RestaurantManagementSystem.Models
{
    
        public class Payment
        {
            public int PaymentId { get; set; }
            public int OrderId { get; set; }
            public decimal Amount { get; set; }
            public decimal TipAmount { get; set; } // Optional
            public string Status { get; set; } = "Pending"; // or "Completed", "Failed"
            public string PaymentType { get; set; } // e.g., Cash, Credit Card
            public DateTime PaymentDate { get; set; }
        }
    

}
