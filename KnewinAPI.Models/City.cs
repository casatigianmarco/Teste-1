using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace KnewinAPI.Models
{
    public class City
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Population { get; set; }
        public List<Border> Border { get; set; }
    }
}
