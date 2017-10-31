using System;
using System.Text;

namespace Api.Infrastructure.Extensions
{
    public static class StringExtensions
    {
        public static string ToBase64(this string input)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(input);
            return Convert.ToBase64String(plainTextBytes);
        }
    }
}
