namespace RestaurantManagementSystem.Models
{
    public class OrderItem
    {
        public List<OrderItem>  Id { get; set; }
        // Unique identifier for the order item
        public int OrderItemId { get; set; }
      
        // Foreign key to the Order
        public int OrderId { get; set; }
      
        // Navigation property to the Order
        public Order Order { get; set; }
        // Foreign key to the MenuItem
        public int MenuItemId { get; set; }
        // Navigation property to the MenuItem
        public MenuItem MenuItem { get; set; }
        // Quantity of the menu item ordered
        public int Quantity { get; set; }
        // Price per unit of the menu item
        public decimal UnitPrice { get; set; } 
    }

}
