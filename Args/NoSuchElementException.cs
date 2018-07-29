//========================================================================
// This conversion was produced by the Free Edition of
// Java to C# Converter courtesy of Tangible Software Solutions.
// Purchase the Premium Edition at https://www.tangiblesoftwaresolutions.com
//========================================================================

using System;
using System.Runtime.Serialization;

namespace com.cleancoder.args
{
    [Serializable]
    internal class NoSuchElementException : Exception
    {
        public NoSuchElementException()
        {
        }

        public NoSuchElementException(string message) : base(message)
        {
        }

        public NoSuchElementException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NoSuchElementException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}