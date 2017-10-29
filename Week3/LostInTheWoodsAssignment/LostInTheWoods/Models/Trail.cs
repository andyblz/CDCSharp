using System.ComponentModel.DataAnnotations;

namespace LostInTheWoods.Models
{
    public class Trail
    {
        [Required]
        [MinLength(1)]
        public string name { get; set; }
 
        [Required]
        [MinLength(1)]
        public string description { get; set; }
 
        [Required]
        public int length { get; set; }
 
        [Required]
        [Display(Name="elevation change")]
        public int elevationChange { get; set; }

        [Required]
        public float longitude { get; set; }

        [Required]
        public float latitude { get; set; }
    }
}