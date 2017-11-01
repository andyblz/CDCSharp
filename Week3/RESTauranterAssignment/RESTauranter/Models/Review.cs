using System;


namespace RESTauranter.Models
{
    public class Review
    {
        public int id { get; set; }
        public string reviewer { get; set; }
        public string restaurantName { get; set; }       
        public string review { get; set; }    
        public int rating { get; set; }
        public DateTime created_at { get; set; }
    }
}