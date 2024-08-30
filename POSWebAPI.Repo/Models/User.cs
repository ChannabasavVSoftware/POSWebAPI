using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace POSWebAPI.Repo.Models
{
    public class User
    {
        [Key]
        public string MobileNumber { get; set; }  // Primary 
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime RemovedOn { get; set; }
        public DateTime LastActive { get; set; }
        public Guid RoleId { get; set; }
        public Guid AddressId { get; set; }


        public Role Role { get; set; }
        public Address Address { get; set; }


        [JsonIgnore]
        public ICollection<Order> Orders { get; set; }
    }
}
