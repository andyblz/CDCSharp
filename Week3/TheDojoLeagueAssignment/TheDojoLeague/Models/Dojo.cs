using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace TheDojoLeague.Models
{
    public class Dojo
    {
        public Dojo() {
            ninjas = new List<Ninja>();
        }

        [Key]
        public long id { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string location { get; set; }

        public string description { get; set; }

        public ICollection<Ninja> ninjas { get; set; }
    }
}