using System;

namespace Api.Infrastructure.HttpClient
{
    public interface IBaseHttpClientUrlProvider
    {
        Uri GetBaseApiUrl();
    }
}
