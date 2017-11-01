using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Api.Common.Extensions;
using Api.Infrastructure.HttpClient.Extensions;

namespace Api.Infrastructure.HttpClient
{
    public class BaseHttpClient<TResult> : IBaseHttpClient<TResult>
    {
        private readonly IBaseHttpClientFactory httpClientFactory;

        public BaseHttpClient(IBaseHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<TResult> Get(string url, Dictionary<string, string> headers = null)
        {
            using (var httpClient = httpClientFactory.Create(headers))
            {
                var response = await httpClient.GetAsync(url);
                if (!response.IsSuccessStatusCode)
                {
                    response.EnsureCustomSuccessStatusCode();
                }
                
                return await response.Content.ReadAsAsync<TResult>();
            }
        }

        public async Task<TResult> Post(string url, HttpContent httpContent, Dictionary<string, string> headers = null)
        {
            using (var httpClient = httpClientFactory.Create(headers))
            {
                var response = await httpClient.PostAsync(httpClient.BaseAddress.CombineWithUrl(url).ToString(), httpContent);
                if (!response.IsSuccessStatusCode)
                {
                    response.EnsureCustomSuccessStatusCode();
                }

                return await response.Content.ReadAsAsync<TResult>();
            }
        }

        public async Task<TResult> PostAsJson<T>(string url, T postData, Dictionary<string, string> headers = null)
        {
            using (var httpClient = httpClientFactory.Create(headers))
            {
                var response = await httpClient.PostAsJsonAsync(httpClient.BaseAddress.CombineWithUrl(url).ToString(), postData);
                if (!response.IsSuccessStatusCode)
                {
                    response.EnsureCustomSuccessStatusCode();
                }

                return await response.Content.ReadAsAsync<TResult>();
            }
        }

        public async Task<TResult> PostAsXml<T>(string url, T postData, Dictionary<string, string> headers = null)
        {
            using (var httpClient = httpClientFactory.Create(headers))
            {
                var response = await httpClient.PostAsXmlAsync(httpClient.BaseAddress.CombineWithUrl(url).ToString(), postData);
                if (!response.IsSuccessStatusCode)
                {
                    response.EnsureCustomSuccessStatusCode();
                }

                return await response.Content.ReadAsAsync<TResult>();
            }
        }

        public async Task<TResult> Put(string url, Dictionary<string, string> headers, HttpContent httpContent = null)
        {
            using (var httpClient = httpClientFactory.Create(headers))
            {
                var response = await httpClient.PutAsync(httpClient.BaseAddress.CombineWithUrl(url), httpContent);
                if (!response.IsSuccessStatusCode)
                {
                    response.EnsureCustomSuccessStatusCode();
                }

                return await response.Content.ReadAsAsync<TResult>();
            }
        }

        public async Task<TResult> Delete(string url, Dictionary<string, string> headers)
        {
            using (var httpClient = httpClientFactory.Create(headers))
            {
                var response = await httpClient.DeleteAsync(httpClient.BaseAddress.CombineWithUrl(url));
                if (!response.IsSuccessStatusCode)
                {
                    response.EnsureCustomSuccessStatusCode();
                }

                return await response.Content.ReadAsAsync<TResult>();
            }
        }
    }
}
