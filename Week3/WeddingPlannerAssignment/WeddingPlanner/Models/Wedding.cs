using System;
using System.Collections.Generic;

namespace WeddingPlanner.Models
{
    public class Wedding : BaseEntity
    {
        public int weddingId { get; set; }
        public string wedder_one { get; set; }
        public string wedder_two { get; set; }
        public DateTime wedding_date { get; set; }
        public string address { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }

        // Add wedding one-one relationship here.
        public User user { get; set; }
        public int userId { get; set; }


        // Add user/wedding many-many relationship here.
        public List<WeddingUser> Guests { get; set; }
    }
}