namespace RestaurantManagementSystem.Models
{
   
        public class MenuItem
        {
            public int MenuItemId { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
            public string Description { get; set; }
            public bool IsAvailable { get; set; }
            public string Category { get; set; } // e.g., Appetizer, Main Course, Dessert
            public bool IsDeleted { get; set; }
        }
    

}
