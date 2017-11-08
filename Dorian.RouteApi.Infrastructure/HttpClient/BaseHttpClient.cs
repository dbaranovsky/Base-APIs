using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Dorian.RouteApi.Common.Constants;
using Dorian.RouteApi.Common.Extensions;
using Dorian.RouteApi.Infrastructure.HttpClient.Contents;
using Dorian.RouteApi.Infrastructure.HttpClient.Extensions;
using Newtonsoft.Json;

namespace Dorian.RouteApi.Infrastructure.HttpClient
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

                if (typeof(TResult) == typeof(string))
                {
                    return (TResult) Convert.ChangeType(await response.Content.ReadAsStringAsync(), typeof(TResult));
                }

                return JsonConvert.DeserializeObject<TResult>(await response.Content.ReadAsStringAsync());
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

                var responseData = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TResult>(responseData);
            }
        }

        public async Task<TResult> PostAsJson<T>(string url, T postData, Dictionary<string, string> headers = null)
        {
            var jsonContent = new JsonContent(JsonConvert.SerializeObject(postData));

            using (var httpClient = httpClientFactory.Create(headers))
            {
                var response = await httpClient.PostAsync(httpClient.BaseAddress.CombineWithUrl(url).ToString(), jsonContent);
                if (!response.IsSuccessStatusCode)
                {
                    response.EnsureCustomSuccessStatusCode();
                }

                return JsonConvert.DeserializeObject<TResult>(await response.Content.ReadAsStringAsync());
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

                return JsonConvert.DeserializeObject<TResult>(await response.Content.ReadAsStringAsync());
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

                return JsonConvert.DeserializeObject<TResult>(await response.Content.ReadAsStringAsync());
            }
        }
    }
}
