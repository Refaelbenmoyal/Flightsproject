using System;
using System.Collections.Generic;
using System.Text;

namespace FlightsProject
{
    public class Airline
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public object Id { get; internal set; }

        public override string ToString()
        {
            return $"{Name} {Password}";
        }
    }
}
