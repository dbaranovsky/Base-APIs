using System.Net;
using System.Net.Http;
using Dorian.RouteApi.Infrastructure.Exceptions;

namespace Dorian.RouteApi.Infrastructure.HttpClient.Extensions
{
    public static class HttpResponseMessageExtension
    {
        public static void EnsureCustomSuccessStatusCode(this HttpResponseMessage httpResponseMessage)
        {
            if (httpResponseMessage.StatusCode == HttpStatusCode.Unauthorized ||
                httpResponseMessage.StatusCode == HttpStatusCode.NotFound)
            {
                throw new ApiException($"{(int)httpResponseMessage.StatusCode}: {httpResponseMessage.ReasonPhrase}");
            }

            if (httpResponseMessage.StatusCode == HttpStatusCode.BadRequest)
            {
                throw new ApiValidationException(httpResponseMessage.ReasonPhrase);
            }

            httpResponseMessage.EnsureSuccessStatusCode();
        }
    }
}
