using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PaintSharp.Core.Exceptions
{
    public class GetPathFailedException : Exception
    {
        public GetPathFailedException()
        {
        }

        public GetPathFailedException(string? message) : base(message)
        {
        }

        public GetPathFailedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
