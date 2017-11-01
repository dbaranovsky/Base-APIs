using System.Net;
using System.Net.Http;
using System.Web;
using Api.Infrastructure.Exceptions;

namespace Api.Infrastructure.HttpClient.Extensions
{
    public static class HttpResponseMessageExtension
    {
        public static void EnsureCustomSuccessStatusCode(this HttpResponseMessage httpResponseMessage)
        {
            if (httpResponseMessage.StatusCode == HttpStatusCode.Unauthorized ||
                httpResponseMessage.StatusCode == HttpStatusCode.NotFound)
            {
                throw new HttpException((int)httpResponseMessage.StatusCode, httpResponseMessage.ReasonPhrase);
            }

            if (httpResponseMessage.StatusCode == HttpStatusCode.BadRequest)
            {
                throw new ApiValidationException(httpResponseMessage.ReasonPhrase);
            }

            httpResponseMessage.EnsureSuccessStatusCode();
        }
    }
}
