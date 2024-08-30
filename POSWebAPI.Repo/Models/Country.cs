using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace POSWebAPI.Repo.Models
{
    public class Country
    {
        [Key]
        public Guid Id { get; set; }

        public string CountryName { get; set; }



        [JsonIgnore]
        public ICollection<State> States { get; set; }
    }
}
