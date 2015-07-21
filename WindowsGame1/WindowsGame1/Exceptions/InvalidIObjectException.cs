using System;

namespace MarioGame
{
    public class InvalidIObjectException : Exception
    {
        public InvalidIObjectException(string message) : base(message) { }
    }
}