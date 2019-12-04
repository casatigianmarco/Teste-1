using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace KnewinAPI.Models
{
    public class Border
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string City { get; set; }
        [JsonIgnore]
        public Guid CityId { get; set; }
    }
}
