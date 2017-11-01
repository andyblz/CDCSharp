using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;


namespace WeddingPlanner.Models
{
    public class WeddingView : BaseEntity
    {
        [Required]
        [MinLength(1)]
        [RegularExpression("([a-zA-Z]+)", ErrorMessage = "Wedder name can only include alphabetical letters.")]
        [Display(Name = "wedder one")]
        public string wedderOne { get; set; }

        [Required]
        [MinLength(1)]
        [RegularExpression("([a-zA-Z]+)", ErrorMessage = "Wedder name can only include alphabetical letters.")]
        [Display(Name = "wedder two")]
        public string wedderTwo { get; set; }

        [Required(ErrorMessage = "Wedding date is required.")]
        [Display(Name = "wedding date")]
        public DateTime? weddingDate { get; set; }

        [Required]
        [MinLength(1)]
        public string address { get; set; }
    }
}