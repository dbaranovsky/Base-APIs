using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Api.Infrastructure.HttpClient
{
    public interface IBaseHttpClient<TResult>
    {
        Task<TResult> Get(string url, Dictionary<string, string> headers = null);
        Task<TResult> Post(string url, HttpContent httpContent, Dictionary<string, string> headers = null);
        Task<TResult> PostAsJson<T>(string url, T postData, Dictionary<string, string> headers = null);
        Task<TResult> PostAsXml<T>(string url, T postData, Dictionary<string, string> headers = null);
        Task<TResult> Put(string url, Dictionary<string, string> headers = null, HttpContent httpContent = null);
        Task<TResult> Delete(string url, Dictionary<string, string> headers = null);
    }
}