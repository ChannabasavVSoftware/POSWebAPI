namespace RestaurantManagementSystem.Models
{
   
    
        public class Table
        {
            public int TableId { get; set; }
            public int TableNumber { get; set; }
            public int SeatingCapacity { get; set; }
            public bool IsOccupied { get; set; }
            public string Status { get; set; } = "Available"; // or "Occupied", "Reserved"
        }
}

