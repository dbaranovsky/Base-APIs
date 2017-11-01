using System;

namespace Api.Infrastructure.Exceptions
{
    public class ApiValidationException : Exception
    {
        public ApiValidationException(string message) : base(message)
        {

        }

        public ApiValidationException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
