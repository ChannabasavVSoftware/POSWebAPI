using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace POSWebAPI.Repo.Models
{
    public class Address
    {
        [Key]
        public Guid Id { get; set; }

        public string Street { get; set; }

        public Guid CityId { get; set; }



        public City City { get; set; }

        public int PostalCode { get; set; }


        [JsonIgnore]
        public ICollection<User> Users { get; set; }
    }
}
