using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class RegisterView
    {
        [Required]
        [MinLength(1)]
        [RegularExpression("([a-zA-Z_ ]+)", ErrorMessage = "Name can only include alphabetical letters.")]
        [Display(Name = "name")]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(8, ErrorMessage = "Password must be 8 or more characters long.")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Passwords must match.")]
        [Display(Name = "password")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginView
    {
        [Required]
        [EmailAddress]
        [Display(Name = "email")]
        public string LoginEmail { get; set; }

        [Required]
        [MinLength(8)]
        [Display(Name = "password")]
        public string LoginPassword { get; set; }
    }
}
