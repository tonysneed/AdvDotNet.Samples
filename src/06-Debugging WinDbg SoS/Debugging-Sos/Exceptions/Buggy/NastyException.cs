using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buggy
{
    [Serializable]
    public class NastyException : Exception
    {
        public NastyException() { }
        public NastyException(string message) : base(message) { }
        public NastyException(string message, Exception inner) : base(message, inner) { }
        protected NastyException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
