using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace POSWebAPI.Repo.Models
{
    public class City
    {
        [Key]
        public Guid Id { get; set; }

        public string CityName { get; set; }

        public Guid StateId { get; set; }


        [JsonIgnore]
        public State? State { get; set; }


        [JsonIgnore]
        public ICollection<Address> Addresses { get; set; } = new List<Address>();
    }
}
