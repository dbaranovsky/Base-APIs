using System;
using System.Configuration;
using Api.Common.Constants;

namespace Api.RouteGuard.Providers
{
    public class RouteGuardUrlProvider : IRouteGuardUrlProvider
    {
        public Uri GetBaseApiUrl()
        {
            return new Uri(ConfigurationManager.AppSettings[ConfigurationKeys.RouteGuardBaseUrl]);
        }
    }
}
