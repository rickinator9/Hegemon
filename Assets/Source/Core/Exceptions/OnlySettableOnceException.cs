using System;

namespace Assets.Source.Core.Exceptions
{
    public class OnlySettableOnceException : Exception
    {
        public OnlySettableOnceException()
        {
            
        }

        public OnlySettableOnceException(string message) :base(message)
        {
            
        }

        public OnlySettableOnceException(string message, Exception innerException) : base(message, innerException)
        {
            
        }
    }
}