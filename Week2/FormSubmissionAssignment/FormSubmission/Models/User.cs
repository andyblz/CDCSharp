using System;
using System.ComponentModel.DataAnnotations;


namespace FormSubmission.Models
{
    public class User
    {
        [Required]
        [RegularExpression("([a-zA-Z]+)", ErrorMessage = "Enter only alphabetical letters.")]
        public string FirstName { get; set; }

        [Required]
        [RegularExpression("([a-zA-Z]+)", ErrorMessage = "Enter only alphabetical letters.")]
        public string LastName { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required]
        [MinLength(8)]
        public string Password { get; set; }
    }
}