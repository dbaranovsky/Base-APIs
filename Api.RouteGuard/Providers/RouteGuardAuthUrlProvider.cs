using System;
using System.Configuration;
using Api.Common.Constants;

namespace Api.RouteGuard.Providers
{
    public class RouteGuardAuthUrlProvider : IRouteGuardAuthUrlProvider
    {
        public Uri GetBaseApiUrl()
        {
            return new Uri(ConfigurationManager.AppSettings[ConfigurationKeys.RouteGuardAuthUrl]);
        }
    }
}
