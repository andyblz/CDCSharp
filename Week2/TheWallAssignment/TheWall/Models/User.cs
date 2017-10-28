using System.ComponentModel.DataAnnotations;

namespace TheWall.Models
{
    public class Register
    {
        [Required]
        [MinLength(2)]
        [RegularExpression("([a-zA-Z]+)", ErrorMessage = "Enter only alphabetical letters.")]
        [Display(Name = "First Name")]        
        public string firstName { get; set; }

        [Required]
        [MinLength(2)]
        [RegularExpression("([a-zA-Z]+)", ErrorMessage = "Enter only alphabetical letters.")]
        [Display(Name = "Last Name")]        
        public string lastName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]        
        public string email { get; set; }

        [Required]
        [MinLength(8)]
        [Display(Name = "Password")]        
        public string password { get; set; }

        [Required]
        [Compare("password", ErrorMessage = "Passwords must match")]
        [Display(Name = "Password")]                
        public string confirmPassword { get; set; }
    }

    public class Login
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string loginEmail { get; set; }

        [Required]
        [MinLength(8)]   
        [Display(Name = "Password")]         
        public string loginPassword { get; set; }
    }

    public class LogReg
    {
        public Register registerUser { get; set;}
        public Login loginUser { get; set; }
    }
}