using System;

namespace TheDojoLeague.Models
{
    public class Ninja
    {
        public long id { get; set; }
        public string name { get; set; }
        public int level { get; set; }
        public int dojo_id { get; set; }
        public Dojo dojo { get; set; }
    }
}