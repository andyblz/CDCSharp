using System;
using System.ComponentModel.DataAnnotations;


namespace WeddingPlanner.Models
{
    public class WeddingUser : BaseEntity
    {
        [Key]
        public int rsvpId { get; set; }   
        public int userId { get; set; }
        public User Guest { get; set; }
        public int weddingId { get; set; }
    }
}