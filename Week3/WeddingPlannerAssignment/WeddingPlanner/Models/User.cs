using System;
using System.Collections.Generic;


namespace WeddingPlanner.Models
{
    public class User : BaseEntity
    {
        public int userId { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }


        // Add user/wedding many-many relationship here.
        public ICollection<WeddingUser> Weddings { get; set; }
        public User()
        {
            Weddings = new List<WeddingUser>();
        }
    }
}