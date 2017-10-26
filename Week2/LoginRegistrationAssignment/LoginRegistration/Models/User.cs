using System.ComponentModel.DataAnnotations;

namespace LoginRegistration.Models
{
    public class Register
    {
        [Required]
        [MinLength(2)]
        [RegularExpression("([a-zA-Z]+)", ErrorMessage = "Enter only alphabetical letters.")]
        public string firstName { get; set; }

        [Required]
        [MinLength(2)]
        [RegularExpression("([a-zA-Z]+)", ErrorMessage = "Enter only alphabetical letters.")]
        public string lastName { get; set; }

        [Required]
        [EmailAddress]
        public string email { get; set; }

        [Required]
        [MinLength(8)]
        public string password { get; set; }

        [Required]
        [Compare("password", ErrorMessage = "Passwords must match")]
        public string cpassword { get; set; }
    }

    public class Login
    {
        [Required]
        [EmailAddress]
        [Display(Name="email")]
        public string login_email { get; set; }

        [Required]
        [MinLength(8)]
        [Display(Name="password")]    
        public string login_password { get; set; }
    }

    public class LogReg
    {
        public Register RegisterModel { get; set;}
        public Login LoginModel { get; set; }
    }
}