using System.ComponentModel.DataAnnotations;

namespace TheWall.Models
{
    public class MessagePost
    {
        [Required(ErrorMessage = "Message cannot be blank.")]
        [MinLength(5)]
        [Display(Name = "Message Post")]        
        public string messagePost { get; set; }
    }

    public class CommentPost
    {
        [Required]
        [MinLength(5)]
        [Display(Name = "Comment Post")]
        public string commentPost { get; set; }
        public int messageID { get; set; }
    }
}