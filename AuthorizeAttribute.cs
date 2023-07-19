using System;

namespace FlightsProject
{
    internal class AuthorizeAttribute : Attribute
    {
        public string Roles { get; set; }
    }
}