using System.Collections.Generic;

namespace Dorian.RouteApi.Infrastructure.HttpClient
{
    public interface IBaseHttpClientFactory
    {
        System.Net.Http.HttpClient Create(Dictionary<string, string> headers = null);
    }
}
