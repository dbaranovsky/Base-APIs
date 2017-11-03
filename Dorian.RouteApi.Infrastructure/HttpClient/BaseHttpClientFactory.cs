using System.Collections.Generic;

namespace Dorian.RouteApi.Infrastructure.HttpClient
{
    public class BaseHttpClientFactory : IBaseHttpClientFactory
    {
        private readonly IBaseHttpClientUrlProvider baseHttpClientUrlProvider;

        public BaseHttpClientFactory(IBaseHttpClientUrlProvider baseHttpClientUrlProvider)
        {
            this.baseHttpClientUrlProvider = baseHttpClientUrlProvider;
        }

        public System.Net.Http.HttpClient Create(Dictionary<string, string> headers = null)
        {
            var httpClient = new System.Net.Http.HttpClient
            {
                BaseAddress = baseHttpClientUrlProvider.GetBaseApiUrl()
            };

            if (headers != null)
            {
                foreach (var header in headers)
                {
                    httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
                }
            }

            return httpClient;
        }
    }
}
