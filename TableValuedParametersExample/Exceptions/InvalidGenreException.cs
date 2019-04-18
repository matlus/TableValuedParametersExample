using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TableValuedParametersExample
{
    [Serializable]
    public sealed class InvalidGenreException : Exception
    {
        public InvalidGenreException() { }
        public InvalidGenreException(string message) : base(message) { }
        public InvalidGenreException(string message, Exception inner) : base(message, inner) { }
        private InvalidGenreException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
