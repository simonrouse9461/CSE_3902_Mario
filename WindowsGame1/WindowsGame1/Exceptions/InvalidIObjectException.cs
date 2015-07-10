using System;

namespace WindowsGame1.Exceptions
{
    public class InvalidIObjectException : Exception
    {
        public InvalidIObjectException(string message) : base(message) { }
    }
}