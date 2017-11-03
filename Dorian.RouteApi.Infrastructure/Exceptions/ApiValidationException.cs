using System;

namespace Dorian.RouteApi.Infrastructure.Exceptions
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
