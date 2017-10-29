using System.ComponentModel.DataAnnotations;

namespace LostInTheWoods.Models
{
    public class Trail
    {
        [Key]
        public int id { get; set; }

        [Required]
        [MinLength(1)]
        public string name { get; set; }
 
        [Required]
        [MinLength(1)]
        [MaxLength(255)]
        [Display(Name = "description")]
        public string description { get; set; }
 
        [Required(ErrorMessage = "Length required")]
        public float? length { get; set; }
 
        [Required(ErrorMessage = "Elevation required")]
        [Display(Name = "elevation change")]
        public int? elevation { get; set; }

        [Required(ErrorMessage = "Longitude required")]
        public float? longitude { get; set; }

        [Required(ErrorMessage = "Latitude required")]
        public float? latitude { get; set; }
    }
}