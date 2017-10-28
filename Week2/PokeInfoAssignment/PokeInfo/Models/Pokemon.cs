using System;
using System.Collections.Generic;


namespace PokeInfo
{
    public class Pokemon
    {
        public object Name { get; set; }
        public object Photo { get; set; }
        public object ID { get; set; }
        public object PrimaryType { get; set; }
        public List<string> Types { get; set; }
        public object Height { get; set; }
        public object Weight { get; set; }

        public Pokemon()
        {

        }
    }
}
