using System;

namespace Dorian.RouteApi.Infrastructure.HttpClient
{
    public interface IBaseHttpClientUrlProvider
    {
        Uri GetBaseApiUrl();
    }
}
