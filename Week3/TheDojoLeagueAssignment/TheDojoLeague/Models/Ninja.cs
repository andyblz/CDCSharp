using System;
using System.ComponentModel.DataAnnotations;

namespace TheDojoLeague.Models
{
    public class Ninja
    {
        [Key]
        public long id { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public int level { get; set; }

        public Dojo dojo { get; set; }

        public int dojo_id { get; set; }
    }
}