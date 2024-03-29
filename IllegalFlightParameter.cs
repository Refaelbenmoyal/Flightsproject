﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FlightsProject
{
    [Serializable]
    public class IllegalFlightParameter : Exception
    {
        public IllegalFlightParameter()
        {
        }

        public IllegalFlightParameter(string message) : base(message)
        {
        }

        public IllegalFlightParameter(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected IllegalFlightParameter(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

}
