using System;

namespace BeTheHero.Essential
{
    public class InvalidArgumentException : ArgumentException
    {
        public InvalidArgumentException(string argumentName)
            : base($"{argumentName} is not valid", argumentName)
        {
        }

        public InvalidArgumentException(string argumentName, string message)
            : base(message, argumentName)
        {
        }

        public InvalidArgumentException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public InvalidArgumentException()
            : base()
        {
        }
    }
}
