namespace RestaurantManagementSystem.Models
{
    
        public class Discount
        {
            public int DiscountId { get; set; }
            public string DiscountCode { get; set; }
            public decimal DiscountAmount { get; set; }
            public DateTime ValidFrom { get; set; }
            public DateTime ValidTo { get; set; }
            public bool IsActive { get; set; }
        }
    

}
