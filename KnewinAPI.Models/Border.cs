using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace KnewinAPI.Models
{
    public class Border
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string City { get; set; }
        public Guid CityId { get; set; }
    }
}
