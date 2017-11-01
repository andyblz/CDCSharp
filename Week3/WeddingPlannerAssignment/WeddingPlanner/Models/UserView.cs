using System;
using System.ComponentModel.DataAnnotations;


namespace WeddingPlanner.Models
{
    public class RegisterView : BaseEntity
    {
        [Required]
        [MinLength(1)]
        [RegularExpression("([a-zA-Z]+)", ErrorMessage = "First name can only include alphabetical letters.")]
        [Display(Name = "first name")]
        public string firstName { get; set; }

        [Required]
        [MinLength(1)]
        [RegularExpression("([a-zA-Z]+)", ErrorMessage = "Last name can only include alphabetical letters.")]
        [Display(Name = "last name")]
        public string lastName { get; set; }

        [Required]
        [EmailAddress]
        public string email { get; set; }

        [Required]
        [MinLength(8, ErrorMessage = "Password must be 8 or more characters long.")]
        public string password { get; set; }

        [Required]
        [Compare("password", ErrorMessage = "Passwords must match.")]
        [Display(Name = "password")] 
        public string confirmPassword { get; set; }
    }

    public class LoginView : BaseEntity
    {
        [Required]
        [EmailAddress]
        [Display(Name = "email")]
        public string loginEmail { get; set; }

        [Required]
        [MinLength(8)]
        [Display(Name = "password")]        
        public string loginPassword { get; set; }
    }

    // public class LogReg
    // {
    //     public RegisterView registerUser { get; set;}
    //     public LoginView loginUser { get; set; }
    // }
}