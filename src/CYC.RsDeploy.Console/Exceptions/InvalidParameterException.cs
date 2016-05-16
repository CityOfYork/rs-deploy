using System;

namespace CYC.RsDeploy.Console.Exceptions
{
    public class InvalidParameterException : Exception
    {
        public InvalidParameterException(Exception innerException) 
            : base(innerException.Message, innerException)
        {
        }

        public InvalidParameterException(Exception innerException, string message)
            : base(message, innerException)
        {
        }
    }
}
