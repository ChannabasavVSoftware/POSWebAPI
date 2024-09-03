using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace POSWebAPI.Repo.Models
{
    public class Role
    {
        [Key]
        public Guid Id { get; set; }

        public string RoleName { get; set; }


        [JsonIgnore]
        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
