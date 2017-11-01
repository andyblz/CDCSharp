using System.ComponentModel.DataAnnotations;


namespace RESTauranter.Models
{
    public class ReviewView
    {
        [Required]
        [Display(Name = "reviewer name")]
        public string reviewer { get; set; }

        [Required]    
        [Display(Name = "restaurant name")]            
        public string restaurantName { get; set; }

        [Required]        
        public string review { get; set; }

        [Required]     
        public int rating { get; set; }
    }
}