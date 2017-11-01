using System;
using System.ComponentModel.DataAnnotations;


namespace WeddingPlanner.Models
{
    public class WeddingUser : BaseEntity
    {
        [Key]
        public int weddingsUsersId { get; set; }
        
        public int rsvpduser_userId { get; set; }
        public User user { get; set; }

        public int weddingrsvpd_weddingId { get; set; }
        public Wedding wedding { get; set; }
    }
}