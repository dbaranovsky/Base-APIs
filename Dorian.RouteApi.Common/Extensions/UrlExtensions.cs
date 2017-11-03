using System;

namespace Dorian.RouteApi.Common.Extensions
{
    public static class UrlExtensions
    {
        public static Uri CombineWithUrl(this Uri baseUrl, string relativeUrl)
        {
            return new Uri(baseUrl, relativeUrl);
        }
    }
}
