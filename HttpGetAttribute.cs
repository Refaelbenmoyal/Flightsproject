using System;

namespace FlightsProject
{
    internal class HttpGetAttribute : Attribute
    {
        private string v;

        public HttpGetAttribute(string v)
        {
            this.v = v;
        }
    }
}