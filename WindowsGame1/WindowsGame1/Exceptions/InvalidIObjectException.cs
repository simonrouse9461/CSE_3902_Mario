using System;

namespace MarioGame.Exceptions
{
    public class InvalidIObjectException : Exception
    {
        public InvalidIObjectException(string message) : base(message) { }
    }
}