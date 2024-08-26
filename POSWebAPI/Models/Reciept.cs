namespace RestaurantManagementSystem.Models
{
    
        public class Receipt
        {
            public int ReceiptId { get; set; }
            public int OrderId { get; set; }
            public DateTime IssuedDate { get; set; }
            public decimal TotalAmount { get; set; }
            public string ReceiptNumber { get; set; }
        }
    

}
