using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace POSWebAPI.Repo.Models
{
    public class State
    {
        [Key]
        public Guid Id { get; set; }

        public string StateName { get; set; }

        public Guid CountryId { get; set; }



        public Country Country { get; set; }


        [JsonIgnore]
        public ICollection<City> Cities { get; set; } = new List<City>();
    }
}
