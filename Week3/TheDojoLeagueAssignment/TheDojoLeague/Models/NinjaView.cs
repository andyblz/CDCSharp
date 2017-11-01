using System;
using System.ComponentModel.DataAnnotations;

namespace TheDojoLeague.Models
{
    public class NinjaView
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage="Cannot be non-letter characters.")]
        public string name { get; set; }

        [Required]
        public int level { get; set; }

        public int dojo_id { get; set; }
    }
}